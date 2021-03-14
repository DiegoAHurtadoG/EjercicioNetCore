using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ejercicio.Dominio.Entidades
{
    public class Articulo
    {
        [Key]
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal PrecioArticulo { get; set; }
        public long StockArticulo { get; set; }

        public void actualizarStock(long cantidad) {
            long nuevoStock = StockArticulo - cantidad;

            if (nuevoStock >= 0)
            {
                StockArticulo = nuevoStock;
            }
            else {
                throw new Exception("El numero de stock es incorrecto ");
            }
        }
    }
}
