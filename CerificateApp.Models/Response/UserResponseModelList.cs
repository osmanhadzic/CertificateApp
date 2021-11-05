using Emis.Web.Models.Response.BaseModule.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Models.Response
{
    public class UserResponseModelList : PagedListModel<UserResponseModel>
    {
    }

    public class UserResponseModel
    {
        public string Name { get; set; }

        public string Firstname { get; set; }

        public string UserId { get; set; }

        public string Department { get; set; }

        public string Plant { get; set; }
    }
}
