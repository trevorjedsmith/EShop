using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.DAL.TheStoreCore.Entities.App;
using TheStoreCore.DAL.TheStoreCore.Repositories.Abstract;

namespace TheStoreCore.DAL.TheStoreCore.Api
{
    public class ProductController : Controller
    {
        private IEntityRepository<Product> _productRepository;

        public ProductController(IEntityRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("api/products/getProducts")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_productRepository.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Exception = ex });
            }

        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productRepository.FindById(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Exception = ex });
            }
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _productRepository.Create(product);
                _productRepository.Commit();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Exception = ex });
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult PutProduct(int id, [FromBody]Product product)
        {
            try
            {
                if (id == product.Id && ModelState.IsValid)
                {
                    _productRepository.Update(product);
                    _productRepository.Commit();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Exception = ex });
            }
        }
    }
}
