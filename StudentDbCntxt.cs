using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppg_databaser
{
    internal class StudentDbCntxt:DbContext
    {
        public DbSet<Student> Students {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .Build()
                                            .GetSection("ConnectionStrings")["StudentDb"]);
        }
    }
}
