using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.Industry
{
    [Table("Industry")]
    public partial class Industry :EntityBase
    {
        public int IndustryId { get; set; }

        public string NaicsCode { get; set; } = null!;

        public string? NaicsTitle { get; set; }

       

        //public virtual ICollection<SubGroup> SubGroups { get; set; } = new List<SubGroup>();

    }
}
