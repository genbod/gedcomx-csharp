using System;
using RestSharp;
using System.Text;
using System.Collections.Generic;
using Gx.Conclusion;
using Gx.Rs.Api.Util;
using Gx.Links;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using Gx.Records;
using Gx.Common;
using Gedcomx.Model;
using Gedcomx.Support;

namespace Gx.Rs.Api
{
    public abstract class GedcomxApplicationState : HypermediaEnabledData
    {
        protected static readonly EmbeddedLinkLoader DEFAULT_EMBEDDED_LINK_LOADER = new EmbeddedLinkLoader();
        private readonly String gzipSuffix = "-gzip";
        public IFilterableRestClient Client { get; protected set; }
        public String CurrentAccessToken { get; set; }
        protected Tavis.LinkFactory linkFactory;
        protected Tavis.LinkHeaderParser linkHeaderParser;
        public bool IsAuthenticated { get { return CurrentAccessToken != null; } }
        public IRestRequest Request { get; protected set; }
        public IRestResponse Response { get; protected set; }
        public IRestRequest LastEmbeddedRequest { get; set; }
        public IRestResponse LastEmbeddedResponse { get; set; }

        public string ETag
        {
            get
            {
#warning ETag is causing HTTP 412 on all requests
                var result = this.Response != null ? this.Response.Headers.Get("ETag").Select(x => x.Value.ToString()).FirstOrDefault() : null;
                if (result != null && result.IndexOf(gzipSuffix) != -1)
                {
                    result = result.Replace(gzipSuffix, String.Empty);
                }
                return result;
            }
        }

        public DateTime? LastModified
        {
            get
            {
                return this.Response != null ? this.Response.Headers.Get("Last-Modified").Select(x => (DateTime?)DateTime.Parse(x.Value.ToString())).FirstOrDefault() : null;
            }
        }

        protected EmbeddedLinkLoader EmbeddedLinkLoader
        {
            get
            {
                return DEFAULT_EMBEDDED_LINK_LOADER;
            }
        }

        protected void Embed<T>(Link link, Gedcomx entity, params StateTransitionOption[] options) where T : Gedcomx
        {
            if (link.Href != null)
            {
                LastEmbeddedRequest = CreateRequestForEmbeddedResource(link.Rel).Build(link.Href, Method.GET);
                LastEmbeddedResponse = Invoke(LastEmbeddedRequest, options);
                if (LastEmbeddedResponse.StatusCode == HttpStatusCode.OK)
                {
                    entity.Embed(LastEmbeddedResponse.ToIRestResponse<T>().Data);
                }
                else if (LastEmbeddedResponse.HasServerError())
                {
                    throw new GedcomxApplicationException(String.Format("Unable to load embedded resources: server says \"{0}\" at {1}.", LastEmbeddedResponse.StatusDescription, LastEmbeddedRequest.Resource), LastEmbeddedResponse);
                }
                else
                {
                    //todo: log a warning? throw an error?
                }
            }
        }

        protected virtual IRestRequest CreateRequestForEmbeddedResource(String rel)
        {
            return CreateAuthenticatedGedcomxRequest();
        }

        protected internal IRestResponse Invoke(IRestRequest request, params StateTransitionOption[] options)
        {
            IRestResponse result;

            foreach (StateTransitionOption option in options)
            {
                option.Apply(request);
            }

            result = this.Client.Handle(request);

            return result;
        }

        protected internal IRestRequest CreateAuthenticatedGedcomxRequest()
        {
            return CreateAuthenticatedRequest().Accept(MediaTypes.GEDCOMX_JSON_MEDIA_TYPE).ContentType(MediaTypes.GEDCOMX_JSON_MEDIA_TYPE);
        }

        protected IRestRequest CreateAuthenticatedRequest()
        {
            IRestRequest request = CreateRequest();
            if (this.CurrentAccessToken != null)
            {
                request = request.AddHeader("Authorization", "Bearer " + this.CurrentAccessToken);
            }
            return request;
        }

        protected IRestRequest CreateRequest()
        {
            return new RestRequest();
        }

        protected void IncludeEmbeddedResources<T>(Gedcomx entity, params StateTransitionOption[] options) where T : Gedcomx
        {
            Embed<T>(EmbeddedLinkLoader.LoadEmbeddedLinks(entity), entity, options);
        }

