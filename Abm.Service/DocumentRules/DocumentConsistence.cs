using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.DocumentRules
{
    public enum DocumentConsistence
    {
        Unhandled,
        SiteIDDifferentThanDUB,
        DeclararationsCommandDifferentThanDEFAULT,
        DocumentCorrectlyStructured
    }
}
