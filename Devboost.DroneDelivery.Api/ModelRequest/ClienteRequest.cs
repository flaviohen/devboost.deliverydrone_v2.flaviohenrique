using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Api.ModelRequest
{
	public class ClienteRequest
	{
		public string Nome { get; set; }
		public Endereco EnderecoFisico { get; set; }	
	}

	public class Endereco 
	{
		public string Rua { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
