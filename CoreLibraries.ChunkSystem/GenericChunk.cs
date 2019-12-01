// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 9:48 PM.

namespace CoreLibraries.ChunkSystem
{
    public class GenericChunk : ChunkResource
    {
        public override string TypeName { get; }
        public override string Name => "";

        public byte[] Data { get; set; }
    }
}