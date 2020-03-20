using System;
using System.Collections.Generic;
using System.Text;
using Abm.Model;

namespace Abm.Service.DocumentRules
{
    public class DocumentRuleForDocumentStructuredCorrectly : BaseDocumentRule, IDocumentRule
    {
        public override IDocumentRule Parent { get; set; } = default(IDocumentRule);

        public DocumentConsistence Validate(InputDocument inputDocument)
        {
            if (IsValidDocument(inputDocument))
                return DocumentConsistence.DocumentCorrectlyStructured;
            return DocumentConsistence.Unhandled;
        }

        public override bool IsValidDocument(InputDocument inputDocument) => inputDocument != null && inputDocument.DeclarationList != null;
    }
}
