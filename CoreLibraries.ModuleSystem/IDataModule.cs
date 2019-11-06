using System;

namespace CoreLibraries.ModuleSystem
{
    /// <summary>
    /// A common interface for code that implements the module system.
    /// Mandates the presence of various module operations.
    /// </summary>
    public interface IDataModule
    {
        /// <summary>
        /// 
        /// </summary>
        void Load();
    }
}
