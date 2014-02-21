// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Search {

  /// <remarks>
  ///  The levels of confidence of a search result.
  /// </remarks>
  /// <summary>
  ///  The levels of confidence of a search result.
  /// </summary>
  public enum ResultConfidence {

    /// <summary>
    ///  Unspecified enum value.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="__NULL__")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="__NULL__")]
    NULL,

    /// <summary>
    ///   Result confidence level 1 (lowest).
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="1")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="1")]
    one,

    /// <summary>
    ///   Result confidence level 2.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="2")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="2")]
    two,

    /// <summary>
    ///   Result confidence level 3.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="3")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="3")]
    three,

    /// <summary>
    ///   Result confidence level 4.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="4")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="4")]
    four,

    /// <summary>
    ///   Result confidence level 5 (highest).
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="5")]
    [System.Xml.Serialization.SoapEnumAttribute(Name="5")]
    five
  }

}