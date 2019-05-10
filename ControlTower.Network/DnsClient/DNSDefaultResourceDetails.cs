using System;
using System.Collections.Generic;
using System.Text;

namespace InternetCommands.DNSRequest
{
    class DNSDefaultResourceDetails : DNSResourceDetails 
    {
        public byte[] datas;

        public static new string Name { get { return "Unknown"; } }
        public static new ushort Service { get { return 0x00; } }

        public override string ToString() {
            return string.Format("Unknown\t{0} bytes", datas.Length);
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
