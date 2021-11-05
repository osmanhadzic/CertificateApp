using Emis.Web.Api.Common.Result;
using Emis.Web.Services.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCCS.Web.Api.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Convert<T>(ServiceResult<T> result)
        {
            var visitor = new ActionResultVisitor<T>();
            return result.Visit(visitor);
        }
    }
}
