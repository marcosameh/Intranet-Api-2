using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Features.Products.GetProducts;
using App.Application.Features.Users.GetUser;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.Users
{
    public class IndexModel : PageModelBase
    {
        public IEnumerable<GetUsersQuery> Users { get; set; }

        public async Task<IActionResult> OnGet([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetUsersQuery());

            if (result.IsFailure)
            {
                return StatusCode(400, result.Error);
            }
            Users = result.Value;

            return Page();
        }
    }
}
