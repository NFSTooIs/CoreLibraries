// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 9:35 PM.

using System;
using System.Collections.Generic;
using System.IO;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// Reads chunks from a stream.
    /// </summary>
    /// <remarks>This class assumes that it is being given a raw stream, not a compressed or encrypted one.</remarks>
    public class BundleReader : IDisposable
    {
        private readonly Bundle _bundle;
        private readonly BinaryReader _reader;
        private readonly string _gameId;

        public BundleReader(Bundle bundle, Stream stream)
        {
            if (!stream.CanRead)
                throw new ArgumentException("stream is not readable");
            _bundle = bundle;
            _gameId = bundle.GameId;
            _reader = new BinaryReader(stream);
        }

        /// <summary>
        /// Reads chunk resources from the stream
        /// </summary>
        public void Read()
        {
            while (_reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                _bundle.Resources.Add(ReadResource());
            }
        }

        private ChunkResource ReadResource()
        {
            uint type = _reader.ReadUInt32();
            uint length = _reader.ReadUInt32();

            if (_reader.BaseStream.Position + length > _reader.BaseStream.Length)
            {
                throw new InvalidDataException($"overflowing chunk: 0x{type:X8} ({length} bytes)");
            }

            // set ourselves up to jump to the end
            long endPos = _reader.BaseStream.Position + length;

            // create chunk info
            BundleChunk chunk = new BundleChunk();
            chunk.Type = type;
            chunk.Size = length;
            chunk.Offset = _reader.BaseStream.Position - 8;

            // find reader
            ResourceReader reader = ChunkMapper.GetReader(_gameId, type);

            // read resource
            ChunkResource resource = reader.ReadResource(chunk, _reader);

            // we're all done
            _reader.BaseStream.Position = endPos;

            return resource;
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}