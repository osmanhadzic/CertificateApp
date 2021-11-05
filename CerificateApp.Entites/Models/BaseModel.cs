using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Entities.Models
{
    public abstract class BaseModel
    {
        public bool IsDeleted { get; set; }
    }
}
