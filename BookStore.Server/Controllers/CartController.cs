using BookStore.Server.Models;
using BookStore.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<Cart> GetCart()
        {
            return Ok(_cartService.GetCart());
        }

        [HttpPost]
        public ActionResult AddToCart([FromBody] CartItem item)
        {
            _cartService.AddToCart(item);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public ActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return Ok();
        }

        [HttpDelete]
        public ActionResult ClearCart()
        {
            _cartService.ClearCart();
            return Ok();
        }
        [HttpPut("update-quantity")]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            var cart = _cartService.GetCart();
            var item = cart.Items.FirstOrDefault(i => i.BookId == request.BookId);
            if (item != null)
            {
                if (request.NewQuantity > 0)
                {
                    item.Quantity = request.NewQuantity;
                }
                else
                {
                    cart.Items.Remove(item);
                }
                return Ok(cart);
            }
            return NotFound();
        }
    }
}
