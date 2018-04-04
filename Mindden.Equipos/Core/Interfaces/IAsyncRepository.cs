﻿using Mindden.Equipos.Core.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mindden.Equipos.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Lists all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> ListAllAsync();

        /// <summary>
        /// Lists the asynchronous.
        /// </summary>
        /// <param name="spec">The spec.</param>
        /// <returns></returns>
        Task<List<T>> ListAsync(ISpecification<T> spec);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

    }
}