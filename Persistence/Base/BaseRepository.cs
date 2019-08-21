namespace BugTrackerGetIT.Persistence.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BugTrackerGetIT.Core.Abstraction;
    using CSharpFunctionalExtensions;

    public class BaseRepository<T> : IDomainRepository<T> where T : DomainModel
    {
        private readonly ApplicationDbContext context;

        public BaseRepository (ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Edit(T entity)
        {
            var localEntity = GetById(entity.Id);
            localEntity = entity;
        }

        public IEnumerable<T> GetAll() => context.Set<T>();

        public T GetById(int entityId) => context.Set<T>().FirstOrDefault(x => x.Id == entityId);

        public IEnumerable<T> GetFiltered(Func<T, bool> predicate) => context.Set<T>().Where(predicate);

        public void Insert(T entity) => context.Set<T>().Add(entity);

        public void Remove(int entityId)
        {
            var localEntity = context.Set<T>().FirstOrDefault(x => x.Id == entityId);
            if (localEntity != null)
            {
                context.Set<T>().Remove(localEntity);
            }

        }

        public async Task<Result> SaveChangesAsync()
        {
            try 
            {
                await context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            
        }
    }
}