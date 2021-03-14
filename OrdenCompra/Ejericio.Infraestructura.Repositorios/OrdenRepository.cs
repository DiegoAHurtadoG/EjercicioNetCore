using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio.Infraestructura.Repositorios
{
    public class OrdenRepository : RepositorioBase<Orden>
    {
        public OrdenRepository(ContextoAccesoDatos dbContext) : base(dbContext) { }
    }
}
