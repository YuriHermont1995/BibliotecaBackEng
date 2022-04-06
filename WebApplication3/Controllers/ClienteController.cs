using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Entidades.DTO;
using WebApplication3.Dominio.Interfaces;
using WebApplication3.Dominio.Serviços;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        [HttpGet("ListarCliente")]
        [ProducesResponseType(typeof(List<ClienteDTO>), 200)]
        public IActionResult ListarCliente()
        {
            List<ClienteDTO> clientes = _service.ListarCliente();

            return Ok(clientes);
        }

        [HttpGet("BuscarCliente")]
        [ProducesResponseType(typeof(ClienteDTO), 200)]
        public IActionResult BuscarCliente( int idCliente)
        {
            ClienteDTO clientes = _service.BuscarCliente(idCliente);

            return Ok(clientes);
        }
        
        [HttpPost("CadastrarCliente")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult CadastrarCliente( ClienteDTO cliente)
        {
            bool retorno = _service.InserirCliente(cliente);

            return Ok(retorno);
        }

        [HttpPut("AtualizarCliente")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult AtualizarCliente( ClienteDTO cliente)
        {
            bool retorno  = _service.AlterarCliente(cliente);

            return Ok(retorno);
        }

        [HttpDelete("ExcluirCliente")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult ExcluirCliente( int idCliente)
        {
            bool retorno = _service.DesativarCliente(idCliente);

            return Ok(retorno);
        }

        [HttpPost("RelizarEmprestimo")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult RelizarEmprestimo([FromQuery] ClienteDTO cliente,ObraDTO obra)
        {
            bool retorno = _service.RealizarEmprestimo(cliente, obra);

            return Ok(retorno);
        }

    }
}
