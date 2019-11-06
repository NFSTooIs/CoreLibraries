using System.IO;
using System.Text;

namespace CoreLibraries.IO
{
    public static class NullTerminatedString
    {
        public static string Read(BinaryReader br) => Read(br.BaseStream);

        public static string Read(Stream stream)
        {
            StringBuilder sb = new StringBuilder();
            byte b;
            do
            {
                int i = stream.ReadByte();

                if (i == -1) break;

                b = (byte) i;

                //b = br.ReadByte();
                if (b != 0)
                {
                    sb.Append((char)b);
                }
            } while (b != 0);
            return sb.ToString();
        }

        public static void Write(BinaryWriter bw, string value)
        {
            byte[] str = Encoding.ASCII.GetBytes(value);
            bw.Write(str);
            bw.Write((byte)0);
        }
    }
}
