using Abm.Service.Extractors;
using System;
using Xunit;

namespace Abm.Service.Test
{
    public class CustomXmlExtractorTest
    {
        readonly string _textContent = @"
<InputDocument>
    <DeclarationList>
        <Declaration Command=""DEFAULT"" Version=""5.13"">
            <DeclarationHeader>
                <Jurisdiction>IE</Jurisdiction>
                <CWProcedure>IMPORT</CWProcedure>
                <DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>
                <DocumentRef>71Q0019681</DocumentRef>
                <SiteID>DUB</SiteID>
                <AccountCode>G0779837</AccountCode>
                <Reference RefCode=""MWB"">
                    <RefText>586133622</RefText>
                </Reference>
                <Reference RefCode=""KEY"">
                    <RefText>DUB16049</RefText>
                </Reference>
                <Reference RefCode=""CAR"">
                    <RefText>71Q0019681</RefText>
                </Reference>
                <Reference RefCode=""COM"">
                    <RefText>71Q0019681</RefText>
                </Reference>
                <Reference RefCode=""SRC"">
                    <RefText>ECUS</RefText>
                </Reference>
                <Reference RefCode=""TRV"">
                    <RefText>1</RefText>
                </Reference>
                <Reference RefCode=""CAS"">
                    <RefText>586133622</RefText>
                </Reference>
                <Reference RefCode=""HWB"">
                    <RefText>586133622</RefText>
                </Reference>
                <Reference RefCode=""UCR"">
                    <RefText>586133622</RefText>
                </Reference>
                <Country CodeType=""NUM"" CountryType=""Destination"">IE</Country>
                <Country CodeType=""NUM"" CountryType=""Dispatch"">CN</Country>
            </DeclarationHeader>
        </Declaration>    
    </DeclarationList>
</InputDocument>";

        IExtractor<string[], CustomXmlExtractorParameters> extractor;

        public CustomXmlExtractorTest()
        {
            this.extractor = new CustomXmlExtractor(); // extractor;
        }


        [Fact]
        public void ResultIsEmptyWithNullParameters()
        {
            var result = extractor.Extract(null);
            Assert.Equal(default(string[]), result);
        }

        [Fact]
        public void ResultIsEmptyWithNoParameters()
        {
            var result = extractor.Extract(new CustomXmlExtractorParameters { });
            Assert.Equal(default(string[]), result);
        }

        [Fact]
        public void ResultIsNotEmptyWithValidParameters()
        {
            var result = extractor.Extract(
                new CustomXmlExtractorParameters
                {
                    xPath = "/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference[contains(@RefCode, {code})]",
                    Node = "RefText",
                    Codes = new string[] { "MWB", "TRV", "CAR" },
                    Content = _textContent
                }
            );
            

            // order is important for the test, should be necessary to order the lists before asserting
            Assert.Equal(
                new string[] { "586133622", "1", "71Q0019681" }, 
                result
            );
        }

        // more testy are needed for a real world implementation

    }
}
