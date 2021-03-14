using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;

namespace Ejercicio.Dominio.Servicios
{
    public class ClienteService
    {
		private readonly ClienteRepository _clienteRepository;

		public List<Cliente> ListarTodos()
		{
			return _clienteRepository.ObtenerLista();
		}

		public Cliente ObtenerEntidad(long idCliente)
		{
			return _clienteRepository.BuscarPorId(idCliente);
		}

		public Cliente Insertar(Cliente cliente)
		{
			return _clienteRepository.Agregar(cliente);
		}
		public Cliente Modificar(Cliente cliente)
		{
			return _clienteRepository.Actualizar(cliente);
		}

		public void Eliminar(long idCliente)
		{
			_clienteRepository.Eliminar(idCliente);
		}
	}
}
