using App.Domain.Common;
using App.Domain.LoggedInUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public partial class ApplicationContext : DbContext
    {

        private readonly ILoggedInIdentityUserService _loggedInUserService;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, ILoggedInIdentityUserService loggedInUserService)
           : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserName;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserName;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
