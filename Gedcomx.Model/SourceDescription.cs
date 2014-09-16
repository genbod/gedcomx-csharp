using Gedcomx.Model.Rt;
using Gedcomx.Model.Util;
using Newtonsoft.Json;
// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Source
{

    /// <remarks>
    ///  Represents a description of a source.
    /// </remarks>
    /// <summary>
    ///  Represents a description of a source.
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://gedcomx.org/v1/", TypeName = "SourceDescription")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "http://gedcomx.org/v1/", TypeName = "SourceDescription")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://gedcomx.org/v1/", ElementName = "sourceDescription")]
    public partial class SourceDescription : Gx.Links.HypermediaEnabledData
    {

        private string _about;
        private string _lang;
        private string _mediaType;
        private string _sortKey;
        private string _resourceType;
        private System.Collections.Generic.List<Gx.Source.SourceCitation> _citations;
        private Gx.Common.ResourceReference _mediator;
        private System.Collections.Generic.List<Gx.Source.SourceReference> _sources;
        private Gx.Common.ResourceReference _analysis;
        private Gx.Source.SourceReference _componentOf;
        private System.Collections.Generic.List<Gx.Common.TextValue> _titles;
        private Gx.Common.TextValue _titleLabel;
        private System.Collections.Generic.List<Gx.Common.Note> _notes;
        private Gx.Common.Attribution _attribution;
        private System.Collections.Generic.List<Gx.Common.TextValue> _descriptions;
        private System.Collections.Generic.List<Gx.Conclusion.Identifier> _identifiers;
        private DateTime? _created;
        private bool _createdSpecified;
        private DateTime? _modified;
        private bool _modifiedSpecified;
        private System.Collections.Generic.List<Gx.Source.Coverage> _coverage;
        private System.Collections.Generic.List<string> _rights;
        private System.Collections.Generic.List<Gx.Records.Field> _fields;
        private Gx.Common.ResourceReference _repository;
        private Gx.Common.ResourceReference _descriptorRef;
        /// <summary>
        ///  The URI (if applicable) of the actual source.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "about")]
        [System.Xml.Serialization.SoapAttributeAttribute(AttributeName = "about")]
        public string About
        {
            get
            {
                return this._about;
            }
            set
            {
                this._about = value;
            }
        }
        /// <summary>
        ///  The language of the genealogical data.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        [System.Xml.Serialization.SoapAttributeAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang
        {
            get
            {
                return this._lang;
            }
            set
            {
                this._lang = value;
            }
        }
        /// <summary>
        ///  Hint about the media (MIME) type of the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "mediaType")]
        [System.Xml.Serialization.SoapAttributeAttribute(AttributeName = "mediaType")]
        public string MediaType
        {
            get
            {
                return this._mediaType;
            }
            set
            {
                this._mediaType = value;
            }
        }
        /// <summary>
        ///  A sort key to be used in determining the position of this source relative to other sources in the same collection.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "sortKey")]
        [System.Xml.Serialization.SoapAttributeAttribute(AttributeName = "sortKey")]
        public string SortKey
        {
            get
            {
                return this._sortKey;
            }
            set
            {
                this._sortKey = value;
            }
        }
        /// <summary>
        ///  The type of the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "resourceType")]
        [System.Xml.Serialization.SoapAttributeAttribute(AttributeName = "resourceType")]
        public string ResourceType
        {
            get
            {
                return this._resourceType;
            }
            set
            {
                this._resourceType = value;
            }
        }

        /// <summary>
        ///  Convenience property for treating ResourceType as an enum. See Gx.Types.ResourceTypeQNameUtil for details on getter/setter functionality.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public Gx.Types.ResourceType KnownResourceType
        {
            get
            {
                return Gx.Types.ResourceTypeQNameUtil.ConvertFromKnownQName(this._resourceType);
            }
            set
            {
                this._resourceType = Gx.Types.ResourceTypeQNameUtil.ConvertToKnownQName(value);
            }
        }
        /// <summary>
        ///  The bibliographic citations for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "citation", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "citation")]
        public System.Collections.Generic.List<Gx.Source.SourceCitation> Citations
        {
            get
            {
                return this._citations;
            }
            set
            {
                this._citations = value;
            }
        }
        /// <summary>
        ///  A reference to the entity that mediates access to the described source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "mediator", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "mediator")]
        public Gx.Common.ResourceReference Mediator
        {
            get
            {
                return this._mediator;
            }
            set
            {
                this._mediator = value;
            }
        }
        /// <summary>
        ///  References to any sources to which this source is related (usually applicable to sources that are derived from or contained in another source).
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "source", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "source")]
        public System.Collections.Generic.List<Gx.Source.SourceReference> Sources
        {
            get
            {
                return this._sources;
            }
            set
            {
                this._sources = value;
            }
        }
        /// <summary>
        ///  A reference to the analysis document explaining the analysis that went into this description of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "analysis", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "analysis")]
        public Gx.Common.ResourceReference Analysis
        {
            get
            {
                return this._analysis;
            }
            set
            {
                this._analysis = value;
            }
        }
        /// <summary>
        ///  A reference to the source that contains this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "componentOf", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "componentOf")]
        public Gx.Source.SourceReference ComponentOf
        {
            get
            {
                return this._componentOf;
            }
            set
            {
                this._componentOf = value;
            }
        }
        /// <summary>
        ///  A list of titles for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "title", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "title")]
        public System.Collections.Generic.List<Gx.Common.TextValue> Titles
        {
            get
            {
                return this._titles;
            }
            set
            {
                this._titles = value;
            }
        }
        /// <summary>
        ///  A label for the title of this description.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "titleLabel", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "titleLabel")]
        public Gx.Common.TextValue TitleLabel
        {
            get
            {
                return this._titleLabel;
            }
            set
            {
                this._titleLabel = value;
            }
        }
        /// <summary>
        ///  Notes about a source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "note", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "note")]
        public System.Collections.Generic.List<Gx.Common.Note> Notes
        {
            get
            {
                return this._notes;
            }
            set
            {
                this._notes = value;
            }
        }
        /// <summary>
        ///  The attribution metadata for this source description.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "attribution", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "attribution")]
        public Gx.Common.Attribution Attribution
        {
            get
            {
                return this._attribution;
            }
            set
            {
                this._attribution = value;
            }
        }
        /// <summary>
        ///  Human-readable descriptions of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "description", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "description")]
        public System.Collections.Generic.List<Gx.Common.TextValue> Descriptions
        {
            get
            {
                return this._descriptions;
            }
            set
            {
                this._descriptions = value;
            }
        }
        /// <summary>
        ///  The list of identifiers for the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "identifier", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "identifier")]
        [JsonConverter(typeof(JsonIdentifiersConverter))]
        public System.Collections.Generic.List<Gx.Conclusion.Identifier> Identifiers
        {
            get
            {
                return this._identifiers;
            }
            set
            {
                this._identifiers = value;
            }
        }
        /// <summary>
        ///  The date the source was created.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "created", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "created")]
        public DateTime Created
        {
            get
            {
                return this._created.GetValueOrDefault();
            }
            set
            {
                this._created = value;
                this._createdSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Created" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.Xml.Serialization.SoapIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CreatedSpecified
        {
            get
            {
                return this._createdSpecified;
            }
            set
            {
                this._createdSpecified = value;
            }
        }

        /// <summary>
        ///  The date the source was last modified.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "modified", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "modified")]
        [JsonConverter(typeof(JsonUnixTimestampConverter))]
        public DateTime Modified
        {
            get
            {
                return this._modified.GetValueOrDefault();
            }
            set
            {
                this._modified = value;
                this._modifiedSpecified = true;
            }
        }

        /// <summary>
        ///  Property for the XML serializer indicating whether the "Modified" property should be included in the output.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        [System.Xml.Serialization.SoapIgnoreAttribute]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ModifiedSpecified
        {
            get
            {
                return this._modifiedSpecified;
            }
            set
            {
                this._modifiedSpecified = value;
            }
        }

        /// <summary>
        ///  Declarations of the coverage of the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "coverage", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "coverage")]
        public System.Collections.Generic.List<Gx.Source.Coverage> Coverage
        {
            get
            {
                return this._coverage;
            }
            set
            {
                this._coverage = value;
            }
        }
        /// <summary>
        ///  The rights for this source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "rights", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "rights")]
        public System.Collections.Generic.List<string> Rights
        {
            get
            {
                return this._rights;
            }
            set
            {
                this._rights = value;
            }
        }
        /// <summary>
        ///  The fields that are applicable to the resource being described.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "field", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "field")]
        public System.Collections.Generic.List<Gx.Records.Field> Fields
        {
            get
            {
                return this._fields;
            }
            set
            {
                this._fields = value;
            }
        }
        /// <summary>
        ///  Reference to an agent describing the repository in which the source is found.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "repository", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "repository")]
        public Gx.Common.ResourceReference Repository
        {
            get
            {
                return this._repository;
            }
            set
            {
                this._repository = value;
            }
        }
        /// <summary>
        ///  Reference to a descriptor of fields and type of data that can be expected to be extracted from the source.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "descriptor", Namespace = "http://gedcomx.org/v1/")]
        [System.Xml.Serialization.SoapElementAttribute(ElementName = "descriptor")]
        public Gx.Common.ResourceReference DescriptorRef
        {
            get
            {
                return this._descriptorRef;
            }
            set
            {
                this._descriptorRef = value;
            }
        }

        /**
         * Accept a visitor.
         *
         * @param visitor The visitor.
         */
        public void Accept(GedcomxModelVisitor visitor)
        {
            visitor.VisitSourceDescription(this);
        }
    }
}
