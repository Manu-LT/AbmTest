using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.Extractors
{
    public class CustomXmlExtractorParameters
    {
        // In real world applications, this property can be the path where to retrieve the file
        public string Content { get; set; }
        public string Node { get; set; }
        public string xPath { get; set; }
        public string[] Codes { get; set; }
        public string CodeName { get; set; }
    }
}
