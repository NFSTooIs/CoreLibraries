// This file is part of CoreLibraries.ModuleSystem by heyitsleo.
// 
// Created: 10/29/2019 @ 5:52 PM.

using System;
using System.Collections.Generic;
using System.Linq;
using CoreLibraries.GameUtilities;

namespace CoreLibraries.ModuleSystem
{
    /// <summary>
    /// Describes a data module.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DataModuleInfoAttribute : Attribute
    {
        public string Name { get; }
        public List<string> Games { get; }
        public string Author { get; }
        public string Description { get; }

        public DataModuleInfoAttribute(string name, string author = null, string description = null,
            params string[] games)
        {
            Name = name;
            Games = games.ToList();
            Author = author;
            Description = description;
        }
    }
}