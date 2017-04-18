using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.DAL.TheStoreCore.Entities.App;
using TheStoreCore.DAL.TheStoreCore.Repositories.Abstract;
using TheStoreCore.DAL.TheStoreCore.Services.Abstract;
using TheStoreCore.DAL.TheStoreCore.ViewModels;

namespace TheStoreCore.DAL.TheStoreCore.Api
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public int PageSize = 4;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("api/products/getProducts")]
        [HttpGet]
        public IActionResult GetProducts(int page = 1)
        {
            try
            {
                var pagedProducts = _productService.GetProducts()
                                                   .OrderBy(p => p.Id)
                                                   .Skip((page - 1) * PageSize)
                                                   .Take(PageSize);

                var productListVM = new ProductListViewModel
                {
                    Products = pagedProducts,
                    PagingInfo = new Models.PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _productService.GetProducts().Count()
                    }
                };
                return Ok(new {data = productListVM });
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
                var product = _productService.GetProduct(id);
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

                var newProduct = _productService.CreateProduct(product);
                return Ok(newProduct);
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
                    _productService.UpdateProduct(product);
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
