using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Context
{
   public class RoarContext:DbContext
    {
        public RoarContext(DbContextOptions<RoarContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
