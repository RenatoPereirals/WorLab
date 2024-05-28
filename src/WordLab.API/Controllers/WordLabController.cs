using Microsoft.AspNetCore.Mvc;
using WordLab.Application.Interfaces;
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
        public async Task<IActionResult> Post(string word)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(word))
                    return BadRequest("A palavra não pode ser nula ou vazia.");

                if (await _wordApplication.WordExists(word))
                    return Conflict($"A palavra {word} já existe.");

                var isInserted = await _wordApplication.AddWord(word);

                if (isInserted)
                    return CreatedAtAction(nameof(Post), new { word }, word);
                else
                    return BadRequest("Falha ao inserir a palavra.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir palavra");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  $"Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
