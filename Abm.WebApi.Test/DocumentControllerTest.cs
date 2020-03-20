using Abm.Model;
using Abm.Service.DocumentRules;
using Abm.WebApi.Controllers;
using Abm.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Abm.WebApi.Test
{
    public class DocumentControllerTest
    {
        readonly InputDocument nullInputDocument = null;
        [Fact]
        public void TestDocumentControllerNullPayload()
        {
            var controller = new DocumentController(
                new DocumentService(
                    new DocumentRuleForInvalidSiteSpecified()
                )
            );

            var result = controller.Post(nullInputDocument);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        InputDocument validInputDocument = new InputDocument {
            DeclarationList = new DeclarationList {
                Declaration = new Declaration {
                    Command = "DEFAULT",
                    Version = "5.13",
                    DeclarationHeader = new DeclarationHeader {
                        AccountCode = "G0779837",
                        CWProcedure = "IMPORT",
                        SiteID = "DUB",
                        Jurisdiction  = "IE",
                        DocumentRef = "71Q0019681",
                        DeclarationDestination = "CUSTOMSWAREIE"
                    }
                }
            }
        };
        [Fact]
        public void TestDocumentControllerValiPayload()
        {
            var controller = new DocumentController(
                new DocumentService(
                    new DocumentRuleForInvalidSiteSpecified()
                )
            );

            var result = controller.Post(validInputDocument);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var expected = new BusinessStatusCodeResponse { BusinessStatusCode = 0 };
            var resultObject = (BusinessStatusCodeResponse)okResult.Value;
            Assert.Equal(expected.BusinessStatusCode, resultObject.BusinessStatusCode);
        }

        InputDocument validInputDocumentDeclararationsCommandDifferentThanDEFAULT = new InputDocument
        {
            DeclarationList = new DeclarationList
            {
                Declaration = new Declaration
                {
                    Command = "NOTDEFAULT",
                    Version = "5.13",
                    DeclarationHeader = new DeclarationHeader
                    {
                        AccountCode = "G0779837",
                        CWProcedure = "IMPORT",
                        SiteID = "DUB",
                        Jurisdiction = "IE",
                        DocumentRef = "71Q0019681",
                        DeclarationDestination = "CUSTOMSWAREIE"
                    }
                }
            }
        };
        [Fact]
        public void TestDocumentControllerValiPayloadAndDeclararationsCommandDifferentThanDEFAULT()
        {
            var controller = new DocumentController(
                new DocumentService(
                    new DocumentRuleForInvalidSiteSpecified()
                )
            );

            var result = controller.Post(validInputDocumentDeclararationsCommandDifferentThanDEFAULT);

            // Assert
            var unprocessableEntityResult = Assert.IsType<UnprocessableEntityObjectResult>(result);
            var expected = new BusinessStatusCodeResponse { BusinessStatusCode = -1 };
            var resultObject = (BusinessStatusCodeResponse)unprocessableEntityResult.Value;
            Assert.Equal(expected.BusinessStatusCode, resultObject.BusinessStatusCode);
        }

        InputDocument validInputDocumentSiteIDDifferentThanDUB = new InputDocument
        {
            DeclarationList = new DeclarationList
            {
                Declaration = new Declaration
                {
                    Command = "DEFAULT",
                    Version = "5.13",
                    DeclarationHeader = new DeclarationHeader
                    {
                        AccountCode = "G0779837",
                        CWProcedure = "IMPORT",
                        SiteID = "LIM",
                        Jurisdiction = "IE",
                        DocumentRef = "71Q0019681",
                        DeclarationDestination = "CUSTOMSWAREIE"
                    }
                }
            }
        };
        [Fact]
        public void TestDocumentControllerValiPayloadAndSiteIDDifferentThanDUB()
        {
            var controller = new DocumentController(
                new DocumentService(
                    new DocumentRuleForInvalidSiteSpecified()
                )
            );

            var result = controller.Post(validInputDocumentSiteIDDifferentThanDUB);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var expected = new BusinessStatusCodeResponse { BusinessStatusCode = -2 };
            var resultObject = (BusinessStatusCodeResponse)badRequestResult.Value;
            Assert.Equal(expected.BusinessStatusCode, resultObject.BusinessStatusCode);
        }

    }
}
