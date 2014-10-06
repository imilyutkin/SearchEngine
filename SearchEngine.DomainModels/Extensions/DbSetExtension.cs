using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SearchEngine.DomainModels.Extensions
{
    public static class DbSetExtension
    {
        public static IQueryable<T> FindPredicate<T>(this DbSet<T> dbSet, Func<T, bool> predicate) where T : class
        {
            var local = dbSet.Local.Where(predicate).ToArray();
            return local.Any()
                ? local.AsQueryable()
                : dbSet.Where(predicate).ToList().AsQueryable();
        }
    }
}
