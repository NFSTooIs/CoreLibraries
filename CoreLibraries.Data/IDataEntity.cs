// This file is part of CoreLibraries.Data by heyitsleo.
// 
// Created: 11/14/2019 @ 6:03 PM.

using System.Collections.Generic;

namespace CoreLibraries.Data
{
    /// <summary>
    /// Contract for a data entity.
    /// </summary>
    /// <remarks>This interface can be extended if necessary.</remarks>
    public interface IDataEntity
    {
        string TypeName { get; }
        string Name { get; }

        /// <summary>
        /// Returns the collection of child <see cref="IDataEntity"/> instances.
        /// </summary>
        /// <returns>The collection of children</returns>
        ICollection<IDataEntity> GetChildren();

        /// <summary>
        /// Add the given <see cref="IDataEntity"/> to the collection of children
        /// </summary>
        /// <param name="child">The child entity to add</param>
        void AddChild(IDataEntity child);
    }
}