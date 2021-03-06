﻿using System;
using Devboost.DroneDelivery.Domain.Enums;

namespace Devboost.DroneDelivery.Domain.Entities
{
    public class PedidoEntity
    {
        public Guid Id { get; set; }
        public int Peso {get; set;}
        public ClienteEntity Cliente { get; set; }
		public int Cliente_ID { get; set; }
		public DateTime? DataHora { get; set; }
        public string Status { get; set; }
        public DroneEntity Drone { get; set; }
        public Guid DroneId { get; set; }
        public double DistanciaDaEntrega { get; set; }

        public readonly double DistanciaMaxima = 17000;
        public readonly int PesoGramasMaximo = 12000;

        public bool ValidaPedido()
        {
            return DistanciaDaEntrega <= DistanciaMaxima && Peso <= PesoGramasMaximo;
        }
    }
}