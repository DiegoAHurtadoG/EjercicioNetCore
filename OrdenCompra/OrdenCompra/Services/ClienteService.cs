using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenCompra.Models;

namespace OrdenCompra.Services
{
    public class ClienteService
    {
        private Models.ejercicioContext db = new Models.ejercicioContext();

        public List<Cliente> listarTodos() {
            return (from c in db.Cliente select c).ToList();
        }

        public Cliente obtenerEntidad(int idCliente)
        {
            try
            {
                return (from c in db.Cliente where c.IdCliente.Equals(idCliente) select c).First();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public Cliente insertar(Cliente cliente)
        {
            db.Cliente.Add(cliente);
            db.SaveChanges();
            return cliente;
        }

        public Cliente modificar(Cliente cliente)
        {
            db.Cliente.Update(cliente);
            db.SaveChanges();
            return cliente;
        }

        public void eliminarEntidad(int idCliente)
        {
            Cliente obj = obtenerEntidad(idCliente);
            db.Cliente.Remove(obj);
            db.SaveChanges();
        }
    }
}
