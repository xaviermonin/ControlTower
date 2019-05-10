using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class NULL : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            NULL RDATA format (EXPERIMENTAL)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                  <anything>                   /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            Anything at all may be in the RDATA field so long as it is 65535 octets
            or less.
        */
        public byte[] datas;

        public static new string Name { get { return "NULL"; } }
        public static new ushort Service { get { return 0x0A; } }

        public override string ToString() {
            return string.Format("{0} bytes", datas.Length);
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request) {
            request.Write(this.datas);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            this.datas = request.ReadBytes(Length);
        }

    }
}
