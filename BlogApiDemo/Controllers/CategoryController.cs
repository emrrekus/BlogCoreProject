using BlogApiDemo.DAL.ApiContext;
using BlogApiDemo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var c = new Context();

            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var c = new Context();
            var values = c.Categories.Find(id);

            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var c = new Context();
            var values = c.Categories.Find(id);
            if (values != null)
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

