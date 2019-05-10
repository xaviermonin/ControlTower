using System;

namespace InternetCommands.DNSRequest
{
    /// <summary>
    /// Description résumée de RequestResponse.
    /// </summary>
    public class DNSResourceRecord : DNSElement
    {
        /*
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            | 0| 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|15|
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                                               |
            /                                               /
            /                      NAME                     /
            |                                               |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                      TYPE                     |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                     CLASS                     |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                      TTL                      |
            |                                               |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                   RDLENGTH                    |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--|
            /                     RDATA                     /
            /                                               /
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
       */


        DNSName name;
        ushort dnsType;
        DNSClass dnsClass;
        uint timeToLive;
        public DNSResourceDetails Details { get; private set; }

        #region constructeurs
        /// <summary>
        /// Construit un éléments de requête/réponse DNS avec la définition de tous les éléments
        /// </summary>
        /// <param name="name">Nom de la requête</param>
        /// <param name="dnsType">Type de requête/réponse</param>
        /// <param name="dnsClass">Classe de requête/réponse</param>
        /// <param name="timeToLive">Durée de vie de la réponse DNS</param>
        public DNSResourceRecord(DNSRequest dnsrequest, string name, ushort dnsType, DNSClass dnsClass, uint timeToLive) {
            Name = name;
            Type = dnsType;
            Class = dnsClass;
            TimeToLive = timeToLive;
        }

        /// <summary>
        /// Construit un éléments de requête/réponse DNS avec la définition de tous les éléments
        /// </summary>
        /// <param name="name">Nom de la requête</param>
        /// <param name="dnsType">Type de requête/réponse</param>
        /// <param name="dnsClass">Classe de requête/réponse</param>
        public DNSResourceRecord(DNSRequest dnsrequest, string name, ushort dnsType, DNSClass dnsClass) {
            Name = name;
            Type = dnsType;
            Class = dnsClass;
            TimeToLive = 0;
        }

        /// <summary>
        /// Construit un détail de ressources
        /// </summary>
        public DNSResourceRecord() {
        }

        #endregion
        #region Support de DNSRequest

        /// <summary>
        /// transforme le résultat de la requête en chaîne de caractères 
        /// </summary>
        /// <returns>Résultat pour IDE</returns>
        public override string ToString() {
            System.Text.StringBuilder Ret = new System.Text.StringBuilder(256);
            Ret.Append(Details.DNSType);
            Ret.Append(",");
            Ret.Append(dnsClass);
            Ret.Append(",");
            Ret.Append(name);
            Ret.Append("\t(TTL:");
            TimeSpan tp = new TimeSpan(0, 0, (int)timeToLive);
            Ret.Append(tp.ToString());
            Ret.Append(")");
            Ret.Append("\n\t");
            Ret.Append(Details.ToString());
            
            return Ret.ToString();
             
        }

        #endregion
        #region Elements de réponse principaux
        /// <summary>
        /// Nom de la requête
        /// </summary>
        public string Name {
            get { return name.ToString(); }
            set { name = new DNSName(value); }
        }

        /// <summary>
        /// Renvoie le type de requete ou de réponse
        /// </summary>
        public ushort Type {
            get { return dnsType; }
            set { dnsType = value; }
        }

        /// <summary>
        /// Renvoie la classe de requête
        /// </summary>
        public DNSClass Class {
            get { return dnsClass; }
            set { dnsClass = value; }
        }

        /// <summary>
        /// Renvoie la duré de vie de la réponse DNS
        /// </summary>
        public uint TimeToLive {
            get { return timeToLive; }
            set { timeToLive = value; }
        }

        #endregion
        
        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(name);
            request.Write(dnsType);
            request.Write((ushort)dnsClass);
            request.Write(TimeToLive);
            ushort additionalDatasLengthPosition = (ushort)(request.Position);
            request.Write((ushort)0);
            ushort Begin = (ushort)(request.Position);
            Details.Write(request);
            ushort End = (ushort)request.Position;
            ushort detailsLength = (ushort)(End - Begin);
            request.Write(detailsLength, additionalDatasLengthPosition);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request) {
            name = request.ReadDNSName();
            Type = request.ReadShort();
            Class = (DNSClass)request.ReadShort();
            TimeToLive = request.ReadInt();
            ushort resourceDataLength = request.ReadShort();

            request.Push();    

            Details = CreateResourceDetails(Type);
            Details.resourceRecord = this;
            Details.Read(request, resourceDataLength);

            request.Pop();
            request.Position += resourceDataLength;

        }

    }
}
