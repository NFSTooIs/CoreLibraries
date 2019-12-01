// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 9:11 PM.

using System;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// Attribute that describes internal metadata for a chunk resource.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ChunkMetaAttribute : Attribute
    {
        public ChunkMetaAttribute(uint typeId, uint requiredAlignment)
        {
            TypeID = typeId;
            RequiredAlignment = requiredAlignment;
        }

        /// <summary>
        /// The internal ID of the chunk type for the resource
        /// </summary>
        public uint TypeID { get; }

        /// <summary>
        /// Alignment boundary for the chunk type
        /// </summary>
        public uint RequiredAlignment { get; }
    }
}