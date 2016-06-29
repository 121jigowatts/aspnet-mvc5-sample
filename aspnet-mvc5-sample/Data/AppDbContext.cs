using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDbContext")
        {

        }

        public DbSet<Item> Items { get; set; }

    }
}
