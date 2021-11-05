using DCCS.Services.Definition;
using DCCS.Web.Entities;
using Emis.Web.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Services.Implementation
{
    public class Service : IService
    {
        public Service()
        {
        }

        public OkServiceResult Ok()
        {
            return new OkServiceResult();
        }

        public OkServiceResult<T> Ok<T>(T value)
        {
            return new OkServiceResult<T>(value);
        }

        public NotFoundServiceResult NotFound()
        {
            return new NotFoundServiceResult();
        }

        public ErrorServiceResult Error(String message, params String[] args)
        {
            message = String.Format(message, args);
            return new ErrorServiceResult(message);
        }

        public ErrorServiceResult Error(String message, bool prefix = true)
        {
            return new ErrorServiceResult(message, prefix);
        }


    }
}
