using App.Application.Contracts;
using App.Application.Results;
using App.Domain;
using App.Domain.Entities;
using App.Domain.LoggedInUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Identity.UserServices
{
    public class CurrentUserUserService : ICurrentUserService
    {
        private readonly ILoggedInIdentityUserService _loggedInIdentityUserService;
        private readonly ApplicationContext _context;

        public CurrentUserUserService(ILoggedInIdentityUserService loggedInIdentityUserService, ApplicationContext context)
        {
            _loggedInIdentityUserService = loggedInIdentityUserService;
            _context = context;
        }

        #region Get User
        public async Task<Result<User>> GetCurrentLoggedInUser()
        {
            var identityUserResult = await _loggedInIdentityUserService.GetLoggedInUser();

            if (identityUserResult is null)
            {
                return Result.Fail<User>("Couldn't find user");
            }

            var dbUser = _context.Users.FirstOrDefault(x => x.AspNetUserId == identityUserResult.Id);

            if (dbUser == null)
            {
                return Result.Fail<User>("Couldn't find user");
            }

            return Result.Ok(dbUser);

        }

        public async Task<Result<IEnumerable<string>>> GetCurrentUserRoles()
        {
          
            var rolesResult = await _loggedInIdentityUserService.GetUserRoles();
            if (rolesResult.Any() == false)
            {
                return Result.Fail<IEnumerable<string>>("Current user has no roles");
            }

            return Result.Ok(rolesResult);

        }

        #endregion
    }
}
