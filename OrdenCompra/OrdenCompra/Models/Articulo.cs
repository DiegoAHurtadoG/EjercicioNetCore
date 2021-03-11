using System;
using System.Collections.Generic;

namespace OrdenCompra.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            OrdenArticulo = new HashSet<OrdenArticulo>();
        }

        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal? PrecioArticulo { get; set; }
        public int? StockArticulo { get; set; }

        public virtual ICollection<OrdenArticulo> OrdenArticulo { get; set; }
    }
}
