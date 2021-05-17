using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataBaseApp.Model.Data
{
    public class ApplicationContext : DbContext//класс для создания и подключения к базе данных
    {
        #region ListBd

        public DbSet<PowerSupply> PowerSupplies { get; set; }//база данных для блоков питания
        public DbSet<PCB> PCBs { get; set; }//бд для плат
        public DbSet<ElectronicComponent> ElectronicComponents { get; set; }//бд для эк компонентов

        #endregion

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