using Emis.Web.Models.Response.BaseModule.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Models.Response
{
    public class CertificateResponseModelListModel : PagedListModel<CertificateResponseModelItem>
    {
 
    }

    public class CertificateResponseModelItem
    {
        public Guid Id { get; set; }

        public string SupSupplier { get; set; }

        public string CertificateType { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}
