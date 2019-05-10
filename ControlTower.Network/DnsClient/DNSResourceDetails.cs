using System;
using System.Collections.Generic;
using System.Text;

namespace InternetCommands.DNSRequest
{
    public abstract class DNSResourceDetails : DNSElement
    {
        internal DNSResourceRecord resourceRecord = null;

        /// <summary>
        /// Renvoi le nom du service défini dans la RFC
        /// </summary>
        public static string Name { get {throw new Exception("Not implemented");} }
        /// <summary>
        /// Renvoi le numéro du service défini dans la RFC
        /// </summary>
        public static ushort Service { get{throw new Exception("Not implemented");} }

        public string DNSType { get { return this.GetType().Name; } }

        /// <summary>
        /// Renvoi la représentation sous forme de chaine de l'enregistrement
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();

        /// <summary>
        /// Procédure d'execution de la lecture de l'enregistrement
        /// </summary>
        /// <param name="request">Objet requête</param>
        /// <param name="Length">Longueur de l'enregistrement</param>
        public override void Read(DNSRequest request) {}

        /// <summary>
        /// Procédure d'execution de la lecture de l'enregistrement
        /// </summary>
        /// <param name="request">Objet requête</param>
        /// <param name="Length">Longueur de l'enregistrement</param>
        public abstract void Read(DNSRequest request, int Length);
    }
}
