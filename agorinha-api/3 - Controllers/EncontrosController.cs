using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agorinha_api.Entities;
using agorinha_api.Entities.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace agorinha_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncontrosController : Controller
    {
        private IEncontrosRepository _encontrosRepository { get; }
        private readonly ILogger<EncontrosController> _logger;
        public EncontrosController(ILogger<EncontrosController> logger, IEncontrosRepository encontrosRepository)
        {
            _logger = logger;
            _encontrosRepository = encontrosRepository;
        }


        [HttpGet("GetAll")]
        public IEnumerable<EncontrosDTO> GetAllEncontros()
        {
            return _encontrosRepository.GetAllEncontros();
        }

    }
}
