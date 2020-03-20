using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abm.Model;
using Abm.Service.DocumentRules;
using Abm.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Abm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        IDocumentService documentService;
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] InputDocument document)
        {
            if (document == null)
                return new BadRequestObjectResult(new SerializableError());

            var documentState = documentService.ValidateConsistency(document);
            switch (documentState)
            {
                case DocumentConsistence.DocumentCorrectlyStructured:
                    return Ok(new BusinessStatusCodeResponse { BusinessStatusCode  = 0 });
                case DocumentConsistence.DeclararationsCommandDifferentThanDEFAULT:
                    return UnprocessableEntity(new BusinessStatusCodeResponse { BusinessStatusCode = -1 });
                case DocumentConsistence.SiteIDDifferentThanDUB:
                    return BadRequest(new BusinessStatusCodeResponse { BusinessStatusCode = -2 });
                default: // unst to be clear
                    throw new ArgumentException();
            }
        }
    }
}
