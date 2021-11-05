using CerificateApp.Entites.Models;
using CerificateApp.Models.Request;
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
    public class SupplierServices : Service, ISupplierServices
    {
        private DCCSContext context;
        public SupplierServices(DCCSContext context)
        {
            this.context = context;
        }

        public ServiceResult<SupplierResonseModel> AddSupplier(SupplierRequestModel model)
        {
            var supplier = new Supplier
            {
                SupplierIndex = (int)model.SupplierIndex,
                SupplierName = model.SupplierName,
                City = model.City
            };

            context.Supplier.Add(supplier);

            context.SaveChanges();

            return GetByIdSupplier(supplier.Id);

        }

        public ServiceResult<SupplierResonseModel> GetAll(SupplierRequestModel model)
        {
            var supplierQvery = context.Supplier.AsQueryable();

            if (model.SupplierName != null)
            {
                supplierQvery = supplierQvery.Where(s => s.SupplierName == model.SupplierName);
            }
            if (model.SupplierIndex.HasValue)
            {
                supplierQvery = supplierQvery.Where(s => s.SupplierIndex == model.SupplierIndex);
            }
            if(model.City != null)
            {
                supplierQvery = supplierQvery.Where(s => s.City == model.City);
            }

            var result = supplierQvery.Select(s => new SupplierResonseModel
            {
                Id = s.Id,
                SupplierName = s.SupplierName,
                City = s.City,
                SupplierIndex = s.SupplierIndex
            }).FirstOrDefault();

            return Ok(result);
        }

        public ServiceResult<SupplierResonseModel> GetByIdSupplier(int Id)
        {
            var supplier = context.Supplier.Where(s => s.Id == Id)
                .Select(s => new SupplierResonseModel {
                    Id = s.Id,
                    SupplierIndex = s.SupplierIndex,
                    SupplierName = s.SupplierName,
                    City = s.City
                }).FirstOrDefault();

            if (supplier == null)
                return Error("");

            return Ok(supplier);
        }
    }
}
