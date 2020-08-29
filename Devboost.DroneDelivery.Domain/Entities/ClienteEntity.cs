using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devboost.DroneDelivery.Domain.Entities
{
	public class ClienteEntity
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		//public SqlGeography PontoGeografico
		//{
		//	get
		//	{
		//		SqlGeography point = SqlGeography.Point(this.Latitude, this.Longitude, 4326);
		//		return point;
		//	}
		//}
	}
}
