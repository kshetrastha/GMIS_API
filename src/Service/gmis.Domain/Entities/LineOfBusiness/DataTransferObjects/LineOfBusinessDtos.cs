using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.LineOfBusiness.DataTransferObjects
{
    public class LineOfBusinessDtos
    {
        public int LineOfBusinessID { get; set; }
        public string LineOfBusinessName { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    
    }
}
