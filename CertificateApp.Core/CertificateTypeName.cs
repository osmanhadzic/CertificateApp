using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Core
{
    public enum CertificateTypeName
    {
        EmailCertificate = 0,
        EMVCertificate = 1,
        CodeSigningCertificate = 2,
        QualifiedCertificate = 3,
        RootCertificate = 4
    }
}
