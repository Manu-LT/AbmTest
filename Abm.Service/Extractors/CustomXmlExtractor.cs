using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Abm.Service.Extractors
{
    public class CustomXmlExtractor : BaseExtractor<CustomXmlExtractorParameters>, IExtractor<string[], CustomXmlExtractorParameters>
    {
        readonly string _codeName = "{code}";

        public string[] Extract(CustomXmlExtractorParameters parameters)
        {
            if (!AreParametersOk(parameters))
                return default(string[]);

            XmlDocument document = new XmlDocument();
            document.LoadXml(parameters.Content);

            var results = new List<string>();
            foreach (var code in parameters.Codes)
            {
                var nodeList = document.SelectNodes(parameters.xPath.Replace(_codeName, string.Format("\"{0}\"", code)));
                foreach (XmlNode node in nodeList)
                    results.Add(node.SelectSingleNode(parameters.Node).InnerText);
           }

            return results.ToArray();
        }

        protected override bool AreParametersOk(CustomXmlExtractorParameters parameters)
        {
            return 
                parameters != null && 
                !string.IsNullOrWhiteSpace(parameters.Content) &&
                !string.IsNullOrWhiteSpace(parameters.xPath) &&
                !string.IsNullOrWhiteSpace(parameters.Node) &&
                !string.IsNullOrWhiteSpace(parameters.xPath) &&
                parameters.Codes != null &&
                parameters.Codes.Length > 0;
        }
    }
}
