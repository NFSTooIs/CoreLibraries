// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 10:01 PM.

using System.IO;

namespace CoreLibraries.ChunkSystem
{
    public class GenericResourceReader : ResourceReader<GenericChunk>
    {
        protected override GenericChunk ReadInternal(BundleChunk chunk, BinaryReader binaryReader)
        {
            throw new System.NotImplementedException();
        }
    }
}