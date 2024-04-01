using App.Application.Features.Products.CreateProduct;
using App.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.UI.Pages.Products
{
    public class CreateModel : PageModelBase
    {
        [BindProperty]
        public CreateProductCommand CreateProductCommand { get; set; }

        public async Task<IActionResult> OnPost([FromServices] IMediator mediatR)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = await mediatR.Send(CreateProductCommand);
            if(result.IsFailure)
            {
                ModelState.AddModelError(string.Empty, result.Error);
                return Page();
            }

            return Redirect("/Products/");
        }
    }
}