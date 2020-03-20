using System;
using System.Collections.Generic;
using System.Text;

namespace Abm.Service.Extractors
{
    public class CustomEdifactExtractorParametersPosBySegment
    {
        // In real world applications, this property can be the path where to retrieve the file
        public string Content { get; set; }
        public string Segment { get; set; }
        public int[] Positions { get; set; }
    }
}
