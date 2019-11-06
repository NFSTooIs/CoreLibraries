// This file is part of CommonLib by heyitsleo.
// 
// Created: 10/25/2019 @ 9:24 PM.

using System.IO;

namespace CoreLibraries.IO
{
    public interface IBinaryAccess
    {
        void Read(BinaryReader br);

        void Write(BinaryWriter bw);
    }
}