using System;
using System.Collections.Generic;

namespace OrdenCompra.Models
{
    public partial class OrdenArticulo
    {
        public string CodigoArticulo { get; set; }
        public int IdOrden { get; set; }
        public int? CantidadArticulo { get; set; }

        public virtual Articulo CodigoArticuloNavigation { get; set; }
        public virtual Orden IdOrdenNavigation { get; set; }
    }
}
