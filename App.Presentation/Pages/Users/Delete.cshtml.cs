using App.Application.Features.Users.DeleteUser;
using App.Application.Features.Users.EditUser;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.UI.Pages.Users
{
    public class DeleteModel : PageModelBase
    {
        
        [BindProperty(SupportsGet =true)]
        public string AspNetUserId { get; set; }
        
        //public DeleteUserCommand DeleteUserCommand { get; set; }
        public async Task<IActionResult> OnGet([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new DeleteUserCommand { AspNetUserId = AspNetUserId });

            if (result.IsFailure)
            {
                TempData["ErrorMessage"] = result.Error;
            }
            else
            {
                TempData["SuccessMessage"] = "User deleted successfully.";
            }

            return Redirect("/users/"); // Redirect to the Users index page after deletion
        }
       

    }
}
