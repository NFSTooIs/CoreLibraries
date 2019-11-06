// This file is part of CommonLib by heyitsleo.
// 
// Created: 10/28/2019 @ 6:13 PM.

using System.Linq;
using System.Text;

namespace CoreLibraries.GameUtilities
{
    public static class BINHasher
    {
        public static uint Hash(string text)
        {
            return Encoding.ASCII.GetBytes(text).Aggregate(0xFFFFFFFF, (h, b) => h * 33 + b);
        }
    }
}