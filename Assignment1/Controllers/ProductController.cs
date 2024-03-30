using Assignment1.Models;
using Assignment1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = productRepository.GetAll();

            return Ok(products);
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Product product = productRepository.GetById(id);

            if (product == null)
            {
                return BadRequest("No Product found with this ID");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);

                productRepository.Save();

                // return Ok("Product Added Successfully");

                //  return Created($"http://localhost:49076/api/Product/{product.Id}" , product);

                return CreatedAtAction("GetById", new { id = product.Id }, product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Edit(int id , Product editedProduct)
        {
           Product productFromDB = productRepository.GetById(id);

            if(productFromDB == null || editedProduct.Id != id)
            {
                return BadRequest("No Product found with this ID or IDs are not matched");
            }

            productRepository.Edit(editedProduct);

            productRepository.Save();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            Product productFromDB = productRepository.GetById(id);

            if (productFromDB == null)
            {
                return BadRequest("No Product found with this ID");
            }

            try
            {
                productRepository.Remove(id);

                productRepository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
      
        }
    }
}
