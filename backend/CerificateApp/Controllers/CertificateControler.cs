using CerificateApp.Models.Request;
using DCCS.Services.Definition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Web.Api.Controllers
{
    [Route("certificate/")]
    public class CertificateControler : BaseController
    {
        private ICertificateServices certificateServices;
        public CertificateControler(ICertificateServices certificateServices)
        {
            this.certificateServices = certificateServices;
        }

        [HttpGet("")]
        public IActionResult GetAllCertificate()
        {
            var result = certificateServices.GetAll();
            return Convert(result);
        }

        [HttpGet("/{id}")]
        public IActionResult GetById(Guid Id)
        {
            var result = certificateServices.GetById(Id);
            return Convert(result);
        }

        [HttpPost("/")]
        public IActionResult AddCertificate([FromBody] CertificateModelRequest model)
        {
            var result = certificateServices.AddCertificate(model);
            return Convert(result);
        }

        [HttpPost("/edit/{id}")]
        public IActionResult EditCertificate([FromQuery] Guid Id,[FromBody] CertificateModelRequest model)
        {
            var result = certificateServices.EditCertificate(Id,model);
            return Convert(result);
        }

        //[HttpPost("/upload")]
        //public IActionResult UploadDocument()
        //{
        //    return Convert();
        //}

        [HttpDelete("/remove/{id}")]
        public IActionResult RemoveById(Guid Id)
        {
            var result = certificateServices.RemoveById(Id);
            return Convert(result);
        }

    }
}
