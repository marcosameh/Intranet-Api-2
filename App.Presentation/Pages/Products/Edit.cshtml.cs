using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Features.Products.EditProduct;
using App.Application.Features.Products.GetProduct;
using App.Domain.Entities;
using App.UI.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.Products
{
    public class EditModel : PageModelBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public EditProductCommand EditProductCommand { get; set; }
        
        public EditModel(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await mediator.Send(new GetProductQuery
            {
                Id = Id,
            });

            if (result.IsFailure)
            {
                return StatusCode(400, result.Error);
            }

            var product = mapper.Map<Product>(result.Value);
            EditProductCommand = mapper.Map<EditProductCommand>(product);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var response = await mediator.Send(EditProductCommand);

            if (response.IsFailure)
            {
                ModelState.AddModelError(string.Empty, response.Error);
                return Page();
            }

            return Redirect("/Products/");
        }

    }
}
