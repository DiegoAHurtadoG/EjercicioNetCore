using Ejercicio.Dominio.Entidades;
using Ejercicio.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio.Infraestructura.Repositorios
{
    public class ClienteRepository : RepositorioBase<Cliente>
    {
        public ClienteRepository(ContextoAccesoDatos dbContext) : base(dbContext) { }
    }
}
