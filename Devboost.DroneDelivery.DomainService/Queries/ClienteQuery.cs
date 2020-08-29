using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Queries;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.DomainService.Queries
{
	public class ClienteQuery : IClienteQuery
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteQuery(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public Task<List<ClienteEntity>> GetAll()
		{
			return _clienteRepository.GetAll();
		}

		public Task<List<ClienteEntity>> GetByID(int id)
		{
			return _clienteRepository.GetByID(id);
		}
	}
}
