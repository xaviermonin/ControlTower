using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    public class A : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            A RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                    ADDRESS                    |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            ADDRESS         A 32 bit Internet address.

            Hosts that have multiple Internet addresses will have multiple A
            records.
            A records cause no additional section processing.  The RDATA section of
            an A line in a master file is an Internet address expressed as four
            decimal numbers separated by dots without any imbedded spaces (e.g.,
            "10.2.0.52" or "192.0.5.6").
         */
        public System.Net.IPAddress ipAddress=null;

        public static new string Name { get { return "A"; } }
        public static new ushort Service { get { return 0x01; } }

        public override string ToString() {
            return ipAddress.ToString();
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(ipAddress.GetAddressBytes());
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            byte[] b = new byte[4];
            b[0] = request.ReadByte();
            b[1] = request.ReadByte();
            b[2] = request.ReadByte();
            b[3] = request.ReadByte();
            ipAddress = new System.Net.IPAddress(b);
        }

    }
}
