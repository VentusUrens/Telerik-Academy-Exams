using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WCF.DataModels
{
    public class ApplicationUserDataModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public static Expression<Func<ApplicationUser, ApplicationUserDataModel>> FromUsers
        {
            get
            {
                return user => new ApplicationUserDataModel
                {
                    UserId = HttpContext.Current.User.Identity.Name,
                    UserName = user.Name
                };
            }
        }
    }
}