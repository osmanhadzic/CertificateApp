using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Models.Request
{
    public class CertificateModelRequest
    {
        public int SupplierId { get; set; }

        public int CertificateTypeId { get; set; }

        public DateTime CertificateValidateFrom { get; set; }

        public DateTime CertificateValidateTo { get; set; }

        public IFormFile File { get; set; }
    }
}
