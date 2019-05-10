using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class NS : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            NS RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   NSDNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            NSDNAME         A <domain-name> which specifies a host which should be
                            authoritative for the specified class and domain.

            NS records cause both the usual additional section processing to locate
            a type A record, and, when used in a referral, a special search of the
            zone in which they reside for glue information.

            The NS RR states that the named host should be expected to have a zone
            starting at owner name of the specified class.  Note that the class may
            not indicate the protocol family which should be used to communicate
            with the host, although it is typically a strong hint.  For example,
            hosts which are name servers for either Internet (IN) or Hesiod (HS)
            class information are normally queried using IN class protocols.
        */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string NSName { get { return dnsName.ToString(); } }


        public static new string Name { get { return "NS"; } }
        public static new ushort Service { get { return 0x02; } }

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
