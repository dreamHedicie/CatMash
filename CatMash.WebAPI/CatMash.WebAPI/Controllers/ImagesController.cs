using System.Linq;
using System.Threading.Tasks;
using CatMash.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatMash.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ILatelierClient _client;

        public ImagesController(ILatelierClient client)
        {
            _client = client;
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<string>> Get(string id)
        {
            var images = await _client.GetImages();
            var image = images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                return Ok(image.Url);
            }
            return NotFound();
        }

    }
}
