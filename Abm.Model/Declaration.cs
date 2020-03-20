using System.Xml.Serialization;

namespace Abm.Model
{
    [XmlRoot(ElementName = "Declaration")]
    public class Declaration
    {
        [XmlElement(ElementName = "DeclarationHeader")]
        public DeclarationHeader DeclarationHeader { get; set; }
        [XmlAttribute(AttributeName = "Command")]
        public string Command { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
    }
}

