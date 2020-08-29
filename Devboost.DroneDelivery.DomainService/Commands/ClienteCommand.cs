using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Commands;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.DomainService.Commands
{
	public class ClienteCommand : IClienteCommand
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteCommand(IClienteRepository clienteRepository) 
		{
			_clienteRepository = clienteRepository;
		}
		public async Task InserirCliente(ClienteEntity cliente)
		{
			await _clienteRepository.InserirCliente(cliente);
		}
	}
}
