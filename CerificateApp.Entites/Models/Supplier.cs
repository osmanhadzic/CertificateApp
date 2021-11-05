using DCCS.Web.Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerificateApp.Entites.Models
{
    public class Supplier : BaseModel
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string SupplierName { get; set; }

        public int SupplierIndex { get; set; }

        public string  City { get; set; }

    }
}
