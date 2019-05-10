using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MD : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MD RDATA format (Obsolete)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   MADNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            MADNAME         A <domain-name> which specifies a host which has a mail
                            agent for the domain which should be able to deliver
                            mail for the domain.

            MD records cause additional section processing which looks up an A type
            record corresponding to MADNAME.

            MD is obsolete.  See the definition of MX and [RFC-974] for details of
            the new scheme.  The recommended policy for dealing with MD RRs found in
            a master file is to reject them, or to convert them to MX RRs with a
            preference of 0.
         */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string MDName { get { return dnsName.ToString(); } }

        public static new string Name { get { return "MD"; } }
        public static new ushort Service { get { return 0x03; } }

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
