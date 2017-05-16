using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2012130659_ENTStore.Entities.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Metodos estandar que todos las tablas deben tener.
        //se programa de manera generica para no duplicar codigo cada una.
        //CREATES
        //Agrega un registro al repositorio (SQL Server) a la tabla TEnyity
        void Add(TEntity entity);
        //Agrega un grupo de registro al repositorio (SQL Server) a la tabla TEnyity
        void AddRange(IEnumerable<TEntity> entities);

        //READS
        //obtiene el Registro con Primare Key = Id de la tabla Tentity
        TEntity Get(int Id);
        //obtiene todos los Registros de la tabla Tentity
        IEnumerable<TEntity> GetAll();
        //Obtiene todos los registros de la tabla TEntity que cumplan con la codicion predicate
        //predicate es un exprecion lambda que tiene como parametro de enterada a TEntity
        //y devolvera una espresion booleana. si esa exprecion es True para un registro,
        //entonces dicho registro se agrega a la lista de registro a la aplicacion.
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //UPDATES
        //Actualiza un registro al repositorio (SQL Server) a la tabla TEnyity
        void Update(TEntity entity);
        //Actualiza un grupo de registro al repositorio (SQL Server) a la tabla TEnyity
        void UpdateRange(IEnumerable<TEntity> entities);
        //DELETES
        //Elimina un registro al repositorio (SQL Server) a la tabla TEnyity
        void Delete(TEntity entity);
        //Elimina un grupo de registro al repositorio (SQL Server) a la tabla TEnyity
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
