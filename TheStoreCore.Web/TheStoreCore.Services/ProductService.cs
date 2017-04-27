using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.App;
using TheStoreCore.Web.TheStoreCore.Repositories.Abstract;
using TheStoreCore.Web.TheStoreCore.Services.Abstract;

namespace TheStoreCore.Web.TheStoreCore.Services
{
    public class ProductService : IProductService
    {
        private IEntityRepository<Product> _productRepository;

        public ProductService(IEntityRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            _productRepository.Create(product);
            _productRepository.Commit();
            return product;
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.FindById(id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.FindAll();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Commit();
        }
    }
}
