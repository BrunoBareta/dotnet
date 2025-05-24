using ApiClientes.Services;
using ApiClientes.Services.DTOs;
using ApiClientes.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecosService _service;

        public EnderecosController(EnderecosService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<EnderecoDTO> Criar([FromBody] CriarEnderecoDTO dto)
        {
            try
            {
                var endereco = _service.Criar(dto);
                return Ok(endereco);
            }
            catch (BadRequestException b)
            {
                return BadRequest(b.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EnderecoDTO>> ListarTodos()
        {
            try
            {
                var lista = _service.ListarTodos();
                return Ok(lista);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EnderecoDTO> ListarPorId(int id)
        {
            try
            {
                var endereco = _service.ListarPorId(id);
                return Ok(endereco);
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EnderecoDTO> Atualizar(int id, [FromBody] AtualizarEnderecoDTO dto)
        {
            try
            {
                var endereco = _service.Atualizar(id, dto);
                return Ok(endereco);
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();
            }
            catch (BadRequestException b)
            {
                return NotFound(b.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