        protected void Embed<T>(IEnumerable<Link> links, Gedcomx entity, params StateTransitionOption[] options) where T : Gedcomx
        {
            foreach (Link link in links)
            {
                Embed<T>(link, entity, options);
            }
        }
    }

    public abstract class GedcomxApplicationState<T> : GedcomxApplicationState where T : class, new()
    {
        protected internal readonly StateFactory stateFactory;
        public T Entity { get; private set; }
        protected abstract GedcomxApplicationState<T> Clone(IRestRequest request, IRestResponse response, IFilterableRestClient client);
        protected virtual T LoadEntity(IRestResponse response)
        {
            T result = null;

            if (response != null)
            {
                result = response.ToIRestResponse<T>().Data;
            }

            return result;
        }
        protected virtual SupportsLinks MainDataElement
        {
            get
            {
                return (SupportsLinks)Entity;
            }
        }

        protected GedcomxApplicationState()
        {
            linkFactory = new Tavis.LinkFactory();
            linkHeaderParser = new Tavis.LinkHeaderParser(linkFactory);
        }

        protected GedcomxApplicationState(IRestRequest request, IRestResponse response, IFilterableRestClient client, String accessToken, StateFactory stateFactory)
            : this()
        {
            this.Request = request;
            this.Response = response;
            this.Client = client;
            this.CurrentAccessToken = accessToken;
            this.stateFactory = stateFactory;
            this.Entity = LoadEntityConditionally(this.Response);
            List<Link> links = LoadLinks(this.Response, this.Entity, this.Request.RequestFormat);
            this.Links = new List<Link>();
            this.Links.AddRange(links);
        }

        protected virtual T LoadEntityConditionally(IRestResponse response)
        {
            if (Request.Method != Method.HEAD && Request.Method != Method.OPTIONS && response.StatusCode == HttpStatusCode.OK)
            {
                return LoadEntity(response);
            }
            else
            {
                return null;
            }
        }

        public GedcomxApplicationState<T> Inject(IRestRequest request)
        {
            return Clone(request, Invoke(request), this.Client);
        }

        protected List<Link> LoadLinks(IRestResponse response, T entity, DataFormat contentFormat)
        {
            List<Link> links = new List<Link>();
            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            //if there's a location, we'll consider it a "self" link.
            if (location != null && location.Value != null)
            {
                links.Add(new Link() { Rel = Rel.SELF, Href = location.Value.ToString() });
            }

            //initialize links with link headers
            foreach (var header in response.Headers.Where(x => x.Name == "Link" && x.Value != null).SelectMany(x => linkHeaderParser.Parse(response.ResponseUri, x.Value.ToString())))
            {
                Link link = new Link() { Rel = header.Relation, Href = header.Target.ToString() };
                link.Template = header.GetLinkExtensionSafe("template");
                link.Title = header.Title;
                link.Accept = header.GetLinkExtensionSafe("accept");
                link.Allow = header.GetLinkExtensionSafe("allow");
                link.Hreflang = header.HrefLang.Select(x => x.Name).FirstOrDefault();
                link.Type = header.GetLinkExtensionSafe("type");
                links.Add(link);
            }

            //load the links from the main data element
            SupportsLinks mainElement = MainDataElement;
            if (mainElement != null && mainElement.Links != null)
            {
                links.AddRange(mainElement.Links);
            }

            //load links at the document level
            var collection = entity as SupportsLinks;
            if (entity != mainElement && collection != null && collection.Links != null)
            {
                links.AddRange(collection.Links);
            }


            return links;
        }

        public string GetUri()
        {
            return this.Client.BaseUrl + this.Request.Resource;
        }

        public bool HasError()
        {
            return this.Response.HasClientError() || this.Response.HasServerError();
        }

        public bool HasStatus(HttpStatusCode status)
        {
            return this.Response.StatusCode == status;
        }

        public virtual GedcomxApplicationState<T> IfSuccessful()
        {
            if (HasError())
            {
                throw new GedcomxApplicationException(String.Format("Unsuccessful {0} to {1}", this.Request.Method, GetUri()), this.Response);
            }
            return this;
        }

        public virtual GedcomxApplicationState<T> Head(params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }

