using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Services;
using TheStoreCore.Web.TheStoreCore.Services.Abstract;
using TheStoreCore.Web.TheStoreCore.Common;

namespace TheStoreCore.Web.TheStoreCore.Api
{
    public class CartController : Controller
    {
        private IProductService _productService;


        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("api/cart/getAllCartItems")]
        public IActionResult GetAllCartItems()
        {
            try
            {
                var cart = GetCart();
                return Ok(new { cart = cart, total = cart.ComputeTotalValue(), count = cart.CartCount() });
            }
            catch(Exception ex)
            {
                //Log here - TODO
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/cart/addProduct")]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                var product = _productService.GetProduct(productId);

                if (product == null)
                {
                    return NotFound();
                }

                //saving cart in session
                var cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);

                return Ok(new { cart = cart, total = cart.ComputeTotalValue(), count = cart.CartCount() });
            }
            catch (Exception ex)
            {
                //Log here - TODO
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/cart/removeProduct/{id}")]
        public IActionResult RemoveCart(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                //removing cart from session
                var cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
                return Ok(new { cart = cart, total = cart.ComputeTotalValue(), count = cart.CartCount() });
            }
            catch (Exception ex)
            {
                //Log here - TODO
                return BadRequest(ex.Message);
            }
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
