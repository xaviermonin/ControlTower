using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    public class CNAME : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            CNAME RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                     CNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            CNAME           A <domain-name> which specifies the canonical or primary
                            name for the owner.  The owner name is an alias.

            CNAME RRs cause no additional section processing, but name servers may
            choose to restart the query at the canonical name in certain cases.  See
            the description of name server logic in [RFC-1034] for details.
        */
        private InternetCommands.DNSRequest.DNSName dnsName;

        public string CName { get { return dnsName.ToString(); }
                              set { dnsName = new DNSName(value); }
                            }


        public static new string Name { get { return "CNAME"; } }
        public static new ushort Service { get { return 0x05; } }

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
