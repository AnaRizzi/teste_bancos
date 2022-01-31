using AnaDomain.Interfaces;
using AnaDomain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet("buscar")]
        public IActionResult Get()
        {
            var listaClientes = _service.BuscarTodos();

            if (listaClientes.Count == 0)
            {
                return NotFound("Nenhum cliente encontrado");
            };

            var response = JsonSerializer.Serialize(listaClientes);

            return Ok(response);
        }

        [HttpGet("buscar/{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _service.Buscar(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var response = JsonSerializer.Serialize(cliente);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteRequest request)
        {
            var cliente = _service.Cadastrar(request);
            var response = JsonSerializer.Serialize(cliente);

            return Created("", response);
        }

        [HttpGet("comentarios/{id}")]
        public IActionResult BuscarComentarios(int id)
        {
            var comentarios = _service.BuscarComentarios(id);

            if (comentarios.Count == 0)
            {
                return NotFound("Nenhum comentário encontrado");
            }

            var response = JsonSerializer.Serialize(comentarios);

            return Ok(response);
        }

        [HttpPost("comentarios")]
        public IActionResult InserirComentarios(ComentarioRequest request)
        {
            try
            {
                _service.InserirComentario(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
