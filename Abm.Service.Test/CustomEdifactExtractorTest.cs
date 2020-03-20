using Abm.Service.Extractors;
using System;
using Xunit;

namespace Abm.Service.Test
{
    public class CustomEdifactExtractorTest
    {
        readonly string _textContent = @"
UNA:+.? '
UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'
UNH+EDIFACT+CUSDEC:D:96B:UN:145050'
BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'
LOC+17+IT044100'
LOC+18+SOL'
LOC+35+SE'
LOC+36+TZ'
LOC+116+SE003033'
DTM+9:20090527:102'
DTM+268:20090626:102'
DTM+182:20090527:102'
";

        IExtractor<string[,], CustomEdifactExtractorParametersPosBySegment> extractor;

        public CustomEdifactExtractorTest()
        {
            this.extractor = new CustomEdifactExtractor(); // extractor;
        }


        [Fact]
        public void ResultIsEmptyWithNullParameters()
        {
            var result = extractor.Extract(null);
            Assert.Equal(default(string[,]), result);
        }

        [Fact]
        public void ResultIsEmptyWithNoParameters()
        {
            var result = extractor.Extract(new CustomEdifactExtractorParametersPosBySegment { });
            Assert.Equal(default(string[,]), result);
        }

        [Fact]
        public void ResultIsNotEmptyWithParameters()
        {
            var result = extractor.Extract(
                new CustomEdifactExtractorParametersPosBySegment
                    { Segment = "LOC", Content = _textContent,
                Positions = new int[] { 2, 3 }
                }
            );
            Assert.NotEqual(default(string[,]), result);
        }

        [Fact]
        public void ResultIsNotEmptyWithValidParameters()
        {
            var result = extractor.Extract(
                new CustomEdifactExtractorParametersPosBySegment
                {
                    Segment = "LOC",
                    Content = _textContent,
                    Positions = new int[] { 2, 3 }
                }
            );

            Assert.Equal(new string[,] { 
                { "17", "IT044100" }, 
                { "18", "SOL" },
                { "35", "SE" },
                { "36", "TZ" },
                { "116", "SE003033" }
            }, result);
        }

        // Bonus Test
        [Fact]
        public void ResultIsNotEmptyWithValidParametersOnly1Value()
        {
            var result = extractor.Extract(
                new CustomEdifactExtractorParametersPosBySegment
                {
                    Segment = "LOC",
                    Content = _textContent,
                    Positions = new int[] { 2 }
                }
            );

            Assert.Equal(new string[,] {
                { "17" },
                { "18" },
                { "35" },
                { "36" },
                { "116" }
            }, result);
        }

        // more testy are needed for a real world implementation

    }
}
