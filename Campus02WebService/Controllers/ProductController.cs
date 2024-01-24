
using Campus02WebService.Models;
using Campus02WebService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campus02WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private Member Variable zeigt später auf LieferkostenCalculator
        private ILieferkostenCalculator _calculator;

        //konstruktor injection
        public ProductController(ILieferkostenCalculator calculator)
        {
            _calculator = calculator;
        }

        static List<Product> products = new List<Product>();

        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //return NotFound();
                //TODO Implement IActionResult
                Product product = products.Find(p => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception)
            {

                return BadRequest();
            }
          
            
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post(Product newProduct)
        {
           //Dependency LieferkostenCalculator
            /*ILieferkostenCalculator calculator = 
                new LieferkostenCalculator();*/

            newProduct.Lieferkosten =
                _calculator.
                CalculateLieferkosten(newProduct.Gewicht);

            products.Add(newProduct);
            return CreatedAtAction(nameof(Post), 
                new { id = newProduct.Id }, newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {//TODO Implement -IActionResult
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO Implement - IActionResult
        }
    }
}
