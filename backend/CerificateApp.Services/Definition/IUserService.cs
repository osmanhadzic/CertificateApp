using CerificateApp.Models.Request;
using CerificateApp.Models.Response;
using Emis.Web.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Services.Definition
{
    public interface IUserService 
    {
        ServiceResult<UserResponseModelList> GetAllUsers(UserRequestModel model);

        ServiceResult<UserResponseModel> GetUser(int Id);

    }
}
