using Microsoft.AspNetCore.Mvc;
using WordLab.API.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController(IWordApplication wordApplication) : ControllerBase
    {
        private readonly IWordApplication _wordApplication = wordApplication;

        [HttpPost]
        public async Task<IActionResult> InsertionWord(string word)
        {
            var result = await _wordApplication.AddWord(word);
            if (result)
                return StatusCode(201);

            return StatusCode(400);
        }
    }
}