            request.Build(GetSelfUri(), Method.HEAD);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public virtual GedcomxApplicationState<T> Options(params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }
            request.Build(GetSelfUri(), Method.OPTIONS);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public virtual GedcomxApplicationState<T> Get(params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }

            request.Build(GetSelfUri(), Method.GET);
            IRestResponse response = Invoke(request, options);
            return Clone(request, response, this.Client);
        }

        public virtual GedcomxApplicationState<T> Delete(params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }
            request.Build(GetSelfUri(), Method.DELETE);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public virtual GedcomxApplicationState<T> Put(T entity, params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            Parameter contentType = this.Request.GetHeaders().Get("Content-Type").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }
            if (contentType != null)
            {
                request.ContentType(contentType.Value as string);
            }
            request.SetEntity(entity).Build(GetSelfUri(), Method.PUT);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public virtual GedcomxApplicationState<T> Post(T entity, params StateTransitionOption[] options)
        {
            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            Parameter contentType = this.Request.GetHeaders().Get("Content-Type").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }
            if (contentType != null)
            {
                request.ContentType(contentType.Value as string);
            }
            request.SetEntity(entity).Build(GetSelfUri(), Method.POST);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public List<HttpWarning> Warnings
        {
            get
            {
                List<HttpWarning> warnings = new List<HttpWarning>();
                IEnumerable<Parameter> warningValues = this.Response.Headers.Get("Warning");
                if (warningValues != null)
                {
                    foreach (Parameter warningValue in warningValues)
                    {
                        warnings.AddRange(HttpWarning.Parse(warningValue));
                    }
                }
                return warnings;
            }
        }

        public virtual GedcomxApplicationState<T> AuthenticateViaOAuth2Password(String username, String password, String clientId)
        {
            return AuthenticateViaOAuth2Password(username, password, clientId, null);
        }

        public virtual GedcomxApplicationState<T> AuthenticateViaOAuth2Password(String username, String password, String clientId, String clientSecret)
        {
            IDictionary<String, String> formData = new Dictionary<String, String>();
            formData.Add("grant_type", "password");
            formData.Add("username", username);
            formData.Add("password", password);
            formData.Add("client_id", clientId);
            if (clientSecret != null)
            {
                formData.Add("client_secret", clientSecret);
            }
            return AuthenticateViaOAuth2(formData);
        }

        public GedcomxApplicationState<T> AuthenticateViaOAuth2AuthCode(String authCode, String redirect, String clientId)
        {
            return AuthenticateViaOAuth2Password(authCode, authCode, clientId, null);
        }

        public GedcomxApplicationState<T> AuthenticateViaOAuth2AuthCode(String authCode, String redirect, String clientId, String clientSecret)
        {
            IDictionary<String, String> formData = new Dictionary<String, String>();
            formData.Add("grant_type", "authorization_code");
            formData.Add("code", authCode);
            formData.Add("redirect_uri", redirect);
            formData.Add("client_id", clientId);
            if (clientSecret != null)
            {
                formData.Add("client_secret", clientSecret);
            }
            return AuthenticateViaOAuth2(formData);
        }

        public GedcomxApplicationState<T> AuthenticateViaOAuth2ClientCredentials(String clientId, String clientSecret)
        {
            IDictionary<String, String> formData = new Dictionary<String, String>();
            formData.Add("grant_type", "client_credentials");
            formData.Add("client_id", clientId);
            if (clientSecret != null)
            {
                formData.Add("client_secret", clientSecret);
            }
            return AuthenticateViaOAuth2(formData);
        }

		public GedcomxApplicationState<T> UnauthenticatedAccess(string ipAddress, string clientId, string clientSecret = null)
		{
			IDictionary<String, String> formData = new Dictionary<String, String>();
			formData.Add("grant_type", "unauthenticated_session");
			formData.Add("client_id", clientId);
			formData.Add("ip_address", ipAddress);
			if (clientSecret != null)
			{
				formData.Add("client_secret", clientSecret);
			}
			return AuthenticateViaOAuth2(formData);
		}

        public GedcomxApplicationState<T> AuthenticateWithAccessToken(String accessToken)
        {
            this.CurrentAccessToken = accessToken;
            return this;
        }

