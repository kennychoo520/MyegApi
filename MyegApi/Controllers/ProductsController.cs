using Microsoft.AspNetCore.Mvc;
using MyegApi.Model;

namespace MyegApi.Controllers
{
    [ApiController]

    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1000 },
        new Product { Id = 2, Name = "Phone", Price = 500 }
    };








        [HttpGet]               //GET DATA
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }




        [HttpGet("{id}")]       //GET DATA BY ID
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }





        [HttpPost]              //POST = ADD NEW ITEM
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }




        [HttpPut("{id}")]       //PUT = UPDATE DATA
        public ActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return NoContent();
        }




        [HttpDelete("{id}")]    //DELETE BY ID
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }


    }
}