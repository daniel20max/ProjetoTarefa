using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTarefa.Services;
using ProjetoTarefa.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : Controller
    {
        ClientService _service;
        public ClientController(ClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetClientByEmail")]

        public IActionResult GetClient(string email)
        {
            return Ok(_service.GetClient(email));
        }
        [HttpDelete]
        [Route("DeleteClientByEmail")]
        public IActionResult DeleteClient(string email)
        {
            return Ok(_service.DeleteClient(email));
        }
        [HttpPatch]
        [Route("UpdateClientByEmail")]
        public IActionResult UpdateClient([FromBody]Client client)
        {
            return Ok(_service.UpdateClient(client));
        }
        
    }
}
