namespace ShopXam.Web.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Prooducto.OrderBy(p => p.Nombre);
        }

        public Product GetProduct(int id)
        {
            return this.context.Prooducto.Find(id);
        }

        public void AddProduct(Product producto)
        {
            this.context.Prooducto.Add(producto);
        }

        public void UpdateProduct(Product producto)
        {
            this.context.Prooducto.Update(producto);
        }

        public void RemoveProduct(Product producto)
        {
            this.context.Prooducto.Remove(producto);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExist(int id)
        {
            return this.context.Prooducto.Any(p => p.Id == id);
        }
    }
}
