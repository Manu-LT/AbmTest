using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.Extractors
{
    public interface IExtractor<TResult, TParameters>
    {
        TResult Extract(TParameters parameters);
    }
}
