using CerificateApp.Models.Request;
using Emis.Web.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Services.Definition
{
    public interface ISupplierServices 
    {
        //SupplierRequestModel
        ServiceResult<SupplierResonseModel> GetAll(SupplierRequestModel model);

        ServiceResult<SupplierResonseModel> GetByIdSupplier(int Id);

        ServiceResult<SupplierResonseModel> AddSupplier(SupplierRequestModel model);
    }
}
