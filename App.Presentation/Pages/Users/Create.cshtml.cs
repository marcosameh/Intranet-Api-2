using App.Application.Features.Roles.GetRoles;
using App.Application.Features.Users.CreateUser;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.UI.Pages.Users
{
    public class CreateModel : PageModelBase
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public CreateUserCommand CreateUserCommand { get; set; }
        public IEnumerable<GetRolesQuery> Roles { get; set; }

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> OnGet([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetRolesQuery());

            if (result.IsFailure)
            {
                return StatusCode(400, result.Error);
            }
            Roles = result.Value;

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var result = await _mediator.Send(CreateUserCommand);

            if (result.IsFailure)
            {
               return RedirectAndNotify("/users/create", result.Error,"Error",NotificationType.error);
            }

            return Redirect("/users/");
        }
    }
}