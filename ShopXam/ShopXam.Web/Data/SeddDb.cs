using ShopXam.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data
{
    public class SeddDb
    {
        private readonly DataContext context;
        private Random random;

        public SeddDb(DataContext contexto)
        {
            this.context = contexto;
            this.random = new Random();
        }
        public void AddProducts(string name)
        {
            this.context.Prooducto.Add(new Product
            {
                Nombre = name,
                Precio = this.random.Next(100),
                Disponible = true,
                Stock = this.random.Next(100)
            });
        }
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            if (!this.context.Prooducto.Any())
            {
                this.AddProducts("Iphone 10 XS");
                this.AddProducts("Radio");
                this.AddProducts("Televisores");
                this.AddProducts("Motores");
                await this.context.SaveChangesAsync();
            }
        }
    }
}
