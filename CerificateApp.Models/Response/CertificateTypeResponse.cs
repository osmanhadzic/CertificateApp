using DCCS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Models.Response
{
    public class CertificateTypeResponseList : ListModel<CertificateTypeResponse>
    {

    }
    public class CertificateTypeResponse 
    {
        public int CertificateTypeId { get; set; }

        public string CerificateTypeName { get; set; }
    }
}
