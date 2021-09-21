using Microsoft.AspNetCore.Mvc;
using ProjetoTarefa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        ClientService _service;
        public ClientController(ClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetClient(string email)
        {
            return Ok(_service.GetClient(email));
        }
    }
}
