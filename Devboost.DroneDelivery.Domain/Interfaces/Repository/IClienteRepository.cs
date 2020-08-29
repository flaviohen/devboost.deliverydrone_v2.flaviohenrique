using Devboost.DroneDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Domain.Interfaces.Repository
{
	public interface IClienteRepository
	{
		Task InserirCliente(ClienteEntity cliente);
		Task<List<ClienteEntity>> GetAll();
		Task<List<ClienteEntity>> GetByID(int id);
	}
}
