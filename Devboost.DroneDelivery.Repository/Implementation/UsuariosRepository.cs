using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devboost.DroneDelivery.Domain.Entities;
using Devboost.DroneDelivery.Domain.Enums;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Repository.Models;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Devboost.DroneDelivery.Repository.Implementation
{
	public class UsuariosRepository : IUsuariosRepository
	{
		private readonly string _configConnectionString = "DroneDelivery";
		private readonly IDbConnectionFactoryExtended _dbFactory;

		public UsuariosRepository(IConfiguration config)
		{
			_dbFactory = new OrmLiteConnectionFactory(
				config.GetConnectionString(_configConnectionString),
				SqlServerDialect.Provider);
		}


		public async Task<UsuarioEntity> GetUsuarioByLoginSenha(UsuarioEntity usuario)
		{
			//var conexao = await _dbFactory.OpenAsync();
			//if (conexao.CreateTableIfNotExists<Usuario>())
			//{
			//	await conexao.InsertAllAsync(SeedUsuario());
			//}
			//var retornoUsuario = await conexao.SingleAsync<Usuario>(
			//	u =>
			//		u.Login == usuario.Login && u.Senha == usuario.Senha);

			var retornoUsuario = SeedUsuario().Where(c => c.Login == usuario.Login && c.Senha == usuario.Senha).FirstOrDefault();

			return retornoUsuario.ConvertTo<UsuarioEntity>();
		}

		private static List<Usuario> SeedUsuario()
		{
			return new List<Usuario>
			{
				new Usuario
				{
					Id = 1,
					Login = "fulano",
					Nome = "Fulano da Silva Ramos",
					Role = RoleEnum.Comprador,
					Senha = "123456#"
				},
				new Usuario
				{
					Id = 2,
					Login = "ciclano",
					Nome = "Ciclano da Silva",
					Role = RoleEnum.Administrador,
					Senha = "123456#"
				},
			};
		}
	}
}