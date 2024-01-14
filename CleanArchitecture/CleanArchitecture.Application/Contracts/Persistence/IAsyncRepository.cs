using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository <T> where T : BaseDomainModel
    {
        //Mantenimiento de las entidades del proyecto
        Task<IReadOnlyList<T>> GetAllAsync();// Obtener los datos de la entidad
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T,bool>> predicate);// Obtener los datos de la entidad usando where
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includes = null,
            bool disableTraking = true);// Obtener los datos de la entidad usando where con order by 
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy =null,
            List<Expression<Func<T,object>>> includes=null,
            bool disableTraking=true);// Obtener los datos de la entidad usando where con order by  y Multiples Entidades

        Task<T> GetByIdAsync(int id);//Consulta por Id
        Task<T> AddAsync(T entity);//Agregar nuevos registros
        Task<T> UpdateAsync(T entity);//Actualizar nuevos registros
        Task DeleteAsync(T entity);//Eliminar nuevos registros


    }
}
