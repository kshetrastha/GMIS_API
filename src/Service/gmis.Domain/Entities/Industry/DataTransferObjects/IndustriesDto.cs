using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.Industry.DataTransferObjects
{
    public class IndustriesDto
    {
        public int IndustryId { get; set; }
        public string? NaicsCode { get; set; } = null;
        public string? NaicsTitle { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
