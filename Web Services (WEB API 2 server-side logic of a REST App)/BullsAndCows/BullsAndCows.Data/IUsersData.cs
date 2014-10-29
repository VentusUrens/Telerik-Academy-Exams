namespace BullsAndCows.Data
{
    using System;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;
    
    public interface IUsersData
    {
        int SaveChanges();
        IRepository<ApplicationUser> Users { get; }
    }
}
