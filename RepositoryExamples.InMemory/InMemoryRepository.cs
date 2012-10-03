using System.Collections.Generic;
using System.Linq;
using Examples.Core;
using Examples.Core.Repositories;

namespace RepositoryExamples.InMemory
{
    /// <summary>
    /// Repository implementation that only persists data in Memory
    /// </summary>
    public class InMemoryRepository : IRepository
    {
        /// <summary>
        /// Where everything is persisted
        /// </summary>
        private readonly List<object> _entities = new List<object>();


        /// <summary>
        /// Search the repository
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <returns></returns>
        public IQueryable<T> Find<T>() where T : IEntity, new()
        {
            return _entities.OfType<T>().ToList().AsQueryable();
        }

        /// <summary>
        /// Obtains a single item
        /// </summary>
        /// <typeparam name="T">Item to search for</typeparam>
        /// <param name="key">Item key to find</param>
        /// <returns></returns>
        public T Get<T>(object key) where T : IEntity, new()
        {
            return _entities.OfType<T>().SingleOrDefault(e => e.Id == key.ToString());
        }

        /// <summary>
        /// Saves a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Save<T>(T value) where T : IEntity, new()
        {
            this.Delete(value);
            _entities.Add(value);
        }

        /// <summary>
        /// Delete a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Delete<T>(T value) where T : IEntity, new()
        {
            _entities.Remove(value);
        }
    }
}
