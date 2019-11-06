// This file is part of CoreLibraries.ModuleSystem by heyitsleo.
// 
// Created: 10/29/2019 @ 5:54 PM.

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CoreLibraries.ModuleSystem
{
    /// <summary>
    /// Loads modules through MEF.
    /// A search pattern can be provided, optionally.
    /// </summary>
    public class ModuleLoader
    {
        private readonly string _searchPattern;
        private readonly string _directory;

        private readonly AggregateCatalog _catalog;

        [ImportMany(typeof(IDataModule))]
        public List<Lazy<IDataModule>> Modules { get; }

        /// <summary>
        /// Initializes the loader.
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <param name="directory"></param>
        public ModuleLoader(string searchPattern = null, string directory = null)
        {
            _searchPattern = searchPattern;
            _directory = directory;
            _catalog = new AggregateCatalog(
                new DirectoryCatalog(_directory ?? AppDomain.CurrentDomain.BaseDirectory, _searchPattern ?? "*.dll"));
            Modules = new List<Lazy<IDataModule>>();
        }

        /// <summary>
        /// Loads modules
        /// </summary>
        public void Load()
        {
            CompositionContainer container = new CompositionContainer(_catalog);
            container.ComposeParts(this);

            foreach (var lazyModule in Modules)
            {
                IDataModule module = lazyModule.Value;
                module.Load();
            }
        }
    }
}