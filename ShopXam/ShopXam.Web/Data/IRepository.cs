namespace ShopXam.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        Product GetProduct(int id);

        void AddProduct(Product producto);

        IEnumerable<Product> GetProducts();

        bool ProductExist(int id);

        void RemoveProduct(Product producto);

        Task<bool> SaveAllAsync();

        void UpdateProduct(Product producto);
    }
}