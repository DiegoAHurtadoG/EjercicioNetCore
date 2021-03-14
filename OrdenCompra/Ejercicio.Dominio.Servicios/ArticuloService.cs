using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;

namespace Ejercicio.Dominio.Servicios
{
    public class ArticuloService
    {
		private readonly ArticuloRepository _articuloRepository;

		public List<Articulo> ListarTodos()
		{
			return _articuloRepository.ObtenerLista();
		}

		public Articulo ObtenerEntidad(String codigoArticulo)
		{
			return _articuloRepository.BuscarPorIdString(codigoArticulo);
		}

		public Articulo Insertar(Articulo articulo)
		{
			return _articuloRepository.Agregar(articulo);
		}
		public Articulo Modificar(Articulo articulo)
		{
			return _articuloRepository.Actualizar(articulo);
		}

		public void Eliminar(String codigoArticulo)
		{
			_articuloRepository.EliminarString(codigoArticulo);
		}
	}
}
