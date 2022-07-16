using StudentShadow.Conists;
using System.Linq.Expressions;

namespace StudentShadow.Services
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T>? FindAsync(Expression<Func<T, bool>> criteria, string[]? includes);

        Task<IEnumerable<T>>? FindAllAsync(Expression<Func<T, bool>> criteria, string[]? includes);

        Task<IEnumerable<T>>? FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
        Task<IEnumerable<T>>? FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T,object>> orderBy = null,string orderByDirection = OrderBy.ASCENDING
            );
        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Attach(T entity);

        void AttachRange(IEnumerable<T> entities);

        int Count();

        int Count(Expression<Func<T, bool>> criteria);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> criteria);


    }
}
