using BullsAndCows.Data;
using BullsAndCows.WCF.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BullsAndCows.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsersService.svc or UsersService.svc.cs at the Solution Explorer and start debugging.
    public class UsersService : IUsersService
    {

        private IUsersData data;

        public UsersService()
        {
            this.data = new UsersData( BullsAndCowsDbContext.Create());
        }

        public IEnumerable<ApplicationUserDataModel> GetUsers()
        {
            var users = this.data.Users
                .All()
                .Select(ApplicationUserDataModel.FromUsers)
                .ToList();

            return users;
        }

    }
}
