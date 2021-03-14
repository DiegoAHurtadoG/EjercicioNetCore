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
	public class ArticuloController : Controller
	{
		private readonly ArticuloService _articuloService;

		public List<Articulo> listar()
		{
			return _articuloService.ListarTodos();
		}

		public Articulo obtener(String codigoArticulo)
		{
			return _articuloService.ObtenerEntidad(codigoArticulo);
		}

		public Articulo guardar(Articulo cliente)
		{
			return _articuloService.Insertar(cliente);
		}

		public Articulo actualizar(Articulo cliente)
		{
			return _articuloService.Modificar(cliente);
		}

		public void eliminar(String codigoArticulo)
		{
			_articuloService.Eliminar(codigoArticulo);
		}
	}
}
