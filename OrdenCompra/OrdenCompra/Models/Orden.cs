using System;
using System.Collections.Generic;

namespace OrdenCompra.Models
{
    public partial class Orden
    {
        public Orden()
        {
            OrdenArticulo = new HashSet<OrdenArticulo>();
        }

        public int IdOrden { get; set; }
        public DateTime? FechaOrden { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<OrdenArticulo> OrdenArticulo { get; set; }
    }
}
