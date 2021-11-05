using CerificateApp.Models.Request;
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
    public class UserServices : Service, IUserService
    {
        private DCCSContext context;
        public UserServices(DCCSContext context)
        {
            this.context = context;
        }

        public ServiceResult<UserResponseModelList> GetAllUsers(UserRequestModel model)
        {
            var quvery = context.User.AsQueryable();

            if(model.Name != null)
            {
                quvery = quvery.Where(u => u.Name == model.Name);
            }
            if(model.Firstname != null)
            {
                quvery = quvery.Where(u => u.Name == model.Firstname);
            }
            if (model.UserId != null)
            {
                quvery = quvery.Where(u => u.UserId == model.UserId);
            }
            if (model.Department != null)
            {
                quvery = quvery.Where(u => u.Department == model.Department);
            }
            if (model.Plant != null)
            {
                quvery = quvery.Where(u => u.Plant == model.Plant);
            }

            var users = quvery.Select(u => new UserResponseModel { 
                Name = u.Name,
                UserId = u.UserId,
                Plant = u.Plant,
                Department = u.Department
            }).ToList();

            if (users != null)
                return Error("");

            var count = users.Count();

            var result = new UserResponseModelList
            {
                Items = users,
                All = false,
                Page = 1,
                Total = 10
            };

            return Ok(result);
        }

        public ServiceResult<UserResponseModel> GetUser(int Id)
        {
            var user = context.User.Where(u => u.Id == Id).Select(u => new UserResponseModel
            {
                Name = u.Name,
                UserId = u.UserId,
                Plant = u.Plant,
                Department = u.Department
            }).FirstOrDefault();

            if (user != null)
                return Error("");

            return Ok(user);
        }
    }
}
