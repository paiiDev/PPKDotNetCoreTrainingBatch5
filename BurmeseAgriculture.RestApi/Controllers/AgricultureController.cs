using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace BurmeseAgriculture.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgricultureController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAgricultureInfo()
        {
            string filePath = "Data/BurmeseAgriculture.json";
            var jsonStr = System.IO.File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<List<AgricultureModel>>(jsonStr);


            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAgricultureById(string id)
        {
            string filePath = "Data/BurmeseAgriculture.json";
            var jsonStr = System.IO.File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<List<AgricultureModel>>(jsonStr);
            var item = result.FirstOrDefault(x => x.Id == id);

            return Ok(item);
        }




        public class AgricultureModel
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public string Author { get; set; }
            public string Content { get; set; }
        }

    }
}