        public GedcomxApplicationState<T> AuthenticateViaOAuth2(IDictionary<String, String> formData, params StateTransitionOption[] options)
        {
            Link tokenLink = this.GetLink(Rel.OAUTH2_TOKEN);
            if (tokenLink == null || tokenLink.Href == null)
            {
                throw new GedcomxApplicationException(String.Format("No OAuth2 token URI supplied for resource at {0}.", GetUri()));
            }

            IRestRequest request = CreateRequest()
                .Accept(MediaTypes.APPLICATION_JSON_TYPE)
                .ContentType(MediaTypes.APPLICATION_FORM_URLENCODED_TYPE)
                .SetEntity(formData)
                .Build(tokenLink.Href, Method.POST);
            IRestResponse response = Invoke(request, options);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
            {
                var accessToken = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                String access_token = null;

                if (accessToken.ContainsKey("access_token"))
                {
                    access_token = accessToken["access_token"] as string;
                }
                if (access_token == null && accessToken.ContainsKey("token"))
                {
                    //workaround to accommodate providers that were built on an older version of the oauth2 specification.
                    access_token = accessToken["token"] as string;
                }

                if (access_token == null)
                {
                    throw new GedcomxApplicationException("Illegal access token response: no access_token provided.", response);
                }

                return AuthenticateWithAccessToken(access_token);
            }
            else
            {
                throw new GedcomxApplicationException("Unable to obtain an access token.", response);
            }
        }

        public GedcomxApplicationState<T> ReadPage(String rel, params StateTransitionOption[] options)
        {
            Link link = GetLink(rel);
            if (link == null || link.Href == null)
            {
                return null;
            }

            IRestRequest request = CreateAuthenticatedRequest();
            Parameter accept = this.Request.GetHeaders().Get("Accept").FirstOrDefault();
            Parameter contentType = this.Request.GetHeaders().Get("Content-Type").FirstOrDefault();
            if (accept != null)
            {
                request.Accept(accept.Value as string);
            }
            if (contentType != null)
            {
                request.ContentType(contentType.Value as string);
            }
            request.Build(link.Href, Method.GET);
            return Clone(request, Invoke(request, options), this.Client);
        }

        public GedcomxApplicationState<T> ReadNextPage(params StateTransitionOption[] options)
        {
            return ReadPage(Rel.NEXT, options);
        }

        public GedcomxApplicationState<T> ReadPreviousPage(params StateTransitionOption[] options)
        {
            return ReadPage(Rel.PREVIOUS, options);
        }

        public GedcomxApplicationState<T> ReadFirstPage(params StateTransitionOption[] options)
        {
            return ReadPage(Rel.FIRST, options);
        }

        public GedcomxApplicationState<T> ReadLastPage(params StateTransitionOption[] options)
        {
            return ReadPage(Rel.LAST, options);
        }

        protected IRestRequest CreateAuthenticatedFeedRequest()
        {
            return CreateAuthenticatedRequest().Accept(MediaTypes.ATOM_GEDCOMX_JSON_MEDIA_TYPE);
        }

        public AgentState ReadContributor(params StateTransitionOption[] options)
        {
            var scope = MainDataElement;
            if (scope is Attributable)
            {
                return ReadContributor((Attributable)scope, options);
            }
            else
            {
                return null;
            }
        }

        public AgentState ReadContributor(Attributable attributable, params StateTransitionOption[] options)
        {
            Attribution attribution = attributable.Attribution;
            if (attribution == null)
            {
                return null;
            }

            return ReadContributor(attribution.Contributor, options);
        }

        public AgentState ReadContributor(ResourceReference contributor, params StateTransitionOption[] options)
        {
            if (contributor == null || contributor.Resource == null)
            {
                return null;
            }

            IRestRequest request = CreateAuthenticatedGedcomxRequest().Build(contributor.Resource, Method.GET);
            return this.stateFactory.NewAgentState(request, Invoke(request, options), this.Client, this.CurrentAccessToken);
        }

        public IList<Parameter> Headers
        {
            get
            {
                return Response.Headers;
            }
        }

        public string GetSelfUri()
        {
            String selfRel = SelfRel;
            Link link = null;
            if (selfRel != null)
            {
                link = this.GetLink(selfRel);
            }
            link = link == null ? this.GetLink(Rel.SELF) : link;
            String self = link == null ? null : link.Href == null ? null : link.Href;
            return self == null ? GetUri() : self;
        }

        public virtual String SelfRel
        {
            get
            {
                return null;
            }
        }
    }
}

