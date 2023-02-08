using deneme.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Server.Data.Context
{
    public class SmartContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BOSLT304;Database=BOSLT304;Trusted_Connection=true;Trust Server Certificate=true");
        }
        
        public DbSet<User> Users { get; set; }
    }
}

