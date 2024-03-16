using gmis.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace gmis.Infrastructure.Auditing
{
    public class AuditTrail
    {
        public EntityEntry Entry { get; }
        public Guid UserId { get; set; }
        public string? TableName { get; set; }
        public Guid KeyValues { get; set; }
        public Dictionary<string, object?> OldValues { get; } = new();
        public Dictionary<string, object?> NewValues { get; } = new();
        public List<PropertyEntry> TemporaryProperties { get; } = new();
        public string TrailType { get; set; }
        public List<string> ChangedColumns { get; } = new();
        public bool HasTemporaryProperties => TemporaryProperties.Count > 0;

        public Trail ToAuditTrail() =>
            new()
            {
                UserId = UserId,
                Type = TrailType,
                TableName = TableName,
                DateTime = DateTime.UtcNow,
                PrimaryKey = KeyValues,
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
            };
    }
}
