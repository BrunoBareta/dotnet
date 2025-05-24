using System.Collections.Generic;
using ApiClientes.Services;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _service;

        public ClientesController(ClientesService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ClienteDTO> Adicionar([FromBody] CriarClienteDTO body)
        {
            try
            {
                var response = _service.Criar(body);
                return Ok(response);
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message);
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> ListarTodos()
        {
            try
            {
                var response = _service.ListarTodos();
                return Ok(response);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> BuscarPorId(int id)
        {
            try
            {
                var response = _service.BuscarPorId(id);
                return Ok(response);
            }
            catch (BadRequestException B)
            {
                return NotFound(B.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] AtualizarClienteDTO body)
        {
            try
            {
                var response = _service.Atualizar(id, body);
                return Ok(response);
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent(); // HTTP 204
            }
            catch (BadRequestException B)
            {
                return NotFound(B.Message);
            }
            catch (System.Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }



    }
}
