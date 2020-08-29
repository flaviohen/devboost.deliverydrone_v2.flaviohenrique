using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Repository.Models;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devboost.DroneDelivery.Repository.Implementation
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly string _configConnectionString = "DroneDelivery";
		private readonly IDbConnectionFactoryExtended _dbFactory;

		public ClienteRepository(IConfiguration config)
		{
			_dbFactory = new OrmLiteConnectionFactory(
				config.GetConnectionString(_configConnectionString),
				SqlServerDialect.Provider);
		}

		public async Task<List<ClienteEntity>> GetAll()
		{
			try
			{
				using var conexao = await _dbFactory.OpenAsync();
				var list = await conexao.SelectAsync<Cliente>();
				return list.ConvertTo<List<ClienteEntity>>();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<ClienteEntity>> GetByID(int id)
		{
			try
			{
				using var conexao = await _dbFactory.OpenAsync();
				var list = await conexao.SelectAsync<Cliente>(d => d.Id == id);
				return list.ConvertTo<List<ClienteEntity>>();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task InserirCliente(ClienteEntity cliente)
		{
			try
			{
				var model = cliente.ConvertTo<Cliente>();
				using var conexao = await _dbFactory.OpenAsync();
				typeof(Cliente).GetModelMetadata().PrimaryKey.AutoIncrement = true;

				await conexao.InsertAsync(model);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
