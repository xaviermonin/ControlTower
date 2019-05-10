using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MX : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MX RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                  PREFERENCE                   |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   EXCHANGE                    /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            PREFERENCE      A 16 bit integer which specifies the preference given to
                            this RR among others at the same owner.  Lower values
                            are preferred.

            EXCHANGE        A <domain-name> which specifies a host willing to act as
                            a mail exchange for the owner name.

            MX records cause type A additional section processing for the host
            specified by EXCHANGE.  The use of MX RRs is explained in detail in
            [RFC-974].
         */
        private InternetCommands.DNSRequest.DNSName dnsName;
        private ushort preference;

        public string MailExchanger { get { return dnsName.ToString(); } }
        public ushort Preference { get { return preference; } }

        public static new string Name { get { return "MX"; } }
        public static new ushort Service { get { return 0x0F; } }

        public override string ToString() {
            return string.Format("{0}\t{1}", preference, dnsName);
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(preference);
            request.Write(dnsName);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            preference = request.ReadShort();
            dnsName = request.ReadDNSName();
        }

    }
}
