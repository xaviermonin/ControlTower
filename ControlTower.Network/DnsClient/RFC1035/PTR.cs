using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class PTR : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            PTR RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   PTRDNAME                    /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            PTRDNAME        A <domain-name> which points to some location in the
                            domain name space.

            PTR records cause no additional section processing.  These RRs are used
            in special domains to point to some other location in the domain space.
            These records are simple data, and don't imply any special processing
            similar to that performed by CNAME, which identifies aliases.  See the
            description of the IN-ADDR.ARPA domain for an example.
        */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string PTRName { get { return dnsName.ToString(); } }


        public static new string Name { get { return "PTR"; } }
        public static new ushort Service { get { return 0x0C; } }

        public override string ToString() {
            return dnsName.ToString();
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(dnsName);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            dnsName = request.ReadDNSName();
        }

    }
}
