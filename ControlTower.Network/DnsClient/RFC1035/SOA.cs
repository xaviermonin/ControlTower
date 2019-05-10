using System;
using System.Collections.Generic;
using System.Text;
using InternetCommands.DNSRequest;

namespace RFC1035
{
    class SOA : InternetCommands.DNSRequest.DNSResourceDetails 
    {
        /*
            SOA RDATA format

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                     MNAME                     /
                /                                               /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                /                     RNAME                     /
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                    SERIAL                     |
                |                                               |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                    REFRESH                    |
                |                                               |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                     RETRY                     |
                |                                               |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                    EXPIRE                     |
                |                                               |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                |                    MINIMUM                    |
                |                                               |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            where:

            MNAME           The <domain-name> of the name server that was the
                            original or primary source of data for this zone.

            RNAME           A <domain-name> which specifies the mailbox of the
                            person responsible for this zone.

            SERIAL          The unsigned 32 bit version number of the original copy
                            of the zone.  Zone transfers preserve this value.  This
                            value wraps and should be compared using sequence space
                            arithmetic.

            REFRESH         A 32 bit time interval before the zone should be
                            refreshed.

            RETRY           A 32 bit time interval that should elapse before a
                            failed refresh should be retried.

            EXPIRE          A 32 bit time value that specifies the upper limit on
                            the time interval that can elapse before the zone is no
                            longer authoritative.

            MINIMUM         The unsigned 32 bit minimum TTL field that should be
                            exported with any RR from this zone.

            SOA records cause no additional section processing.

            All times are in units of seconds.

            Most of these fields are pertinent only for name server maintenance
            operations.  However, MINIMUM is used in all query operations that
            retrieve RRs from a zone.  Whenever a RR is sent in a response to a
            query, the TTL field is set to the maximum of the TTL field from the RR
            and the MINIMUM field in the appropriate SOA.  Thus MINIMUM is a lower
            bound on the TTL field for all RRs in a zone.  Note that this use of
            MINIMUM should occur when the RRs are copied into the response and not
            when the zone is loaded from a master file or via a zone transfer.  The
            reason for this provison is to allow future dynamic update facilities to
            change the SOA RR with known semantics.
        */
        private InternetCommands.DNSRequest.DNSName mName;
        private InternetCommands.DNSRequest.DNSName rName;
        private uint serial;
        private uint refresh;
        private uint retry;
        private uint expire;
        private uint minimum;

        public string MName { get { return mName.ToString(); } }
        public string RName { get { return rName.ToString(); } }
        public uint Serial { get { return serial; } }
        public uint Refresh { get { return refresh; } }
        public uint Retry { get { return retry; } }
        public uint Expire { get { return expire; } }
        public uint Minimum { get { return minimum; } }

        public static new string Name { get { return "SOA"; } }
        public static new ushort Service { get { return 0x06; } }

        public override string ToString() {
            return string.Format(
                "MName\t{0}\n\tRName\t{1}\n\tSerial\t{2}\n\tRetry\t{3}\n\tExpire\t{4}\n\tMinimum\t{5}", 
                mName, rName,serial,refresh,retry,expire,minimum);
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(mName);
            request.Write(rName);
            request.Write(serial);
            request.Write(refresh);
            request.Write(retry);
            request.Write(expire);
            request.Write(minimum);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request, int Length) {
            mName = request.ReadDNSName();
            rName = request.ReadDNSName();
            serial = request.ReadInt();
            refresh = request.ReadInt();
            retry = request.ReadInt();
            expire = request.ReadInt();
            minimum = request.ReadInt();
        }

    }
}
