using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BlogCoreProject.Controllers
{
    [AllowAnonymous]
    public class CategorTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7010/api/Category");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> AddCategory(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7010/api/Category",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
    [AllowAnonymous]
    public class Class1
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
