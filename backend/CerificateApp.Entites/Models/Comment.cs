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
    public class Comment : BaseModel
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime DataComment { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
