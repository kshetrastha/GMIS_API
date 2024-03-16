using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using gmis.Application.Common.AppSession;
using gmis.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Reflection;
using gmis.Infrastructure.Auditing;
using gmis.Infrastructure.Converter;
using gmis.Domain.Entities.LineOfBusiness;

namespace gmis.Infrastructure.Persistence.Context
{
    public partial class RepositoryContext : IdentityDbContext<Application.Models.Users.ApplicationUser, IdentityRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICurrentUser _currentUser;
        public DbSet<Trail> AuditTrails => Set<Trail>();
        //public DbSet<UserDetail> UserDetails => Set<UserDetail>();
        public DbSet<LineOfBusiness> lineOfBusinesses => Set<LineOfBusiness>();


  
        public RepositoryContext(DbContextOptions<RepositoryContext> options, IHttpContextAccessor httpContextAccessor, ICurrentUser currentUser) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
        }
        public RepositoryContext(string connectionString) :
                    base(GetOptions(connectionString))
        { }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var user = _currentUser.GetUserId();
            var auditEntries = HandleAuditingBeforeSaveChanges(user);
            int result = await base.SaveChangesAsync(cancellationToken);
            await HandleAuditingAfterSaveChangesAsync(auditEntries, cancellationToken);
            return result;
        }
        private List<AuditTrail> HandleAuditingBeforeSaveChanges(Guid userId)
        {
            userId = Guid.NewGuid();   
            foreach (var entry in ChangeTracker.Entries<EntityBase>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "PAI\\jshapiro";
                        break;
                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = "PAI\\jshapiro";
                        break;
                }
            }
            ChangeTracker.DetectChanges();

            var trailEntries = new List<AuditTrail>();
            foreach (var entry in ChangeTracker.Entries<EntityBase>().Where(e => e.State is EntityState.Added or EntityState.Modified).ToList())
            {
                var trailEntry = new AuditTrail()
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = Guid.NewGuid(),
                };
                trailEntries.Add(trailEntry);
                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        trailEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        trailEntry.KeyValues = Guid.NewGuid(); //new Guid(property.CurrentValue.ToString());
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            trailEntry.TrailType = EntityState.Added.ToString();
                            trailEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                trailEntry.ChangedColumns.Add(propertyName);
                                trailEntry.TrailType = EntityState.Modified.ToString();
                                trailEntry.OldValues[propertyName] = property.OriginalValue;
                                trailEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            foreach (var auditEntry in trailEntries.Where(e => !e.HasTemporaryProperties))
            {
                AuditTrails.Add(auditEntry.ToAuditTrail());
            }
            return trailEntries.Where(e => e.HasTemporaryProperties).ToList();
        }

        private Task HandleAuditingAfterSaveChangesAsync(List<AuditTrail> trailEntries, CancellationToken cancellationToken = new())
        {
            if (trailEntries == null || trailEntries.Count == 0)
            {
                return Task.CompletedTask;
            }

            foreach (var entry in trailEntries)
            {
                foreach (var prop in entry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        entry.KeyValues = Guid.NewGuid();
                    }
                    else
                    {
                        entry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                AuditTrails.Add(entry.ToAuditTrail());
            }

            return SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    if (memberInfo == null) continue;
                    var defaultValue = Attribute.GetCustomAttribute(memberInfo, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                    if (defaultValue == null) continue;
                    property.SetDefaultValue(defaultValue.Value);
                }
            }
            OnModelCreatingPartial(builder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<Converter.DateOnlyConverter, DateOnlyComparer>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<Converter.TimeOnlyConverter, TimeOnlyComparer>();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }
    }
}
