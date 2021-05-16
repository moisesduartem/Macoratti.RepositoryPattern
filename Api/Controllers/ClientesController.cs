using BusinessLogic;
using Macoratti.RepositoryPattern.Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/v1/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteBusinessLogic _clienteBLL;

        public ClientesController()
        {
            _clienteBLL = new ClienteBusinessLogic();
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Cliente>> ListarClientes()
        {
            return Ok(_clienteBLL.ListarClientes());
        }

        [HttpGet]
        [Route("{id}", Name = "ObterCliente")]
        public ActionResult<Cliente> ObterCliente(int id)
        {
            var cliente = _clienteBLL.GetClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        [Route("")]
        public ActionResult IncluirCliente([FromBody] Cliente cliente)
        {
            try
            {
                _clienteBLL.AdicionarCliente(cliente);
                return CreatedAtRoute("ObterCliente", new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao tentar cadastrar cliente" });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult AlterarCliente(int id, [FromBody] Cliente requestData)
        {
            try
            {
                var cliente = _clienteBLL.GetClientePorId(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.Email = requestData.Email;
                cliente.Nome = requestData.Nome;

                _clienteBLL.AlterarCliente(cliente);

                return Ok(new { message = "Cliente atualizado com sucesso" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao tentar atualizar cliente" });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult ExcluirCliente(int id)
        {
            try
            {
                var cliente = _clienteBLL.GetClientePorId(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                _clienteBLL.ExcluirCliente(cliente);

                return Ok(new { message = "Cliente removido com sucesso" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao tentar remover cliente" });
            }
        }
    }
}
