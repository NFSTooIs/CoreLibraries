// This file is part of CoreLibraries.ChunkSystem by heyitsleo.
// 
// Created: 11/22/2019 @ 9:55 PM.

using System;
using System.Collections.Generic;
using System.Reflection;
using CommonServiceLocator;

namespace CoreLibraries.ChunkSystem
{
    /// <summary>
    /// Maps chunk type IDs to readers/writers
    /// </summary>
    public static class ChunkMapper
    {
        private static readonly Dictionary<string, Dictionary<uint, Type>> _readerDictionary =
            new Dictionary<string, Dictionary<uint, Type>>();
        private static readonly Dictionary<string, Dictionary<uint, Type>> _writerDictionary =
            new Dictionary<string, Dictionary<uint, Type>>();

        public static void RegisterReader<TR, TI>(string gameId)
            where TR : ChunkResource where TI : ResourceReader<TR>
        {
            if (!_readerDictionary.ContainsKey(gameId))
                _readerDictionary[gameId] = new Dictionary<uint, Type>();
            Type resourceType = typeof(TR);

            if (resourceType.GetCustomAttribute(typeof(ChunkMetaAttribute)) is ChunkMetaAttribute metaAttribute)
                _readerDictionary[gameId].Add(metaAttribute.TypeID, typeof(TI));
            else
                throw new Exception($"{resourceType} does not have ChunkMetaAttribute");
        }

        public static ResourceReader GetReader(string gameId, uint type)
        {
            if (_readerDictionary[gameId].TryGetValue(type, out Type rt))
            {
                return (ResourceReader) ServiceLocator.Current.GetInstance(rt);
            }

            return new GenericResourceReader();
        }
        //private static Dictionary<uint, KeyValuePair<Type, Type>> _readerDictionary =
        //    new Dictionary<uint, KeyValuePair<Type, Type>>();
        //private static Dictionary<uint, KeyValuePair<Type, Type>> _writerDictionary =
        //    new Dictionary<uint, KeyValuePair<Type, Type>>();
    }
}