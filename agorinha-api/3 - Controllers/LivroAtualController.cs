using System;
using agorinha_api.Entities.DTO;
using agorinha_api.Entities.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace agorinha_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroAtualController : Controller
    {
        private ILivroAtualRepository _livroAtualRepository { get; }
        private readonly ILogger<LivroAtualController> _logger;
        public LivroAtualController(ILogger<LivroAtualController> logger, ILivroAtualRepository livroAtualRepository)
        {
            _logger = logger;
            _livroAtualRepository = livroAtualRepository;
        }


        [HttpGet("Get")]
        public LivroDTO GetLivroAtual()
        {
            return _livroAtualRepository.GetLivroAtual();
        }

        [HttpPut("Update")]
        public bool UpdateLivroAtual([FromBody] LivroDTO livro)
        {
            return _livroAtualRepository.UpdateLivroAtual(livro);
        }

    }
}
