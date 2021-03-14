using Ejercicio.Infraestructura.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio.Infraestructura.Repositorios
{
    public abstract class RepositorioBase<T> where T : class
    {
        protected readonly ContextoAccesoDatos _dbContext;
        private bool disposed = false;

        protected RepositorioBase(ContextoAccesoDatos dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Agregar(T entidad)
        {
            _dbContext.Set<T>().Add(entidad);
            _dbContext.SaveChanges();
            return entidad;
        }

        public virtual void Eliminar(long id)
        {
            T entidad = BuscarPorId(id);
            _dbContext.Set<T>().Remove(entidad);
            _dbContext.SaveChanges();
        }

        public virtual void EliminarString(String id)
        {
            T entidad = BuscarPorIdString(id);
            _dbContext.Set<T>().Remove(entidad);
            _dbContext.SaveChanges();
        }

        public virtual void Eliminar(T entidad)
        {
            _dbContext.Set<T>().Remove(entidad);
            _dbContext.SaveChanges();
        }

        public virtual T BuscarPorId(long? id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual T BuscarPorIdString(String id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual List<T> ObtenerLista()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T Actualizar(T entidad)
        {
            _dbContext.Set<T>().Update(entidad);
            _dbContext.SaveChanges();
            return entidad;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _dbContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
