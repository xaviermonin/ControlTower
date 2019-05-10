using System;

namespace InternetCommands.DNSRequest
{
    /// <summary>
    /// Construit l'en-tête DNS
    /// </summary>
    public class DNSHeader : DNSElement
    {
        /*
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            | 0| 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|15|
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                      ID                       |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |QR|   Opcode  |AA|TC|RD|RA|   Z    |   RCODE   |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                    QDCOUNT                    |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                    ANCOUNT                    |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                    NSCOUNT                    |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
            |                    ARCOUNT                    |
            +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
        */

        /// <summary>
        /// Bit qui indique que le paquet est une réponse 1 ou une question 0
        /// Les valeurs sont décallés
        /// </summary>
        public enum DNSQR
        {
            Question = 0x00,
            Response = 0x80
        }

        /// <summary>
        /// Quatre bits qui indiquent l'opération demmandée
        /// Les valeurs possibles sont :
        /// Standart 0
        /// Inverse  1
        /// Status   2
        /// Les valeurs sont décallées
        /// </summary>
        public enum DNSOpcode
        {
            Standart = 0x00,
            Inverse = 0x10,
            Status = 0x20
        }

        public enum DNSError
        {
            Ok = 0x00, // No error condition
            FormatError = 0x01, // Format error - The name server was unable to interpret the query.
            ServerFailure = 0x02, // Server failure - The name server was unable to process this query due to a problem with the name server.
            NameError = 0x03, // Name Error - Meaningful only for responses from an authoritative name server, this code signifies that the domain name referenced in the query does not exist.
            NotImplemented = 0x04, // Not Implemented - The name server does not support the requested kind of query.
            Refused = 0x05  // Refused - The name server refuses to perform the specified operation for policy reasons.  For example, a name server may not wish to provide the information to the particular requester, or a name server may not wish to perform a particular operation (e.g., zone transfer) for particular data.
        }

        private const byte QR = 0x80;
        private const byte OpCode = 0x78;
        private const byte authoritativeAnswer = 0x04;
        private const byte messageTruncated = 0x02;
        private const byte recursionDesired = 0x01;

        private const byte recursionPossible = 0x08;
        private const byte ReservedZ = 0x00;
        private const byte error = 0xF;

        byte[] header = new byte[12];

        /// <summary>
        /// Construit un en-tête de question
        /// </summary>
        public DNSHeader() {
            System.Random rnd = new System.Random();
            QuestionIdentifier = rnd.Next(65535); //on généère un identifiant de requête, le retour doit être égal
            Question = true;    // Question
            Standart = true;    // Requête standard
            RecursionDesired = false; // On veut une répose récursive
            QuestionCount = 1;  // Question, on pose une question par défaut

            AnswerCount = 0;    //
            NSCount = 0;        // Pas une question par défaut, donc on met tout à 0
            ARCount = 0;        //
        }

        /// <summary>
        /// Renvoie l'en-tête sous forme de tableau d'octets
        /// </summary>
        /// <returns></returns>
        private byte[] ToByte() {
            return header;
        }

        /// <summary>
        /// Indentifiant de l'en-tête, tous les identifiant Question/Réponse d'une même requête doivent être égaux
        /// </summary>
        public int QuestionIdentifier {
            get { return ((int)header[0] << 8) + (int)header[1]; }
            set { header[0] = (byte)((value >> 8) & 0xFF); header[1] = (byte)(value & 0xFF); }
        }

        /// <summary>
        /// Indique qu'il s'agit d'une question
        /// </summary>
        public bool Question {
            get { return (QR & header[02]) == (byte)DNSQR.Question; }
            set { header[02] = (byte)((header[02] & (0xFF - QR)) | (byte)DNSQR.Question); }
        }

        /// <summary>
        /// Indique qu'il sagit d'une réponse
        /// </summary>
        public bool Response {
            get { return (QR & header[02]) == (byte)DNSQR.Response; }
            set { header[02] = (byte)((header[02] & (0xFF - QR)) | (byte)DNSQR.Response); }
        }

        /// <summary>
        /// Indique qu'il s'agit d'une requête standard
        /// </summary>
        public bool Standart {
            get { return (QR & header[02]) == (byte)DNSOpcode.Standart; }
            set { header[02] = (byte)((header[02] & (0xFF - OpCode)) | (byte)DNSOpcode.Standart); }
        }

        /// <summary>
        /// Indique qu'il s'agit d'une requête inverse
        /// </summary>
        public bool Inverse {
            get { return (QR & header[02]) == (byte)DNSOpcode.Inverse; }
            set { header[02] = (byte)((header[02] & (0xFF - OpCode)) | (byte)DNSOpcode.Inverse); }
        }

        /// <summary>
        /// Indique qu'il s'agit d'une recherche de status
        /// </summary>
        public bool Status {
            get { return (QR & header[02]) == (byte)DNSOpcode.Status; }
            set { header[02] = (byte)((header[02] & (0xFF - OpCode)) | (byte)DNSOpcode.Status); }
        }

        /// <summary>
        /// Indique qu'il s'agit de la réponse faisant autoritée
        /// </summary>
        public bool AuthoritativeAnswer {
            get { return (authoritativeAnswer & header[02]) != 0; }
            set { header[02] = (byte)((header[02] & (0xFF - authoritativeAnswer)) | (value ? authoritativeAnswer : (byte)0x0)); }
        }

        /// <summary>
        /// Indique que le message est tronqué
        /// </summary>
        public bool MessageTruncated {
            get { return (messageTruncated & header[02]) != 0; }
            set { header[02] = (byte)((header[02] & (0xFF - messageTruncated)) | (value ? messageTruncated : (byte)0x0)); }
        }

        /// <summary>
        /// Indique qu'on recherche les réponse récursive (???)
        /// </summary>
        public bool RecursionDesired {
            get { return (recursionDesired & header[02]) != 0; }
            set { header[02] = (byte)((header[02] & (0xFF - recursionDesired)) | (value ? recursionDesired : (byte)0x0)); }
        }

        /// <summary>
        /// Nombre de questions envoyées au serveur
        /// </summary>
        public int QuestionCount {
            get { return ((int)header[4] << 8) + (int)header[5]; }
            set { header[4] = (byte)((value >> 8) & 0xFF); header[5] = (byte)(value & 0xFF); }
        }

        /// <summary>
        /// Nom bre de réponse renvoyées par le serveur
        /// </summary>
        public int AnswerCount {
            get { return ((int)header[6] << 8) + (int)header[7]; }
            set { header[6] = (byte)((value >> 8) & 0xFF); header[7] = (byte)(value & 0xFF); }
        }

        /// <summary>
        /// Nombre de NS d'autorité renvoyés par le serveur
        /// </summary>
        public int NSCount {
            get { return ((int)header[8] << 8) + (int)header[9]; }
            set { header[8] = (byte)((value >> 8) & 0xFF); header[9] = (byte)(value & 0xFF); }
        }

        /// <summary>
        /// Nombre de réponses additionnelles renvoyées par le serveur
        /// </summary>
        public int ARCount {
            get { return ((int)header[10] << 8) + (int)header[11]; }
            set { header[10] = (byte)((value >> 8) & 0xFF); header[11] = (byte)(value & 0xFF); }
        }

        /// <summary>
        /// ecrit vers le flux sous-jaccent
        /// </summary>
        public override void Write(DNSRequest request)
        {
            request.Write(header);
        }

        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request) {
            header = request.ReadBytes(12);
        }

    }
}
