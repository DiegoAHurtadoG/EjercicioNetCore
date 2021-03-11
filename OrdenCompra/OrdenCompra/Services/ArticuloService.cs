using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenCompra.Models;

namespace OrdenCompra.Services
{
    public class ArticuloService
    {
        private Models.ejercicioContext db = new Models.ejercicioContext();

        public List<Articulo> listarTodos() {
            return (from a in db.Articulo select a).ToList();
        }

        public Articulo obtenerEntidad(String codigoArticulo)
        {
            try
            {
                return (from a in db.Articulo where a.CodigoArticulo.Equals(codigoArticulo) select a).First();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public Articulo insertar(Articulo articulo)
        {
            db.Articulo.Add(articulo);
            db.SaveChanges();
            return articulo;
        }

        public Articulo modificar(Articulo articulo)
        {
            db.Articulo.Update(articulo);
            db.SaveChanges();
            return articulo;
        }

        public void eliminarEntidad(String codigoArticulo)
        {
            Articulo obj = obtenerEntidad(codigoArticulo);
            db.Articulo.Remove(obj);
            db.SaveChanges();
        }
    }
}
