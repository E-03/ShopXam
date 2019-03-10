using Microsoft.EntityFrameworkCore;
using ShopXam.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Prooducto { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
