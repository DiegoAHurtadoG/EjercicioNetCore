using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ejercicio.Dominio.Entidades
{
    public class OrdenArticulo
    {
        public string CodigoArticulo { get; set; }
        public long IdOrden { get; set; }
        public long CantidadArticulo { get; set; }
        public Articulo Articulo { get; set; }
    }
}
