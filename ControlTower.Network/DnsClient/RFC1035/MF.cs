using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MF : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MF RDATA format (Obsolete)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   MADNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            MADNAME         A <domain-name> which specifies a host which has a mail
                            agent for the domain which will accept mail for
                            forwarding to the domain.

            MF records cause additional section processing which looks up an A type
            record corresponding to MADNAME.

            MF is obsolete.  See the definition of MX and [RFC-974] for details ofw
            the new scheme.  The recommended policy for dealing with MD RRs found in
            a master file is to reject them, or to convert them to MX RRs with a
            preference of 10.

         */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string MFName { get { return dnsName.ToString(); } }

        public static new string Name { get { return "MF"; } }
        public static new ushort Service { get { return 0x04; } }

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
