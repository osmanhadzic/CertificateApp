using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Models.Request
{
    public class UserRequestModel
    {
        public string Name { get; set; }

        public string Firstname { get; set; }

        public string UserId { get; set; }

        public string Department { get; set; }

        public string Plant { get; set; }
    }
}
