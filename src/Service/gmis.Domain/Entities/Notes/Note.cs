using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.Notes
{
    [Table("Note")]
    public partial class Note : EntityBase
    {
        public int NoteId { get; set; }

        public string NoteDescription { get; set; } = null!;

        //public DateTime CreatedDate { get; set; }

        //public string CreatedBy { get; set; } = null!;

        //public DateTime ModifiedDate { get; set; }

        //public string ModifiedBy { get; set; } = null!;

        //public virtual ICollection<SubGroup> SubGroups { get; set; } = new List<SubGroup>();
    }
}
