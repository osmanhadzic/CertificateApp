using CerificateApp.Models.Request;
using CerificateApp.Services.Definition;
using DCCS.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerificateApp.Api.Controllers
{
    [Route("supplier/")]
    public class SupplierController : BaseController
    {
        private ISupplierServices supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }
        [HttpGet("")]
        public IActionResult GetAllSupplier([FromQuery] SupplierRequestModel model)
        {
            var result = supplierServices.GetAll(model);
            return Convert(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplier( [FromHeader]int Id)
        {
            var result = supplierServices.GetByIdSupplier(Id);
            return Convert(result);
        }

        [HttpPost("")]
        public IActionResult AddSupplier([FromBody] SupplierRequestModel model)
        {
            var result = supplierServices.AddSupplier(model);
            return Convert(result);
        }

    }
}
