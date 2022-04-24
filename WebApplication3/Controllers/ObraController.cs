using DomainService.Dominio.Entidades.DTO;
using DomainService.Dominio.Interfaces.Serviço;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObraController : ControllerBase
    {

        private readonly IObraService _service;
        public ObraController(IObraService service)
        {
            _service = service;
        }
        [HttpGet("ListarObra")]
        [ProducesResponseType(typeof(List<ObraDTO>), 200)]
        public IActionResult ListarObra()
        {
            List<ObraDTO> obras = _service.ListarObra();

            return Ok(obras);
        }

        [HttpGet("BuscarObra")]
        [ProducesResponseType(typeof(ObraDTO), 200)]
        public IActionResult BuscarCliente( int idObras)
        {
            ObraDTO obras = _service.BuscarObra(idObras);

            return Ok(obras);
        }

        [HttpPost("CadastrarObra")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult CadastrarObra( ObraDTO obra)
        {
            bool retorno = _service.InserirObra(obra);

            return Ok(retorno);
        }

        [HttpPut("AtualizarObra")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult AtualizarObra( AlterarObraDTO obra)
        {
            bool retorno = _service.AlterarObra(obra);

            return Ok(retorno);
        }
    }
}
