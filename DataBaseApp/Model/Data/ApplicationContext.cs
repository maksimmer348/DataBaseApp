using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataBaseApp.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PCB> PCBs { get; set; }
        public DbSet<ElectronicComponent> ElectronicComponents { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated(); //если бд нен существует он ее создаст
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DataBaseApp;Trusted_Connection=True;");//В этот метод передается объект DbContextOptionsBuilder,
        //// который позволяет создать параметры подключения. Для их создания вызывается метод UseSqlServer, в который передается строка подключения.

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"SupplyDB");
    }
}