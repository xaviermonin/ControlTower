using System;
using InternetCommands;

namespace InternetCommands.DNSRequest
{
    /// <summary>
    /// Description résumée de DNSRequest.
    /// </summary>
    public class DNSRequest : DNSElement
    {
        /*
        All communications inside of the domain protocol are carried in a single
        format called a message.  The top level format of message is divided
        into 5 sections (some of which are empty in certain cases) shown below:

            +---------------------+
            |        Header       |
            +---------------------+
            |       Question      | the question for the name server
            +---------------------+
            |        Answer       | RRs answering the question
            +---------------------+
            |      Authority      | RRs pointing toward an authority
            +---------------------+
            |      Additional     | RRs holding additional information
            +---------------------+

        The header section is always present.  The header includes fields that
        specify which of the remaining sections are present, and also specify
        whether the message is a query or a response, a standard query or some
        other opcode, etc.

        The names of the sections after the header are derived from their use in
        standard queries.  The question section contains fields that describe a
        question to a name server.  These fields are a query type (QTYPE), a
        query class (QCLASS), and a query domain name (QNAME).  The last three
        sections have the same format: a possibly empty list of concatenated
        resource records (RRs).  The answer section contains RRs that answer the
        question; the authority section contains RRs that point toward an
        authoritative name server; the additional records section contains RRs
        which relate to the query, but are not strictly answers for the
        question.
        */

        /// <summary>
        /// Message transmis ou envoyé grâce à l'objet courant
        /// </summary>
        private ByteStream Message;

        private DNSHeader header;
        private DNSQuestion[] questions;
        private DNSResourceRecord[] answers;
        private DNSResourceRecord[] authorities;
        private DNSResourceRecord[] additionals;

        /// <summary>
        /// Construit une requête standard (nom vers type)
        /// </summary>
        /// <param name="name">Nom du domaine à requêter</param>
        /// <param name="Type"></param>
        public DNSRequest(string name, string Type) {
            header = new DNSHeader();
            header.Standart = true;
            header.RecursionDesired = true;
            header.QuestionCount = 1;
            header.AnswerCount = 0;
            header.NSCount = 0;
            header.ARCount = 0;

            // On dimensionne es différents éléments en fonction des besoins
            questions = new DNSQuestion[header.QuestionCount];
            answers = new DNSResourceRecord[header.AnswerCount];
            authorities = new DNSResourceRecord[header.NSCount];
            additionals = new DNSResourceRecord[header.ARCount];

            // On créé la question
            questions[0] = new DNSQuestion(name, Type, DNSClass.ALL);
        }

        public DNSRequest(byte[] dnsResponse) {
            Message = new ByteStream(dnsResponse);
            Read(this);

            /*
            int offset = 0;

            // On lit la réponse du serveur
            header = new DNSHeader(dnsResponse, ref offset);

            // On dimensionne les espace servant à lire les réponses
            questions = new DNSQuestion[header.QuestionCount];
            answers = new DNSResourceRecord[header.AnswerCount];
            authorities = new DNSResourceRecord[header.NSCount];
            additionals = new DNSResourceRecord[header.ARCount];

            // On lit les questions
            for (int i = 0 ; i < questions.Length ; i++) {
                questions[i] = new DNSQuestion(dnsResponse, ref offset);
            }

            // On lit les réponses
            for (int i = 0 ; i < answers.Length ; i++) {
                answers[i] = new DNSResourceRecord(dnsResponse, ref offset);
            }

            // On lit les réponses d'authorités
            for (int i = 0 ; i < authorities.Length ; i++) {
                authorities[i] = new DNSResourceRecord(dnsResponse, ref offset);
            }

            // On lit les réponses additionnelles
            for (int i = 0 ; i < additionals.Length ; i++) {
                additionals[i] = new DNSResourceRecord(dnsResponse, ref offset);
            }
            */
        }

        /// <summary>
        /// Renvoie la requête sous forme d'octets (échangeables sur le net)
        /// </summary>
        /// <returns>Tableau de requête DNS</returns>
        public byte[] ToByte() {
            Write(this);
            return Message.ToBytes();
        }

        /// <summary>
        /// Listes des questions
        /// </summary>
        public DNSQuestion[] Questions { get { return questions; } }
        /// <summary>
        /// Liste des réponses
        /// </summary>
        public DNSResourceRecord[] Answers { get { return answers; } set { answers = value; } }
        /// <summary>
        /// Liste des réponses d'autorités
        /// </summary>
        public DNSResourceRecord[] Authorities { get { return authorities; } }
        /// <summary>
        /// Liste des réponses additionnelles
        /// </summary>
        public DNSResourceRecord[] Additionals { get { return additionals; } }

        public override string ToString() {
            System.Text.StringBuilder ret = new System.Text.StringBuilder();
            ret.Append("Questions : \n");
            foreach (object i in Questions) ret.Append(i.ToString() + "\n");
            ret.Append("Answers : \n");
            foreach (object i in Answers) ret.Append(i.ToString() + "\n");
            ret.Append("Authorities : \n");
            foreach (object i in Authorities) ret.Append(i.ToString() + "\n");
            ret.Append("Additionals : \n");
            foreach (object i in Additionals) ret.Append(i.ToString() + "\n");
            return ret.ToString();
        }

