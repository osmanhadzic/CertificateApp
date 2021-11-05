using CerificateApp.Models.Response;
using CerificateApp.Services.Definition;
using DCCS.Services.Implementation;
using DCCS.Web.Entities;
using Emis.Web.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Services.Implementacion
{
    public class CertificateTypeService : Service, ICertificateTypeService
    {
        private DCCSContext context;
        public CertificateTypeService(DCCSContext context)
        {
            this.context = context;
        }

        public ServiceResult<CertificateTypeResponseList> GetAllCertificateType()
        {
            var certficateTypeList = context.CertificateType.Select(c => new CertificateTypeResponse
            {
                CertificateTypeId = c.Id,
                CerificateTypeName = c.CertificateTypeName
            }).ToList();

            if (certficateTypeList != null)
                return Error("CrtificateType don't existe");

            var result = new CertificateTypeResponseList
            {
                Items = certficateTypeList
            };

            return Ok(result);
        }

    }
}
