using CerificateApp.Models.Request;
using DCCS.Web.Models.Response;
using Emis.Web.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Services.Definition
{
    public interface ICertificateServices
    {
        ServiceResult<CertificateResponseModelListModel> GetAll();

        ServiceResult<CertificateResponseModelItem> GetById(Guid Id);

        ServiceResult<CertificateResponseModelItem> AddCertificate(CertificateModelRequest model);
        ServiceResult<CertificateResponseModelItem> EditCertificate(Guid Id,CertificateModelRequest model);
        ServiceResult<Nothing> RemoveById(Guid Id);

        //ServiceResult<>
    }
}
