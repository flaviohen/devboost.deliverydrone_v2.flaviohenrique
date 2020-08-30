using Devboost.DroneDelivery.Domain.DTOs;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Queries;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.DomainService.Queries
{
    public class DroneQuery : IDroneQuery
    {
        private readonly IDronesRepository _dronesRepository;
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IClienteRepository _clienteRepository;
        public DroneQuery(IDronesRepository dronesRepository, IPedidosRepository pedidosRepository, IClienteRepository clienteRepository)
        {
            _dronesRepository = dronesRepository;
            _pedidosRepository = pedidosRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ConsultaDronePedidoDTO>> ConsultaDrone()
        {
            var listaDrones = await _dronesRepository.GetAll();
            //AtualizaStatusDrones(listaDrones); Por enquanto os Drones nao serão atualizados via consulta de pedido, talvez um fila será responável por fazer essa atualização
            var drones = await _dronesRepository.GetAll();
            return drones.Select(async d => await RetornaConsultaDronePedido(d))
                .ToList()
                .Select(c => c.Result)
                .ToList();

        }

        public async Task<ConsultaDronePedidoDTO> RetornaConsultaDronePedido(DroneEntity drone)
        {

            var pedidos = await _pedidosRepository.GetByDroneID(drone.Id);

			foreach (var item in pedidos)
			{
                item.Cliente = _clienteRepository.GetByID(item.Cliente_ID).Result[0];
			}

            return new ConsultaDronePedidoDTO
            {

                IdDrone = drone.Id,
                Situacao = drone.Status.ToString(),
                Pedidos = pedidos
            };
        }        
    }
}