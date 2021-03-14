using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;

namespace Ejercicio.Dominio.Servicios
{
    public class OrdenService
    {
		private readonly OrdenRepository _ordenRepository;
		private readonly OrdenArticuloRepository _ordenArticuloRepository;
		private readonly ArticuloRepository _articuloRepository;

		public List<Orden> ListarTodos()
		{
			return _ordenRepository.ObtenerLista();
		}

		public Orden ObtenerEntidad(long idOrden)
		{
			return _ordenRepository.BuscarPorId(idOrden);
		}

		public Orden Insertar(Orden orden)
		{
			Orden nuevaOrden = _ordenRepository.Agregar(orden);
			foreach (OrdenArticulo oa in orden.OrdenArticulos) {
				oa.IdOrden = orden.IdOrden;

				_ordenArticuloRepository.Agregar(oa);

				Articulo art = _articuloRepository.BuscarPorIdString(oa.CodigoArticulo);
				art.actualizarStock(oa.CantidadArticulo);

				_articuloRepository.Actualizar(art);
			}
			return nuevaOrden;
		}

		public Orden Modificar(Orden orden)
		{			
			foreach (OrdenArticulo oa in orden.OrdenArticulos)
			{
				oa.IdOrden = orden.IdOrden;

				_ordenArticuloRepository.Actualizar(oa);

				Articulo art = _articuloRepository.BuscarPorIdString(oa.CodigoArticulo);
				art.actualizarStock(oa.CantidadArticulo);

				_articuloRepository.Actualizar(art);
			}
			return _ordenRepository.Actualizar(orden);
		}
	}
}
