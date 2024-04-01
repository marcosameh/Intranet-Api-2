using App.Application.Features.Roles.GetRoles;
using App.Application.Features.Users.EditUser;
using App.Application.Features.Users.GetUser;
using App.Application.Results;
using App.Domain.Entities;
using App.UI.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.UI.Pages.Users
{
    public class EditModel : PageModelBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;   

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IEnumerable<GetRolesQuery> Roles { get; set; }
        [BindProperty]
        public EditUserCommand EditUserCommand { get; set; }
        public EditModel(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            var getRolesResult = await mediator.Send(new GetRolesQuery());                
            var getUserResult = await mediator.Send(new GetUserQuery
            {
                Id = Id,
            });

            if (getUserResult.IsFailure || getRolesResult.IsFailure)
            {
                return RedirectAndNotify("/users/", getUserResult.Error+getRolesResult.Error, "Error", NotificationType.error);
            }
            EditUserCommand=mapper.Map<EditUserCommand>(getUserResult.Value);
            Roles = getRolesResult.Value;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var result = await mediator.Send(EditUserCommand);

            if (result.IsFailure)
            {
                return RedirectAndNotify($"/users/edit?Id={Id}", result.Error, "Error", NotificationType.error);
            }

            return Redirect("/users/");
        }
    }
}
