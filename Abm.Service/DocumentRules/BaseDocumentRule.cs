using Abm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.DocumentRules
{
    public abstract class BaseDocumentRule
    {
        public abstract IDocumentRule Parent { get; set; }

        public abstract bool IsValidDocument(InputDocument inputDocument);

    }
}
