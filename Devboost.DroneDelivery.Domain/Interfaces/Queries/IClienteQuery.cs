using Devboost.DroneDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Domain.Interfaces.Queries
{
	public interface IClienteQuery
	{
		Task<List<ClienteEntity>> GetAll();
		Task<List<ClienteEntity>> GetByID(int id);
	}
}
