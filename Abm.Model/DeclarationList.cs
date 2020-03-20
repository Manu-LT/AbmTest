using System.Xml.Serialization;

namespace Abm.Model
{
    [XmlRoot(ElementName = "DeclarationList")]
    public class DeclarationList
    {
        [XmlElement(ElementName = "Declaration")]
        public Declaration Declaration { get; set; }
    }
}
