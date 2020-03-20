using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.DocumentRules
{
    public class DocumentRuleChain
    {
        Dictionary<IDocumentRule, IDocumentRule> documentRules = new Dictionary<IDocumentRule, IDocumentRule>();
        IDocumentRule lastInsertedRule = default(IDocumentRule);

        public void Chain(IDocumentRule documentRule)
        {
            documentRules.Add(lastInsertedRule, documentRule);
            lastInsertedRule = documentRule;
        }

        public IDocumentRule GetRoot() => documentRules[default(IDocumentRule)];
        public IDocumentRule GetLast() => lastInsertedRule;
    }
}
