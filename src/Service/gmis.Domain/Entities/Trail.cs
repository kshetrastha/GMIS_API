using System.ComponentModel.DataAnnotations;

namespace gmis.Domain.Entities
{
    public class Trail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Type { get; set; }
        public string? TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public string? AffectedColumns { get; set; }
        public Guid PrimaryKey { get; set; }
    }
}
