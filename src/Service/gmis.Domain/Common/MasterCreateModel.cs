using System.ComponentModel.DataAnnotations;

namespace gmis.Domain.Common
{
    public class MasterCreateModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
