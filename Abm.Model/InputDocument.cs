using System;
using System.Xml.Serialization;

namespace Abm.Model
{
    [XmlRoot(ElementName = "InputDocument")]
    public class InputDocument
    {
        [XmlElement(ElementName = "DeclarationList")]
        public DeclarationList DeclarationList { get; set; }
    }
}
