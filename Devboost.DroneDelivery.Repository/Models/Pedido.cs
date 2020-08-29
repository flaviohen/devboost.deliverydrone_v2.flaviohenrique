using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devboost.DroneDelivery.Repository.Models
{
    [Table("dbo.Pedido")]
    public class Pedido
    {
        public Pedido()
        {
            Id = Guid.NewGuid();
            DataHora = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public int Peso { get; set; }
        public string Status { get; set; }
        public DateTime? DataHora { get; set; }
        public double DistanciaDaEntrega { get; set; }
        public Guid DroneId { get; set; }
    }
}