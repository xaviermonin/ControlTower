using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class INFO : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            HINFO RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                      CPU                      /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                       OS                      /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            CPU             A <character-string> which specifies the CPU type.

            OS              A <character-string> which specifies the operating
                            system type.

            Standard values for CPU and OS can be found in [RFC-1010].

            HINFO records are used to acquire general information about a host.  The
            main use is for protocols such as FTP that can use special procedures
            when talking between machines or operating systems of the same type.
        */
        public string Text;

        public static new string Name { get { return "HINFO"; } }
        public static new ushort Service { get { return 0x0D; } }

        public override string ToString() {
            return Text;
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
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
