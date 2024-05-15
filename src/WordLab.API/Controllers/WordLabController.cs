using Microsoft.AspNetCore.Mvc;
using WordLab.API.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertionWord(string word)
        {
            return StatusCode(201);
        }
    }
}