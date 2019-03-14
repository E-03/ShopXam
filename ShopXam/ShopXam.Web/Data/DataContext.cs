using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopXam.Web.Data.Entities;
using ShopXam.Web.Data.Entities.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data
{
    public class DataContext : IdentityDbContext<User> //Para que el context trabaje con el usuario que accede al sistema, no con todos
    {
        public DbSet<Product> Prooducto { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
