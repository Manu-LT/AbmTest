using Abm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.DocumentRules
{
    public class DocumentService : IDocumentService
    {
        IDocumentRule documentRule;
        public DocumentService(IDocumentRule documentRule) => this.documentRule = documentRule;

        public DocumentConsistence ValidateConsistency(InputDocument document) => documentRule.Validate(document);
    }
}
