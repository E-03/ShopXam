namespace ShopXam.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helper;

    public class SeddDb
    {
        private readonly DataContext context;
        private Random random;
        public IUserHelper UserHelper { get; }

        public SeddDb(DataContext contexto,IUserHelper userHelper)
        {
            this.context = contexto;
            UserHelper = userHelper;
            this.random = new Random();
        }
        
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.UserHelper.GetUserByEmailAsync("efabal@mardom.com");
            if (user == null)
            {
                user = new User
                {
                    Nombre = "Eber",
                    Apellido = "Fabal",
                    Email = "efabal@mardom.com",
                    UserName = "efabal@mardom.com",
                    PhoneNumber = "23423423422"
                };

                var result = await this.UserHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se creo el Usuario en Seeder");
                }
            }
            if (!this.context.Prooducto.Any())
            {
                this.AddProducts("Iphone 10 XS",user);
                this.AddProducts("Radio", user);
                this.AddProducts("Televisores", user);
                this.AddProducts("Motores", user);
                await this.context.SaveChangesAsync();
            }
        }
        public void AddProducts(string name, User user)
        {

            this.context.Prooducto.Add(new Product
            {
                Nombre = name,
                Precio = this.random.Next(100),
                Disponible = true,
                Stock = this.random.Next(100),
                user = user
            });
        }
    }
}
