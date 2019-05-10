using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MR : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MR RDATA format (EXPERIMENTAL)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   NEWNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            NEWNAME         A <domain-name> which specifies a mailbox which is the
                            proper rename of the specified mailbox.

            MR records cause no additional section processing.  The main use for MR
            is as a forwarding entry for a user who has moved to a different
            mailbox.

         */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string MRName { get { return dnsName.ToString(); } }

        public static new string Name { get { return "MR"; } }
        public static new ushort Service { get { return 0x09; } }

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
