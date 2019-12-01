// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 8:50 PM.

using System.Collections.Generic;
using System.IO;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// A bundle contains data resources stored in the form of "chunks".
    /// Each chunk has a type ID and a variable-length stream of data.
    /// Different type IDs correspond to different types of resources.
    /// </summary>
    public class Bundle
    {
        public Bundle(string gameId)
        {
            GameId = gameId;
        }

        public IList<ChunkResource> Resources { get; } = new List<ChunkResource>();

        public string GameId { get; }

        public void Load(Stream stream)
        {
            using (BundleReader reader = new BundleReader(this, stream))
            {
                reader.Read();
            }
        }
    }
}