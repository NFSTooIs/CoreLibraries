// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 9:57 PM.

using System.IO;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// Base class for a resource reader
    /// </summary>
    public abstract class ResourceReader
    {
        /// <summary>
        /// Reads the resource from the given stream
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        public abstract ChunkResource ReadResource(BundleChunk chunk, BinaryReader binaryReader);
    }

    /// <summary>
    /// Generic resource reader class
    /// </summary>
    /// <typeparam name="T">The <see cref="ChunkResource"/> type that will be read</typeparam>
    public abstract class ResourceReader<T> : ResourceReader where T : ChunkResource
    {
        public override ChunkResource ReadResource(BundleChunk chunk, BinaryReader binaryReader)
        {
            return ReadInternal(chunk, binaryReader);
        }

        protected abstract T ReadInternal(BundleChunk chunk, BinaryReader binaryReader);
    }
}