using System;
using System.Collections.Generic;
using System.Text;
using Abm.Model;

namespace Abm.Service.DocumentRules
{
    public class DocumentRuleForInvalidSiteSpecified : BaseDocumentRule, IDocumentRule
    {
        readonly string _dubDescription = "DUB";

        public override IDocumentRule Parent { get; set; } = new DocumentRuleForInvalidCommandSpecified();

        public DocumentConsistence Validate(InputDocument inputDocument)
        {
            if (!IsValidDocument(inputDocument))
                return DocumentConsistence.SiteIDDifferentThanDUB;
            else if (Parent != default(IDocumentRule))
                    return Parent.Validate(inputDocument);
            return DocumentConsistence.Unhandled;
        }

        public override bool IsValidDocument(InputDocument inputDocument) =>
            inputDocument != null &&
            inputDocument.DeclarationList != null &&
            inputDocument.DeclarationList.Declaration != null &&

            // should consider string case
            inputDocument.DeclarationList.Declaration.DeclarationHeader != null &&
            inputDocument.DeclarationList.Declaration.DeclarationHeader.SiteID == _dubDescription;
    }
}
