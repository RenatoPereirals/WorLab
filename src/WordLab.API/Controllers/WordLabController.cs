using Microsoft.AspNetCore.Mvc;
using WordLab.API.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController(IWordApplication wordApplication) : ControllerBase
    {
        private readonly IWordApplication _wordApplication = wordApplication ?? throw new ArgumentNullException(nameof(wordApplication));

        [HttpPost]
        public async Task<IActionResult> InsertionWord([FromBody] string word)
        {
            try
            {
                if (string.IsNullOrEmpty(word))
                {
                    return BadRequest("A palavra não pode ser nula ou vazia.");
                }

                var isInserted = await _wordApplication.AddWord(word);

                if (isInserted)
                {
                    return CreatedAtAction(nameof(InsertionWord), new { word }, null);
                }
                else
                {
                    return BadRequest("Falha ao inserir a palavra.");
                }
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, $"Ocorreu um erro interno. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
    }
}
