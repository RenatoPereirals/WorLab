using Microsoft.AspNetCore.Mvc;
using WordLab.API.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController(IWordApplication wordApplication) : ControllerBase
    {
        private readonly IWordApplication _wordApplication = wordApplication ?? throw new ArgumentException(null, nameof(wordApplication));

        [HttpPost]
        public async Task<IActionResult> InsertionWord(string word)
        {
            try
            {
                if (string.IsNullOrEmpty(word))
                {
                    return BadRequest("A palavra não pode ser nula ou vazia.");
                }

                var isInserted = await _wordApplication.AddWord(word);

                if (isInserted)
                    return StatusCode(201);

                return StatusCode(400);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}