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
    public  class User : BaseModel
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        [MaxLength(60)]
        public string Department { get; set; }

        [MaxLength(60)]
        public string UserId { get; set; }
        public string Plant { get; set; }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
