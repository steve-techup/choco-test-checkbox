using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Caretag_Class.Util
{
    public enum CacheState
    {
        Updated,
        Created,
        LoadedFromDatabase,
        DoesNotExist
    }
    public class CachingRepository<TEntity, TLocalKey>
        where TEntity : class
    {

        private readonly DbSet<TEntity> _dbSet;
        private readonly Dictionary<TLocalKey, Tuple<TEntity, CacheState>> _store = new();

        public CachingRepository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        private Tuple<TEntity, CacheState> GetEntity(TLocalKey localKey)
        {
            if (_store.TryGetValue(localKey, out var tuple))
            {
                return tuple;
            }

            return null;
        }

        public TEntity Get(Func<TEntity, bool> query, TLocalKey localKey)
        {
            var localVal = GetEntity(localKey);
            if (localVal != null)
                return localVal.Item1;
            else
            {
                var dbVal = _dbSet.FirstOrDefault(query);
                if (dbVal != null)
                    _store.Add(localKey, new Tuple<TEntity, CacheState>(dbVal, CacheState.LoadedFromDatabase));
                return dbVal;
            }       
        }

        public CacheState GetState(TLocalKey localKey)
        {
            return GetEntity(localKey)?.Item2 ?? CacheState.DoesNotExist;
        }

        public void SetState(TLocalKey localKey, CacheState state)
        {
            var localVal = GetEntity(localKey);
            if (localVal != null)
                _store[localKey] = new Tuple<TEntity, CacheState>(localVal.Item1, state);
        }

        public void Add(TEntity entity, TLocalKey localKey)
        {
            _store.Add(localKey, new Tuple<TEntity, CacheState>(entity, CacheState.Created));
            _dbSet.Add(entity);
        }

        public void Remove(TLocalKey primaryKey)
        {
            _store.Remove(primaryKey);
        }
    }
}
