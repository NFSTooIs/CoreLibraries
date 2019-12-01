// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 8:51 PM.

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// A chunk is the file-level container for a resource.
    /// </summary>
    public class BundleChunk
    {
        /// <summary>
        /// The ID of the chunk's data type.
        /// </summary>
        public uint Type { get; set; }

        /// <summary>
        /// The size of the chunk data
        /// </summary>
        public uint Size { get; set; }

        /// <summary>
        /// The offset of the chunk (@ header)
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// The end offset of the chunk data
        /// </summary>
        public long EndOffset => Offset + 8 + Size;
    }
}