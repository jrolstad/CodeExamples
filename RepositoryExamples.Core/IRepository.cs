using System.Linq;

namespace RepositoryExamples.Core
{
    /// <summary>
    /// Repository of data
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Search the repository
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <returns></returns>
        IQueryable<T> Find<T>() where T : IEntity;

        /// <summary>
        /// Obtains a single item
        /// </summary>
        /// <typeparam name="T">Item to search for</typeparam>
        /// <param name="key">Item key to find</param>
        /// <returns></returns>
        T Get<T>(object key) where T : IEntity;

        /// <summary>
        /// Saves a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void Save<T>(T value) where T : IEntity;

        /// <summary>
        /// Delete a given item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void Delete<T>(T value) where T : IEntity;
    }
}