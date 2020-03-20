using System.Xml.Serialization;

namespace Abm.Model
{
    [XmlRoot(ElementName = "DeclarationHeader")]
    public class DeclarationHeader
    {
        [XmlElement(ElementName = "Jurisdiction")]
        public string Jurisdiction { get; set; }
        [XmlElement(ElementName = "CWProcedure")]
        public string CWProcedure { get; set; }
        [XmlElement(ElementName = "DeclarationDestination")]
        public string DeclarationDestination { get; set; }
        [XmlElement(ElementName = "DocumentRef")]
        public string DocumentRef { get; set; }
        [XmlElement(ElementName = "SiteID")]
        public string SiteID { get; set; }
        [XmlElement(ElementName = "AccountCode")]
        public string AccountCode { get; set; }
    }
}
