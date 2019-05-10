using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MB : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MB RDATA format (EXPERIMENTAL)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   MADNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            MADNAME         A <domain-name> which specifies a host which has the
                            specified mailbox.

            MB records cause additional section processing which looks up an A type
            RRs corresponding to MADNAME.
        */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string MBName { get { return dnsName.ToString(); } }

        public static new string Name { get { return "MB"; } }
        public static new ushort Service { get { return 0x07; } }

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
