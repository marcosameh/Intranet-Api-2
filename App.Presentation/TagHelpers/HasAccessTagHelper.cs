using App.Domain.LoggedInUser;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace App.UI.TagHelpers
{
    [HtmlTargetElement("has-access")]
    public class HasAccessTagHelper : TagHelper
    {
        private readonly ILoggedInIdentityUserService _loggedInIdentityUserService;

        [HtmlAttributeName("comma-separated-roles")]
        public string CommaSeparatedRoles { get; set; }

        public HasAccessTagHelper(ILoggedInIdentityUserService loggedInIdentityUserService)
        {
            _loggedInIdentityUserService = loggedInIdentityUserService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var commaSeparatedRoles = CommaSeparatedRoles.Split(",");
            if(commaSeparatedRoles.Any() == false)
            {
                output.SuppressOutput();
                await base.ProcessAsync(context, output);

                return;
            }

            var roleResult = await _loggedInIdentityUserService.GetUserRoles();
            
            if (roleResult is null)
            {
                output.SuppressOutput();
                await base.ProcessAsync(context, output);

                return;
            }

            var roles = roleResult.Select(x => x.ToLower().Trim());
            var accessRolesList = commaSeparatedRoles.Select(x => x.ToLower().Trim());

            if (roles.Intersect(accessRolesList).Any() == false)
            {
                output.SuppressOutput();
                await base.ProcessAsync(context, output);

                return;
            }
            
            await base.ProcessAsync(context, output);
        }
    }


}

