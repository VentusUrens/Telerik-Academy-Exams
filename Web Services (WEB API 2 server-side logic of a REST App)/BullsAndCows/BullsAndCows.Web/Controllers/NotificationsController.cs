namespace BullsAndCows.Web.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Web.DataModels;


    public class NotificationsController : BaseApiController
    {
        public NotificationsController(IBullsAndCowsData data)
            : base(data)
        {
        }


        // GET /api/notifications/
        [HttpGet]
        [Authorize]
        public IHttpActionResult All()
        {
            return this.All(0);
        }


        // GET /api/notifications?page=P
        [HttpGet]
        [Authorize]
        public IHttpActionResult All(int page)
        {
            var currentId = this.User.Identity.GetUserId();
            var currentUserName = this.data.Users.All().FirstOrDefault(user => user.Id == currentId).UserName;

            var notifications = this.GetAllOrdered()
                .Where(notification => notification.State.ToString() == "Unread")
                .Skip(10 * page)
                .Take(10)
                .Select(NotificationDataModel.FromNotification).ToList();


            foreach (var notification in notifications)
            {
                notification.State = NotificationState.Read.ToString();
            }
            return Ok(notifications);
        }


        // GET /api/notification/next
        [HttpGet]
        [Authorize]
        [Route("api/notifications/next")]
        public IHttpActionResult Next()
        {
            var nextNotification = this.data.Notifications.All().FirstOrDefault(notification => notification.State == NotificationState.Unread);

            if (nextNotification == null)
            {
                return NotFound();
            }

            nextNotification.State = NotificationState.Read;
            return Ok(nextNotification);
        }

        private IQueryable<Notification> GetAllOrdered()
        {
            return this.data.Notifications.All()
                .OrderBy(notification => notification.DateCreated);
        }
    }
}
