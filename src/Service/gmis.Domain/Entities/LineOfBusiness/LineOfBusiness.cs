using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Domain.Entities.LineOfBusiness
{
    [Table("LineOfBusiness")]
    public partial class LineOfBusiness : EntityBase
    {
        public int LineOfBusinessID { get; set; }
        public string LineOfBusinessName { get; set; } = null!;
    }

}
