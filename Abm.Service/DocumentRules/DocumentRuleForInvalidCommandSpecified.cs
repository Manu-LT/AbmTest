using System;
using System.Collections.Generic;
using System.Text;
using Abm.Model;

namespace Abm.Service.DocumentRules
{
    public class DocumentRuleForInvalidCommandSpecified : BaseDocumentRule, IDocumentRule
    {
        readonly string _defaultDescription = "DEFAULT";

        public override IDocumentRule Parent { get; set; } = new DocumentRuleForDocumentStructuredCorrectly();

        public DocumentConsistence Validate(InputDocument inputDocument)
        {
            if (!IsValidDocument(inputDocument))
                return DocumentConsistence.DeclararationsCommandDifferentThanDEFAULT;
            else if (Parent != default(IDocumentRule))
                return Parent.Validate(inputDocument);
            return DocumentConsistence.Unhandled;
        }

        public override bool IsValidDocument(InputDocument inputDocument) => 
            inputDocument != null &&
            inputDocument.DeclarationList != null &&
            inputDocument.DeclarationList.Declaration != null &&

            // should consider string case
            inputDocument.DeclarationList.Declaration.Command == _defaultDescription;
    }
}
