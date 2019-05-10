using System;
using System.Collections.Generic;
using System.Text;

namespace InternetCommands.DNSRequest
{
    public enum DNSClass
    {
        /// <summary>
        /// the Internet
        /// </summary>
        IN = 0x01,
        /// <summary>
        /// the CSNET class (Obsolete - used only for examples in some obsolete RFCs) 
        /// </summary>
        CS = 0x02,
        /// <summary>
        /// the CHAOS class
        /// </summary>
        CH = 0x03,
        /// <summary>
        /// Hesiod [Dyer 87]
        /// </summary>
        HS = 0x04,
        /// <summary>
        /// any class
        /// </summary>
        ALL = 0xFF
    }

}
