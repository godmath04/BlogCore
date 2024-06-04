using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    //T es un parametro de tipo generico  que representa una entidad con la que trabajar el repositorio
    //Esto se usa para que el T pueda ser cateogira, articulo o mas
    //Este codigo es una interfaz generica
    public interface IRepository<T> where T : class 
    {
        // Metodo para obtener un registro individual
        T Get(int id);

        //Metodo para obtener un registreo unico
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
                );
        //Metodo para obtenerl a lista
        T GerFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            String? includeProperties = null
            );

        void Add(T Entity);
        void Remove(int id);
        void Remove(T Entity);
    }
}
