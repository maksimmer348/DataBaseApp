using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace DataBaseApp.Model.DataBase
{
    public class DB: DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Users.db");

    }
}