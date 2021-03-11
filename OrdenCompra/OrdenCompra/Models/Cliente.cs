using System;
using System.Collections.Generic;

namespace OrdenCompra.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Orden = new HashSet<Orden>();
        }

        public int IdCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string NombreCliente { get; set; }

        public virtual ICollection<Orden> Orden { get; set; }
    }
}
