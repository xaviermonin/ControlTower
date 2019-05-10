using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class MINFO : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            MINFO RDATA format (EXPERIMENTAL)

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                    RMAILBX                    /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                    EMAILBX                    /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            RMAILBX         A <domain-name> which specifies a mailbox which is
                            responsible for the mailing list or mailbox.  If this
                            domain name names the root, the owner of the MINFO RR is
                            responsible for itself.  Note that many existing mailing
                            lists use a mailbox X-request for the RMAILBX field of
                            mailing list X, e.g., Msgroup-request for Msgroup.  This
                            field provides a more general mechanism.


            EMAILBX         A <domain-name> which specifies a mailbox which is to
                            receive error messages related to the mailing list or
                            mailbox specified by the owner of the MINFO RR (similar
                            to the ERRORS-TO: field which has been proposed).  If
                            this domain name names the root, errors should be
                            returned to the sender of the message.

            MINFO records cause no additional section processing.  Although these
            records can be associated with a simple mailbox, they are usually used
            with a mailing list.


        */
        private InternetCommands.DNSRequest.DNSName eMailBx;
        private InternetCommands.DNSRequest.DNSName rMailBx;

        public string EMailBx { get { return eMailBx.ToString(); } }
        public string RMailBx { get { return rMailBx.ToString(); } }

        public static new string Name { get { return "MINFO"; } }
        public static new ushort Service { get { return 0x0E; } }

        public override string ToString() {
            return string.Format("EMAILBX\t{0}\n\tRMAILBX\t{1}", eMailBx, rMailBx);
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(eMailBx);
            request.Write(rMailBx);
        }
        
        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            eMailBx = request.ReadDNSName();
            rMailBx = request.ReadDNSName();
        }

    }
}
