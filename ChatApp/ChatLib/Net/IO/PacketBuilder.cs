using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Net.IO
{
    public class PacketBuilder
    {
        MemoryStream _ms;

        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            _ms.Write(BitConverter.GetBytes(bytes.Length));
            _ms.Write(bytes);
        }

        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