        #region Prise en charge de l'écriture vers un flux de bytes

        public override void Write(DNSRequest request)
        {
            Message = new ByteStream();

            header.Write(request);
            foreach (DNSElement i in questions) {
                i.Write(request);
            }
            foreach (DNSElement i in answers) {
                i.Write(request);
            }
            foreach (DNSElement i in authorities) {
                i.Write(request);
            }
            foreach (DNSElement i in additionals) {
                i.Write(request);
            }

        }

        /// <summary>
        /// Ecrit un entier sur le flux
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(uint Value) {
            Message.Write(Value);
        }

        /// <summary>
        /// Ecrit un entier court sur le flux
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(ushort Value) {
            Message.Write(Value);
        }

        /// <summary>
        /// Ecrit un entier court sur le flux à la position indiquée
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(ushort Value, ushort position) {
            Message.Push();
            Message.Position = position;
            Message.Write(Value);
            Message.Pop();
        }

        /// <summary>
        /// Ecrit un octet sur le flux
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(byte Value) {
            Message.Write(Value);
        }

        /// <summary>
        /// Ecrit une chaine de caractères sur le flux
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(string Value) {
            Message.Write(Value);
        }

        /// <summary>
        /// Ecrit une chaine d'octets sur le flux
        /// </summary>
        /// <param name="Value">valeur à écrire</param>
        public void Write(byte[] Value) {
            Message.Write(Value);
        }


        /// <summary>
        /// Ecrit un nom DNS sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(DNSName Value) {
            Value.Write(this);
        }

        #endregion 

        #region Prise en charge de la lecture depuis un flux de bytes
        /// <summary>
        /// Lit le flux sous-jacent
        /// </summary>
        public override void Read(DNSRequest request) {
            Message.Position = 0;
            // On lit la réponse du serveur
            header = new DNSHeader();
            header.Read(request);

            // On dimensionne les espace servant à lire les réponses
            questions = new DNSQuestion[header.QuestionCount];
            answers = new DNSResourceRecord[header.AnswerCount];
            authorities = new DNSResourceRecord[header.NSCount];
            additionals = new DNSResourceRecord[header.ARCount];

            // On lit les questions
            for (int i = 0 ; i < questions.Length ; i++) {
                questions[i] = new DNSQuestion();
                questions[i].Read(request);
            }

            // On lit les réponses
            for (int i = 0 ; i < answers.Length ; i++) {
                answers[i] = new DNSResourceRecord();
                answers[i].Read(request);
            }

            // On lit les réponses d'authorités
            for (int i = 0 ; i < authorities.Length ; i++) {
                authorities[i] = new DNSResourceRecord();
                authorities[i].Read(request);
            }

            // On lit les réponses additionnelles
            for (int i = 0 ; i < additionals.Length ; i++) {
                additionals[i] = new DNSResourceRecord();
                additionals[i].Read(request);
            }
        }

        /// <summary>
        /// Lit un octet dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public byte ReadByte() {
            return (byte)Message.ReadByte();
        }

        /// <summary>
        /// Lit un octet dans le flux courant et le traduit en chaine hexa (Binary Coded HexaDecimal)
        /// </summary>
        /// <returns>Valeur lue</returns>
        public string ReadBCH() {
            byte ret = (byte)Message.ReadByte();
            return ret.ToString("X2");
        }

        /// <summary>
        /// Lit un entier court dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public ushort ReadShort() {
            return Message.ReadShort();
        }

        /// <summary>
        /// Lit un entier dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public uint ReadInt() {
            return Message.ReadInt();
        }

        /// <summary>
        /// Lit une chaine en précisant sa taille dans le flux courant
        /// </summary>
        /// <param name="length">taille de la chaine à lire</param>
        /// <returns>Valeur lue</returns>
        public string ReadString(int length) {
            return Message.ReadString(length);
        }

        /// <summary>
        /// Lit une chaine en assumant qu'elle est précédée par sa taille dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public string ReadString() {
            return Message.ReadString();
        }

        /// <summary>
        /// Lit un tableau d'octets en précisant sa taille dans le flux courant
        /// </summary>
        /// <param name="length">taille de la chaine à lire</param>
        /// <returns>Octets lus</returns>
        public byte[] ReadBytes(int length) {
            return Message.ReadBytes(length);
        }

        /// <summary>
        /// Lit un nom qualifié dans le flux courant
        /// </summary>
        /// <param name="source">tableau source</param>
        /// <param name="offset">décallage</param>
        /// <returns>Valeur lue</returns>
        public DNSName ReadDNSName() {
            DNSName ret = new DNSName();
            ret.Read(this);
            return ret;
        }

        #endregion

        #region Prise en charge du positionnement dans le flux de bytes
        public void Push() {
            Message.Push();
        }

        public void Push(long Position) {
            Message.Push(Position);
        }

        public void Pop() {
            Message.Pop();
        }

        public void Pop(int number) {
            for (int i = 0 ; i< number;i++)
                Message.Pop();
        }

        public void PopAll() {
            Message.PopAll();
        }

        public long Position {
            get { return Message.Position; }
            set { Message.Position = value; }
        }
        #endregion
    }
}
