using CerificateApp.Entites.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Entities.Models
{
    public class Certificate : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual CertificateType CertificateType { get; set; }

        public DateTime  DateFrom { get; set; }

        public DateTime DateTo { get; set; }
        
        public ICollection<User> Participant { get; set; }

        [JsonIgnore]
        public virtual UploadFile UploadFile { get; set; }

        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
