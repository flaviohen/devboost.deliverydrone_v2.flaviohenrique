using Devboost.DroneDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Domain.Interfaces.Commands
{
	public interface IClienteCommand
	{
		Task InserirCliente(ClienteEntity cliente);
	}
}
