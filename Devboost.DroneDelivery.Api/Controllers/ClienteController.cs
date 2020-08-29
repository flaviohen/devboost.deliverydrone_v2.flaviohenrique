using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Api.ModelRequest;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Commands;
using Devboost.DroneDelivery.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devboost.DroneDelivery.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteCommand _clienteCommand;
		private readonly IClienteQuery _clienteQuery;

		public ClienteController(IClienteCommand clienteCommand, IClienteQuery clienteQuery)
		{
			_clienteCommand = clienteCommand;
			_clienteQuery = clienteQuery;
		}

        [HttpPost("Insercao")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> InserirCliente([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                ClienteEntity clienteEntity = new ClienteEntity();
                clienteEntity.Nome = clienteRequest.Nome;
                clienteEntity.Endereco = clienteRequest.EnderecoFisico.Rua;
                clienteEntity.Latitude = clienteRequest.EnderecoFisico.Latitude;
                clienteEntity.Longitude = clienteRequest.EnderecoFisico.Longitude;

                await _clienteCommand.InserirCliente(clienteEntity);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Clientes")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RetornaClientes()
        {
            try
            {
                var lista = await _clienteQuery.GetAll();
                if (lista.Count.Equals(0)) return NotFound();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("RetornoPorID")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RetornaClientes([FromQuery] int id)
        {
            try
            {
                var lista = await _clienteQuery.GetByID(id);
                if (lista.Count.Equals(0)) return NotFound();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
