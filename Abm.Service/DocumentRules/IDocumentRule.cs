using Abm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.DocumentRules
{
    public interface IDocumentRule
    {
        DocumentConsistence Validate(InputDocument inputDocument);
    }
}
