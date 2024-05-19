using Microsoft.AspNetCore.Mvc;
using WordLab.Application.Interfaces;

namespace WordLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordLabController(IWordApplication wordApplication,
                                   ILogger<WordLabController> logger) : ControllerBase
    {
        private readonly IWordApplication _wordApplication = wordApplication ?? throw new ArgumentNullException(nameof(wordApplication));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string word)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    return BadRequest("A palavra não pode ser nula ou vazia.");
                }

                var isInserted = await _wordApplication.AddWord(word);

                if (isInserted)
                {
                    return CreatedAtAction(nameof(Post), new { word });
                }
                else
                {
                    return BadRequest("Falha ao inserir a palavra.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao inserir palavra.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
