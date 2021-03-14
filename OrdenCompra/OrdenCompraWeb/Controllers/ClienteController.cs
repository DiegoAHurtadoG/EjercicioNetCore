using Ejercicio.Dominio.Entidades;
using Ejercicio.Dominio.Servicios;
using Microsoft.AspNetCore.Mvc;
using OrdenCompraWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrdenCompraWeb.Controllers
{
	public class ClienteController : Controller
	{
		private readonly ClienteService _clienteService;

		public List<Cliente> listar()
		{
			return _clienteService.ListarTodos();
		}

		public Cliente obtener(long idCliente)
		{
			return _clienteService.ObtenerEntidad(idCliente);
		}

		public Cliente guardar(Cliente cliente)
		{
			return _clienteService.Insertar(cliente);
		}

		public Cliente actualizar(Cliente cliente)
		{
			return _clienteService.Modificar(cliente);
		}

		public void eliminar(long idCliente)
		{
			_clienteService.Eliminar(idCliente);
		}
	}
}
