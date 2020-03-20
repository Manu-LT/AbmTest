using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abm.Service.Extractors
{
    // this is a custom extractor, can be wrapped the
    // https://github.com/indice-co/EDI.Net#deserialization-edi-to-pocos
    // project in a new implementation

    public class CustomEdifactExtractor : BaseExtractor<CustomEdifactExtractorParametersPosBySegment>, IExtractor<string[,], CustomEdifactExtractorParametersPosBySegment>
    {
        // as this is a file type convension this shouldn't change in time
        readonly char _EdifactDelimiter = '+';
        readonly string _EdifactEndOfLine = "\'";

        public string[,] Extract(CustomEdifactExtractorParametersPosBySegment parameters)
        {
            // i'm not sure if should be handled the multilne lines with EOL character
            // for real implementation should check if the Edifac specification considers
            // multilnes with the EOL delimiter

            // when implementing async methods should be included the locking

            if (!AreParametersOk(parameters))
                return default(string[,]);

            string[] lines = parameters.Content.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            var segment = $"{parameters.Segment}{_EdifactDelimiter}";
            var validLines = lines.Where(item => 
                item.StartsWith(segment) && item.EndsWith(_EdifactEndOfLine)
            )
            .Select(line => 
                line
                    .Trim()
                    .Substring(segment.Length, line.Trim().Length - segment.Length - 1)
                    .Split(_EdifactDelimiter)
            ).ToArray();

            var results = new string[validLines.Length, parameters.Positions.Length];
            for (var i = 0; i < validLines.Length; ++i)
            {
                for (var j = 0; j < validLines[i].Length; ++j)
                {
                    if (parameters.Positions.Contains(j + 2))
                        results[i, j] = validLines[i][j];
                }
            }

            return results;
        }

        protected override bool AreParametersOk(CustomEdifactExtractorParametersPosBySegment parameters)
        {
            // in real world applications,should check if the content is an edifact document type
            return 
                parameters != null && 
                !string.IsNullOrWhiteSpace(parameters.Segment) &&
                !string.IsNullOrWhiteSpace(parameters.Content) &&
                parameters.Positions != null &&
                parameters.Positions.Length > 0;
        }
    }
}
