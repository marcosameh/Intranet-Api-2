using App.Application.Features.Products.DeleteProduct;
using App.Application.Features.Products.GetProduct;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.UI.Pages.Products
{
    public class DeleteModel : PageModelBase
    {

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public GetProductQuery GetProductQuery { get; set; }

        public DeleteProductCommand DeleteProductCommand { get; set; }

        public async Task<IActionResult> OnGet([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new DeleteProductCommand
            {
                ProductId = Id,
            });

            if (result.IsFailure)
            {
                return StatusCode(400, result.Error);
            }

            return Redirect("/Products");
        }


    }
}
