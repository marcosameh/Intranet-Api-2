using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.LoggedInUser
{
    public interface ILoggedInIdentityUserService
    {
        public string  UserName { get; }
        public Task<IdentityUser> GetLoggedInUser();
        public Task<IEnumerable<string>> GetUserRoles();
    }
}
