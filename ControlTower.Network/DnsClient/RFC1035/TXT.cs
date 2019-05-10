using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class TXT : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            TXT RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                   TXT-DATA                    /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            TXT-DATA        One or more <character-string>s.

            TXT RRs are used to hold descriptive text.  The semantics of the text
            depends on the domain where it is found.
        */
        public string Text;

        public static new string Name { get { return "TXT"; } }
        public static new ushort Service { get { return 0x10; } }

        public override string ToString() {
            return Text;
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request) {
            request.Write(Text);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            this.Text = request.ReadString(Length);
        }

    }
}
