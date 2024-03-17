using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.Notes.DataTransferObjects
{
    public  class NotesDtos
    {
        public int NoteId { get; set; }
        public string NoteDescription { get; set; } = null!;
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
