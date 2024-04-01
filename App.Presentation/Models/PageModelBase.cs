using App.Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Models
{
    [Authorize]
    public abstract class PageModelBase : PageModel
    {
        
        #region Error
        public IActionResult RedirectToNotFound()
        {
            return StatusCode(404);
        }
        #endregion
        public RedirectResult RedirectAndNotify(string url, string message, string title = null, NotificationType notificationType = NotificationType.success)
        {
            var notifyObject = new NotificationDetails
            {
                Message = message,
                Title = title,
                NotificationType = notificationType
            };

            TempData.Put("Notify", notifyObject);
            return Redirect(url);
        }

    }
}
