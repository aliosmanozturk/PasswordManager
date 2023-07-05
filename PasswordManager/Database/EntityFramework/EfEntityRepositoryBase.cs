using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Database.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.AddRange(entities);
                await context.SaveChangesAsync();
                return entities;
            }
        }

        public async Task UpdateRange(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.UpdateRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteRange(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                context.RemoveRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();

            }
        }
        public async Task<TEntity> GetFirst()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync();
            }
        }
    }
}
