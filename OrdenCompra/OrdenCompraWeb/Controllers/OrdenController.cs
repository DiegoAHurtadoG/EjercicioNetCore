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
	public class OrdenController : Controller
	{
		private readonly OrdenService _ordenService;

		public List<Orden> listar()
		{
			return _ordenService.ListarTodos();
		}

		public Orden obtener(long idOrden)
		{
			return _ordenService.ObtenerEntidad(idOrden);
		}

		public Orden guardar(Orden orden)
		{
			return _ordenService.Insertar(orden);
		}

		public Orden actualizar(Orden orden)
		{
			return _ordenService.Modificar(orden);
		}
	}
}
