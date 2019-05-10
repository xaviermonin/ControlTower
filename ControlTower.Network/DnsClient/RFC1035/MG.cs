using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MG : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MG RDATA format (EXPERIMENTAL)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   MGMNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            MGMNAME         A <domain-name> which specifies a mailbox which is a
                            member of the mail group specified by the domain name.

            MG records cause no additional section processing.
         */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string MGName { get { return dnsName.ToString(); } }

        public static new string Name { get { return "MG"; } }
        public static new ushort Service { get { return 0x08; } }

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
