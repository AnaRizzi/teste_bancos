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

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
