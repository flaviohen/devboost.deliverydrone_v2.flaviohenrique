using Devboost.DroneDelivery.Api.Controllers;
using Devboost.DroneDelivery.Domain.Interfaces.Commands;
using Devboost.DroneDelivery.Domain.Interfaces.Queries;
using Devboost.DroneDelivery.Domain.Interfaces.Repository;
using Devboost.DroneDelivery.Domain.Interfaces.Services;
using Devboost.DroneDelivery.Domain.Params;
using Devboost.DroneDelivery.Domain.VOs;
using Devboost.DroneDelivery.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Xunit;

namespace Devboost.DroneDelivery.Test
{
	public class PedidoTest
	{
		public const string connectionString = @"Data Source=FLAVIO-NB\\SQLEXPRESS;Initial Catalog=DroneDelivery;Integrated Security=True";
		public IConfiguration _configuration { get; }
		private readonly IAuthService _authService;
		private readonly IPedidoCommand _pedidoCommand;
		private readonly IUsuariosRepository _usuarioRepository;
		private readonly IPedidoQuery _pedidoQuery;
		public PedidoTest() 
		{
			var services = new ServiceCollection();
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();
			_configuration = builder.Build();
			services.Configure<AppSettingsVO>(_configuration.GetSection("TokenSettings"));
			services.AddTokenConfiguration(_configuration);
			services.ResolveDependencies(_configuration);

			var serviceProvider = services.BuildServiceProvider();

			_authService = serviceProvider.GetService<IAuthService>();
			_pedidoCommand = serviceProvider.GetService<IPedidoCommand>();
			_usuarioRepository = serviceProvider.GetService<IUsuariosRepository>();
			_pedidoQuery = serviceProvider.GetService<IPedidoQuery>();

		}
		[Fact]
		public void CriarPedidoTest()
		{
			AuthParam login = new AuthParam();
			login.Login = "fulano";
			login.Senha = "123456#";

			var resultado = new AuthController(_authService).GetToken(login);

			if (((ObjectResult)resultado.Result).StatusCode == 200)
			{
				var idUsuario = _usuarioRepository.GetUsuarioByLoginSenha(new Domain.Entities.UsuarioEntity()
				{
					Login = login.Login,
					Senha = login.Senha
				}).Result.Id;

				PedidoParam pedido = new PedidoParam();
				pedido.ClienteID = idUsuario;
				pedido.DataHora = DateTime.Now;
				pedido.Peso = 2;

				var resultPedido = new PedidoController(_pedidoCommand, _pedidoQuery).ReceberPedido(pedido);

				Assert.True(((ObjectResult)resultPedido.Result).StatusCode == 200);

			}
			else 
			{
				Assert.True(false);
			}
		}
	}
}
