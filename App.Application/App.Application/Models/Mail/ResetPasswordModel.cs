using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Mail
{
    public class ResetPasswordViewModel
    {
        public string CallbackUrl { get; set; } 
        public string Title { get; set; } 
    }
}
