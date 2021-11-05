using CerificateApp.Services.Definition;
using DCCS.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerificateApp.Api.Controllers
{
    [Route("certificate-type/")]
    public class CerrtificateTypeController : BaseController
    {
        private ICertificateTypeService certificateTypeService;
        public CerrtificateTypeController(ICertificateTypeService certificateTypeService)
        {
            this.certificateTypeService = certificateTypeService;
        }

        [HttpGet("")]
        public IActionResult GetAllCerrtificateType()
        {
            var result = certificateTypeService.GetAllCertificateType();
            return Convert(result);
        }


    }
}
