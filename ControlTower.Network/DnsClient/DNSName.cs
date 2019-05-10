using System;
using System.Text;
namespace InternetCommands.DNSRequest
{
    /// <summary>
    /// Description résumée de DNSName.
    /// </summary>
    public class DNSName : DNSElement
    {
        /*
            Domain names in messages are expressed in terms of a sequence of labels.
            Each label is represented as a one octet length field followed by that
            number of octets.  Since every domain name ends with the null label of
            the root, a domain name is terminated by a length byte of zero.  The
            high order two bits of every length octet must be zero, and the
            remaining six bits of the length field limit the label to 63 octets or
            less.

            To simplify implementations, the total length of a domain name (i.e.,
            label octets and label length octets) is restricted to 255 octets or
            less.

            Although labels can contain any 8 bit values in octets that make up a
            label, it is strongly recommended that labels follow the preferred
            syntax described elsewhere in this memo, which is compatible with
            existing host naming conventions.  Name servers and resolvers must
            compare labels in a case-insensitive manner (i.e., A=a), assuming ASCII
            with zero parity.  Non-alphabetic codes must match exactly.
         */
        /*
            Various objects and parameters in the DNS have size limits.  They are
            listed below.  Some could be easily changed, others are more
            fundamental.

            labels          63 octets or less
            names           255 octets or less
         */
        /*
            In order to reduce the size of messages, the domain system utilizes a
            compression scheme which eliminates the repetition of domain names in a
            message.  In this scheme, an entire domain name or a list of labels at
            the end of a domain name is replaced with a pointer to a prior occurance
            of the same name.

            The pointer takes the form of a two octet sequence:

                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
                | 1  1|                OFFSET                   |
                +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+

            The first two bits are ones.  This allows a pointer to be distinguished
            from a label, since the label must begin with two zero bits because
            labels are restricted to 63 octets or less.  (The 10 and 01 combinations
            are reserved for future use.)  The OFFSET field specifies an offset from
            the start of the message (i.e., the first octet of the ID field in the
            domain header).  A zero offset specifies the first byte of the ID field,
            etc.

            The compression scheme allows a domain name in a message to be
            represented as either:

            - a sequence of labels ending in a zero octet

            - a pointer

            - a sequence of labels ending with a pointer

            Pointers can only be used for occurances of a domain name where the
            format is not class specific.  If this were not the case, a name server
            or resolver would be required to know the format of all RRs it handled.
            As yet, there are no such cases, but they may occur in future RDATA
            formats.

            If a domain name is contained in a part of the message subject to a
            length field (such as the RDATA section of an RR), and compression is
            used, the length of the compressed name is used in the length
            calculation, rather than the length of the expanded name.

            Programs are free to avoid using pointers in messages they generate,
            although this will reduce datagram capacity, and may cause truncation.
            However all programs are required to understand arriving messages that
            contain pointers.
        */

        string[] dnsName;
        int length;

        /// <summary>
        /// Contruit un nom dns à partir d'un nom canonique
        /// </summary>
        /// <param name="HostName">Nom canonique</param>
        public DNSName(string HostName) {
            length = HostName.Length + 2;
            dnsName = HostName.Split('.');
        }

        /// <summary>
        /// Construit un DNSName prêt pour une lecture
        /// </summary>
        public DNSName() {
        }

        /// <summary>
        /// Renvoie le nom de domaine au format canonique
        /// </summary>
        /// <returns>Nom de domaine en chîne de caractères</returns>
        public override string ToString() {
            return string.Join(".", dnsName);
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            foreach (string dnsPart in dnsName) {
                request.Write((byte)dnsPart.Length);
                request.Write(dnsPart);
            }
            request.Write((byte)0);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request) {
            System.Collections.ArrayList Name = new System.Collections.ArrayList();
            int domainLength;
            int Recurse = 0;

            do {
                domainLength = request.ReadByte();
                while ((domainLength & 0xC0) != 0) // on teste les bits de pointeurs
                {
                    int newPosition = ((domainLength & 0x3F) << 8) + (int)request.ReadByte();
                    request.Push(newPosition);
                    Recurse++;
                    domainLength = request.ReadByte();
                }
                if (domainLength != 0) {
                    string domainName = request.ReadString(domainLength);
                    Name.Add(domainName);
                }
            } while (domainLength != 0);

            request.Pop(Recurse);

            dnsName = new string[Name.Count];
            Array.Copy(Name.ToArray(), dnsName, Name.Count);
        }
    }
}
