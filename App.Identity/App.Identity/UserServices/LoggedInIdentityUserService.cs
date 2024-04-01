using App.Domain.LoggedInUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Identity.UserServices
{
    internal class LoggedInIdentityUserService : ILoggedInIdentityUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoggedInIdentityUserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserName
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.Identity.Name;
            }
        }
  
        public async Task<IdentityUser> GetLoggedInUser()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == false)
            {
                return default;
            }

            var currentIdentityUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            if (currentIdentityUser == null)
            {
                return default;
            }

            return currentIdentityUser;
        }

        public async Task<IEnumerable<string>> GetUserRoles()
        {
            var identityUserResult = await GetLoggedInUser();
            if (identityUserResult is null)
            {
                return Enumerable.Empty<string>();
            }

            var roles = await _userManager.GetRolesAsync(identityUserResult);

            if (roles.Any())
            {
                return roles.AsEnumerable();
            }
            return  Enumerable.Empty<string>();
        }

       
    }
}
