using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Models.Request
{
    public class SupplierResonseModel
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }

        public int SupplierIndex { get; set; }

        public string City { get; set; }
    }
}
