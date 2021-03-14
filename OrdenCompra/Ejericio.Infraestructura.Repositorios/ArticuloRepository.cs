using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio.Infraestructura.Repositorios
{
    public class ArticuloRepository : RepositorioBase<Articulo>
    {
        public ArticuloRepository(ContextoAccesoDatos dbContext) : base(dbContext) { }
    }
}
