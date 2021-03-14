using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Ejercicio.Dominio.Entidades
{
    public class Orden
    {       
        [Key]
        public long IdOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public long IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        private readonly List<OrdenArticulo> _ordenArticulos = new List<OrdenArticulo>();
        public IEnumerable<OrdenArticulo> OrdenArticulos => _ordenArticulos;

        public void AgregarDetalle(OrdenArticulo ordenArticulo) {
            if (!OrdenArticulos.Any(oa => oa.CodigoArticulo.Equals(ordenArticulo.CodigoArticulo)))
            {
                _ordenArticulos.Add(ordenArticulo);
            }

        }
    }
}
