using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using GMIS.Controllers;
using System.IO;
using System;

namespace GMIS.Web.Host.Controllers
{
    public class HomeController : GMISControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;

        public HomeController(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin }
            );

            return Content("Sent notification: " + message);
        }

        public IActionResult download([FromQuery] string link)
        {
            try
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(link);
                var fileName = Path.GetFileName(link);

                var content = new System.IO.MemoryStream(data);
                var contentType = "APPLICATION/octet-stream";
                return File(content, contentType, fileName);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message + " <br> " +ex.InnerException + " <br> " + ex.StackTrace);
            }

        }

    }
}
