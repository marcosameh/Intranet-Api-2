using App.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSTemplate.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    [AllowAnonymous]
    public class ErrorModel : PageModelBase
    {
        public string ErrorStatusCode { get; set; }

        public ErrorModel()
        {
        }

        public void OnGet()
        {
            var context = PageContext.HttpContext;
            try
            {

                string responseBody = context.Response.StatusCode.ToString();

                ErrorStatusCode = responseBody;

            }
            catch
            {
                return;
            }

        }
    }
}
