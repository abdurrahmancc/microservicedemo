using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Common
{
    public abstract class EntityBase
    {
        public string CreatedBy { get; set; }
        public string CreatedDate {  get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; }
    }
}
