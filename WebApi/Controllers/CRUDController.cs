using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CRUDController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CRUDController> _logger;

        private readonly IDataAcessRepository _dataAcessRepository;
        public CRUDController(ILogger<CRUDController> logger, IDataAcessRepository DataAcessRepository)
        {
            _logger = logger;
            _dataAcessRepository = DataAcessRepository;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var results = _dataAcessRepository.ReadInfo();
            return results;
        }
    }
}
