using Microsoft.SqlServer.Types;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Devboost.DroneDelivery.Repository.Models
{
	public class Cliente
	{
		[PrimaryKey]
		[AutoIncrement]
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		//public SqlGeography PontoGeografico { get; set; }
	}
}
