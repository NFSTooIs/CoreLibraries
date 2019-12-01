// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 8:52 PM.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreLibraries.Data;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// The base class for a resource that can be found in a chunk.
    /// </summary>
    public abstract class ChunkResource : IDataEntity
    {
        private readonly ObservableCollection<IDataEntity> _children = new ObservableCollection<IDataEntity>();

        public BundleChunk Chunk { get; }
        public abstract string TypeName { get; }
        public abstract string Name { get; }
        public ICollection<IDataEntity> GetChildren() => _children;
        public void AddChild(IDataEntity child) => _children.Add(child);
    }
}