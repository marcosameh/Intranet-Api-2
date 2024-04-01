using App.Application.Features.Products.GetProducts;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.UI.Pages.Products
{
    public class IndexModel : PageModelBase
    {
        public IEnumerable<GetProductsQuery> Products { get; set; }

        public async Task<IActionResult> OnGet([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new GetProductsQuery());

            if (result.IsFailure)
            {
                return StatusCode(400, result.Error);
            }
            Products = result.Value;

            return Page();
        }
    }
}
