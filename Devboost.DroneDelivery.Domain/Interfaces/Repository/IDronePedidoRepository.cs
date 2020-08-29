using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Domain.Interfaces.Repository
{
	interface IDronePedidoRepository
	{
		Task InserirPedidosDrone();
	}
}
