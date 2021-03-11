using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenCompra.Models;

namespace OrdenCompra.Services
{
    public class OrdenService
    {
        private Models.ejercicioContext db = new Models.ejercicioContext();

        public List<Orden> listarTodos() {
            List<Orden> lista = (from o in db.Orden select o).ToList();
            foreach (Orden orden in lista)
            {
                orden.OrdenArticulo = (from oa in db.OrdenArticulo where oa.IdOrden.Equals(orden.IdOrden) select oa).ToList();
            }

            return lista;
        }

        public Orden obtenerEntidad(int idOrden)
        {
            try
            {
                return (from o in db.Orden where o.IdOrden.Equals(idOrden) select o).First();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public Orden insertar(Orden orden)
        {
            db.Orden.Add(orden);
            db.SaveChanges();

            foreach(OrdenArticulo articulo in orden.OrdenArticulo)
            {
                OrdenArticulo ordenArticulo = new OrdenArticulo();
                ordenArticulo.IdOrden = orden.IdOrden;
                ordenArticulo.CodigoArticulo = articulo.CodigoArticulo;
                ordenArticulo.CantidadArticulo = articulo.CantidadArticulo;
                db.OrdenArticulo.Add(ordenArticulo);
                db.SaveChanges();
                try
                {
                    ArticuloService articuloService = new ArticuloService();
                    Articulo art = articuloService.obtenerEntidad(articulo.CodigoArticulo);

                    art.StockArticulo = (art.StockArticulo - articulo.CantidadArticulo);
                    db.Articulo.Add(art);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.Write("Error en articulo");
                }
            }

            return orden;
        }

        public Orden modificar(Orden orden)
        {
            db.Orden.Update(orden);
            db.SaveChanges();
            return orden;
        }

        public void eliminarEntidad(int idOrden)
        {
            Orden obj = obtenerEntidad(idOrden);
            db.Orden.Remove(obj);
            db.SaveChanges();
        }
    }
}
