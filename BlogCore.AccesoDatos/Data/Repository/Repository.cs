using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
    //Importamos la base de datos que se esta usando
    // La idea es que los controladores queden limpios
    

{
    //Importamos la clase a usar
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T Entity)
        {
            dbSet.Add(Entity);
        }
        public T Get(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            //Se hace una consulta Iqueryble a partir del DbSet del contexto
            IQueryable<T> query = dbSet;
            //Se aplica el filtro solo si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Se incluyen propiedades de navegacion si estas se porporcionan
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            //Si se manda un ordenamiento se hace aqui
            if (orderBy != null)
            {
                //Se hace el ordenamiento y lo pasa a lista
                return orderBy(query).ToList();
            }
            //Si no hay orden, se convierte la consulta en una lista
            return query.ToList();
        }
        public T GerFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            //Se hace una consulta Iqueryble a partir del DbSet del contexto
            IQueryable<T> query = dbSet;
            //Se aplica el filtro solo si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Se incluyen propiedades de navegacion si estas se porporcionan
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
        }

        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }
    }
}
