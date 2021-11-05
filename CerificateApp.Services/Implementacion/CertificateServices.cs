using CerificateApp.Entites.Models;
using CerificateApp.Models.Request;
using DCCS.Services.Implementation;
using DCCS.Web.Core;
using DCCS.Web.Entities;
using DCCS.Web.Entities.Models;
using DCCS.Web.Models.Response;
using Emis.Web.Services.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Services.Definition
{
    public class CertificateServices : Service, ICertificateServices
    {
        private DCCSContext context;
        public CertificateServices(DCCSContext context)
        {
            this.context = context;
        }

        public ServiceResult<CertificateResponseModelItem> AddCertificate(CertificateModelRequest model)
        {
            var supplayer = context.Supplier.Where(s => s.Id == model.SupplierId).FirstOrDefault();
            if (supplayer == null)
                return Error("");

            var certificateType = context.CertificateType.Where(ct => ct.Id == model.CertificateTypeId).FirstOrDefault();

            if (certificateType == null)
                return Error("");

            UploadFile document = null;

            if (model.File != null)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    model.File.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }


                document = new UploadFile
                {
                    DocumentName = model.File.FileName,
                    File = fileBytes,
                };

            }

            Certificate certificate = new Certificate
            {
                CertificateType = certificateType,
                Supplier = supplayer,
                UploadFile = document,
                DateFrom = model.CertificateValidateFrom,
                DateTo = model.CertificateValidateTo
            };
            context.Certificates.Add(certificate);

            context.SaveChanges();

            return GetById(certificate.Id);
        }

        public ServiceResult<CertificateResponseModelItem> EditCertificate(Guid Id, CertificateModelRequest model)
        {
            var certificate = context.Certificates
                .Include(x => x.Supplier)
                .Include(x => x.CertificateType)
                .Include(x => x.Participant)
                .Include(x => x.UploadFile)
                .Where(x => x.Id == Id).FirstOrDefault();

            if (certificate != null)
                return Error("");

            if(model.SupplierId != 0)
            {
                var supplier = context.Supplier.Where(s => s.Id == model.SupplierId).FirstOrDefault();
                if(supplier != null)
                {
                    certificate.Supplier.Id = model.SupplierId;
                }
                else
                {
                    return Error("");
                }
            }

            if (model.CertificateTypeId != 0)
            {
                var certificateType = context.CertificateType.Where(s => s.Id == model.CertificateTypeId).FirstOrDefault();
                if (certificateType != null)
                {
                    certificate.Supplier.Id = model.CertificateTypeId;
                }
                else
                {
                    return Error("");
                }
            }

            if (model.File != null)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    model.File.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }


                var document = new UploadFile
                {
                    DocumentName = model.File.FileName,
                    File = fileBytes,
                };

                certificate.UploadFile.DocumentId = document.DocumentId;

                context.UploadFile.Add(document);
            }

            certificate.DateFrom = model.CertificateValidateFrom;
            certificate.DateTo = model.CertificateValidateTo;

            context.Certificates.Add(certificate);

            context.SaveChanges();

            return GetById(certificate.Id);
        }

        public ServiceResult<CertificateResponseModelListModel> GetAll()
        {
            var certifaction = context.Certificates
                .Include(c => c.Supplier)
                .Select(c => new CertificateResponseModelItem { 
             Id = c.Id,
             SupSupplier = c.Supplier.SupplierName,
             DateFrom = c.DateFrom,
             DateTo = c.DateTo
            }).ToList();
            
            if(certifaction == null)
            {
                return Error("Certificate don't existe.");
            }

            var total = certifaction.Count();
            var result = new CertificateResponseModelListModel
            {
                Items = certifaction,
                Total = total,
                Page = 1,
                All  = false
            };

            return Ok(result);
        }

        public ServiceResult<CertificateResponseModelItem> GetById(Guid Id)
        {
            var certifaction = context.Certificates
                .Include(c => c.Supplier)
                .Select(c => new CertificateResponseModelItem
                {
                    Id = c.Id,
                    SupSupplier = c.Supplier.SupplierName,
                    DateFrom = c.DateFrom,
                    DateTo = c.DateTo
                })
                .Where(c => c.Id == Id)
                .FirstOrDefault();

            if (certifaction != null)
                return Ok(certifaction);

            return Error("Certificate don't existe.");
        }

        public ServiceResult<Nothing> RemoveById(Guid Id)
        {
            var cerificate = context.Certificates.Where(c => c.Id == Id).FirstOrDefault();

            if(cerificate != null)
            {
                context.Certificates.Remove(cerificate);
                return Ok();
            }

            return Error("Certificate don't existe.");
        }
    }
}
