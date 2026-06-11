using System.Windows;
using DemoExam5.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam5.Classes
{
    public class DbConnection : DbContext
    {
        public DbSet<Direction> Directions { get; set; }
        public DbSet<DocumentAcc> DocumentAccS { get; set; }

        public DbConnection()
        {
            try
            {
                Database.EnsureCreated();
                Directions.Load();
                DocumentAccS.Load();



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            } 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3307;uid=root;pwd=;database=DemoExam5",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }

    }
}
