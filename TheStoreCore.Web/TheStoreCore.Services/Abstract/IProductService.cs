using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.App;

namespace TheStoreCore.Web.TheStoreCore.Services.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        Product CreateProduct(Product product);

        void UpdateProduct(Product product);
    }
}
