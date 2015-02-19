// <auto-generated>
// 
//
// Generated by <a href="http://enunciate.codehaus.org">Enunciate</a>.
// </auto-generated>
using System;

namespace Gx.Types {

  /// <remarks>
  ///  Enumeration of standard event types.
  /// </remarks>
  /// <summary>
  ///  Enumeration of standard event types.
  /// </summary>
  public enum EventType {

    /// <summary>
    ///  Unspecified enum value.
    /// </summary>
    [System.Xml.Serialization.XmlEnumAttribute(Name="__NULL__")]
    NULL,

    /// <summary>
    ///   An adoption event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Adoption")]
    Adoption,

    /// <summary>
    ///   An adult christening event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/AdultChristening")]
    AdultChristening,

    /// <summary>
    ///   An annulment event of a marriage.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Annulment")]
    Annulment,

    /// <summary>
    ///   A baptism event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Baptism")]
    Baptism,

    /// <summary>
    ///   A bar mitzvah event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/BarMitzvah")]
    BarMitzvah,

    /// <summary>
    ///   A bat mitzvah event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/BatMitzvah")]
    BatMitzvah,

    /// <summary>
    ///   A birth event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Birth")]
    Birth,

    /// <summary>
    ///   A an official blessing event, such as at the hands of a clergy member or at another religious rite.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Blessing")]
    Blessing,

    /// <summary>
    ///   A burial event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Burial")]
    Burial,

    /// <summary>
    ///   A census event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Census")]
    Census,

    /// <summary>
    ///   A christening event *at birth*. Note: use `AdultChristening` for a christening event as an adult.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Christening")]
    Christening,

    /// <summary>
    ///   A circumcision event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Circumcision")]
    Circumcision,

    /// <summary>
    ///   A confirmation event (or other rite of initiation) in a church or religion.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Confirmation")]
    Confirmation,

    /// <summary>
    ///   A cremation event after death.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Cremation")]
    Cremation,

    /// <summary>
    ///   A death event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Death")]
    Death,

    /// <summary>
    ///   A divorce event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Divorce")]
    Divorce,

    /// <summary>
    ///   A divorce filing event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/DivorceFiling")]
    DivorceFiling,

    /// <summary>
    ///   A education or an educational achievement event (e.g. diploma, graduation, scholarship, etc.).
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Education")]
    Education,

    /// <summary>
    ///   An engagement to be married event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Engagement")]
    Engagement,

    /// <summary>
    ///   An emigration event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Emigration")]
    Emigration,

    /// <summary>
    ///   An excommunication event from a church.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Excommunication")]
    Excommunication,

    /// <summary>
    ///   A first communion event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/FirstCommunion")]
    FirstCommunion,

    /// <summary>
    ///   A funeral event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Funeral")]
    Funeral,

    /// <summary>
    ///   An immigration event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Immigration")]
    Immigration,

    /// <summary>
    ///   A land transaction event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/LandTransaction")]
    LandTransaction,

    /// <summary>
    ///   A marriage event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Marriage")]
    Marriage,

    /// <summary>
    ///   A military award event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/MilitaryAward")]
    MilitaryAward,

    /// <summary>
    ///   A military discharge event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/MilitaryDischarge")]
    MilitaryDischarge,

    /// <summary>
    ///   A mission event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Mission")]
    Mission,

    /// <summary>
    ///   An event of a move (i.e. change of residence) from a location.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/MoveFrom")]
    MoveFrom,

    /// <summary>
    ///   An event of a move (i.e. change of residence) to a location.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/MoveTo")]
    MoveTo,

    /// <summary>
    ///   A naturalization event (i.e. acquisition of citizenship and nationality).
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Naturalization")]
    Naturalization,

    /// <summary>
    ///   An ordination event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Ordination")]
    Ordination,

    /// <summary>
    ///   A retirement event.
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/Retirement")]
    Retirement,

    /// <summary>
    ///  (no documentation provided)
    /// </summary>
    [System.Xml.Serialization.XmlEnum("http://gedcomx.org/OTHER")]
    OTHER
  }

  /// <remarks>
  /// Utility class for converting to/from the QNames associated with EventType.
  /// </remarks>
  /// <summary>
  /// Utility class for converting to/from the QNames associated with EventType.
  /// </summary>
  public static class EventTypeQNameUtil {

    /// <summary>
    /// Get the known EventType for a given QName. If the QName isn't a known QName, EventType.OTHER will be returned.
    /// </summary>
    public static EventType ConvertFromKnownQName(string qname) {
      if (qname != null) {
      }
      return EventType.OTHER;
    }

    /// <summary>
    /// Convert the known EventType to a QName. If EventType.OTHER, an ArgumentException will be thrown.
    /// </summary>
    public static string ConvertToKnownQName(EventType known) {
      switch (known) {
        case EventType.Adoption:
          return "http://gedcomx.org/Adoption";
        case EventType.AdultChristening:
          return "http://gedcomx.org/AdultChristening";
        case EventType.Annulment:
          return "http://gedcomx.org/Annulment";
        case EventType.Baptism:
          return "http://gedcomx.org/Baptism";
        case EventType.BarMitzvah:
          return "http://gedcomx.org/BarMitzvah";
        case EventType.BatMitzvah:
          return "http://gedcomx.org/BatMitzvah";
        case EventType.Birth:
          return "http://gedcomx.org/Birth";
        case EventType.Blessing:
          return "http://gedcomx.org/Blessing";
        case EventType.Burial:
          return "http://gedcomx.org/Burial";
        case EventType.Census:
          return "http://gedcomx.org/Census";
        case EventType.Christening:
          return "http://gedcomx.org/Christening";
        case EventType.Circumcision:
          return "http://gedcomx.org/Circumcision";
        case EventType.Confirmation:
          return "http://gedcomx.org/Confirmation";
        case EventType.Cremation:
          return "http://gedcomx.org/Cremation";
        case EventType.Death:
          return "http://gedcomx.org/Death";
        case EventType.Divorce:
          return "http://gedcomx.org/Divorce";
        case EventType.DivorceFiling:
          return "http://gedcomx.org/DivorceFiling";
        case EventType.Education:
          return "http://gedcomx.org/Education";
        case EventType.Engagement:
          return "http://gedcomx.org/Engagement";
        case EventType.Emigration:
          return "http://gedcomx.org/Emigration";
        case EventType.Excommunication:
          return "http://gedcomx.org/Excommunication";
        case EventType.FirstCommunion:
          return "http://gedcomx.org/FirstCommunion";
        case EventType.Funeral:
          return "http://gedcomx.org/Funeral";
        case EventType.Immigration:
          return "http://gedcomx.org/Immigration";
        case EventType.LandTransaction:
          return "http://gedcomx.org/LandTransaction";
        case EventType.Marriage:
          return "http://gedcomx.org/Marriage";
        case EventType.MilitaryAward:
          return "http://gedcomx.org/MilitaryAward";
        case EventType.MilitaryDischarge:
          return "http://gedcomx.org/MilitaryDischarge";
        case EventType.Mission:
          return "http://gedcomx.org/Mission";
        case EventType.MoveFrom:
          return "http://gedcomx.org/MoveFrom";
        case EventType.MoveTo:
          return "http://gedcomx.org/MoveTo";
        case EventType.Naturalization:
          return "http://gedcomx.org/Naturalization";
        case EventType.Ordination:
          return "http://gedcomx.org/Ordination";
        case EventType.Retirement:
          return "http://gedcomx.org/Retirement";
        default:
          throw new System.ArgumentException("No known QName for: " + known, "known");
      }
    }
  }
}
