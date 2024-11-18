using Microsoft.AspNetCore.Mvc;
using WordLab.Application.Interfaces;
using WordLab.Application.Models;
using WordLab.Domain.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController(IWordApplication wordApplication,
                                   ILogger<WordLabController> logger) : ControllerBase
    {
        private readonly IWordApplication _wordApplication = wordApplication ?? throw new ArgumentNullException(nameof(wordApplication));
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] WordModel model)
        {
            try
            {
                var word = model.Word;
                if (string.IsNullOrWhiteSpace(word))
                    return BadRequest("The word cannot be null or contain empty spaces.");

                if (await _wordApplication.WordExists(word))
                    return Conflict($"The word {word} already exists.");

                var isInserted = await _wordApplication.AddWord(word);

                if (isInserted)
                    return CreatedAtAction(nameof(Post), new { word }, word);
                else
                    return BadRequest("Error inserting the word");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting the word.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "An internal error occurred. Please try again later.");
            }
        }
    }
}
