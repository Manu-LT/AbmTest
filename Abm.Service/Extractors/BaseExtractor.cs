using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.Extractors
{
    public abstract class BaseExtractor<TParameters>
    {
        protected abstract bool AreParametersOk(TParameters parameters);
    }
}
