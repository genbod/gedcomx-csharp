﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gx.Rs.Api.Util;
using Gedcomx.Model;
using Gx.Conclusion;
using Gx.Links;

namespace Gx.Rs.Api
{
    public class PlaceDescriptionState : GedcomxApplicationState<Gedcomx>
    {
        protected internal PlaceDescriptionState(IRestRequest request, IRestResponse response, IRestClient client, String accessToken, StateFactory stateFactory)
            : base(request, response, client, accessToken, stateFactory)
        {
        }

        public override String SelfRel
        {
            get
            {
                return Rel.DESCRIPTION;
            }
        }

        protected override GedcomxApplicationState<Gedcomx> Clone(IRestRequest request, IRestResponse response, IRestClient client)
        {
            return new PlaceDescriptionState(request, response, client, this.CurrentAccessToken, this.stateFactory);
        }

        protected override SupportsLinks MainDataElement
        {
            get
            {
                return PlaceDescription;
            }
        }

        public PlaceDescription PlaceDescription
        {
            get
            {
                return Entity == null ? null : Entity.Places == null ? null : Entity.Places.FirstOrDefault();
            }
        }

        public PlaceDescriptionsState ReadChildren(params StateTransitionOption[] options)
        {
            Link link = GetLink(Rel.CHILDREN);
            if (link == null || link.Href == null)
            {
                return null;
            }

            IRestRequest request = CreateAuthenticatedGedcomxRequest().Build(link.Href, Method.GET);
            return this.stateFactory.NewPlaceDescriptionsState(request, Invoke(request, options), this.Client, this.CurrentAccessToken);
        }
    }
}
