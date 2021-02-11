using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Asthma_Calc
{
    public class MedicineContext : DbContext
    {
        public DbSet<MedicineInfo> MedicineInfo { get; set; }
        public DbSet<EventInfo> EventInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myMSSQLConnectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            optionsBuilder.UseSqlServer(myMSSQLConnectionString);
        }
    }
}