using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.LOF.Queries.GetAllListAsync.Model
{
    public class LineOfBusinessModel
    {
        public int LineOfBusinessID { get; set; }
        public string LineOfBusinessName { get; set; } = null!;
        //public bool IsActive { get; set; } = true;
        //public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
