
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Web.DataModels
{
    public class NotificationDataModel
    {
        public NotificationDataModel()
        {
        }

        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return notification => new NotificationDataModel
                {
                    Id = notification.Id,
                    Message = notification.Message,
                    DateCreated = notification.DateCreated,
                    Type = notification.Type.ToString(),
                    State = notification.State.ToString(),
                    GameId = notification.GameId
                };
            }
        }
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }

        //public Game Game { get; set; }

    }
}