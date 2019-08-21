namespace BugTrackerGetIT.Core.Abstraction
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CSharpFunctionalExtensions;

    public interface IDomainRepository<T> where T : DomainModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFiltered(Func<T, bool> predicate);
        T GetById(int entityId);

        void Edit(T entity);
        void Insert(T entity);
        void Remove(int entityId);

        Task<Result> SaveChangesAsync();
    }
}