using System;
using System.Collections.Generic;
using System.Text;

namespace InternetCommands.DNSRequest
{
    public abstract class DNSElement
    {
        #region Gestion des types dns
        protected static Loader.Loader<DNSResourceDetails> ResourceDetailsLoader;
        protected static Loader.Index<DNSResourceDetails, ushort> DNSServiceNumber;
        public static Loader.Index<DNSResourceDetails, string> DNSServiceName;

        /// <summary>
        /// Charge une liste statique des DNSElement au démarage de la bibliothèque 
        /// </summary>
        static DNSElement() {
            //Recherche tous les descripteurs de types DNS 
            ResourceDetailsLoader = new Loader.Loader<DNSResourceDetails>();
            Type defaultType = typeof(DNSDefaultResourceDetails);
            ResourceDetailsLoader.AddType(defaultType);
            ResourceDetailsLoader.DefaultElement = defaultType.FullName;

            //Ajoute un index sur le nom des services
            DNSServiceName = ResourceDetailsLoader.CreateIndex<string>("Name");

            //ajoute un index sur le numéro des services
            DNSServiceNumber = ResourceDetailsLoader.CreateIndex<ushort>("Service");
        }

        /// <summary>
        /// Retourne un containeur d'enregistrement DNS par numéro de service
        /// </summary>
        /// <param name="Service">Numéro du service DNS</param>
        /// <returns>Containaire de détails de ressources</returns>
        protected static DNSResourceDetails CreateResourceDetails(ushort Service) {
            //TODO: ajouter la gestion des enregistrements inconnus
            return ResourceDetailsLoader.Create(DNSServiceNumber[Service]);
        }

        /// <summary>
        /// Retourne un containeur d'enregistrement DNS par nom de service
        /// </summary>
        /// <param name="Service">Nom du service DNS</param>
        /// <returns>Containaire de détails de ressources</returns>
        protected static DNSResourceDetails CreateResourceDetails(string Name) {
            return ResourceDetailsLoader.Create(DNSServiceName[Name]);
        }
        #endregion

        #region procédure de conversion d'une IP en chaine de caractères
        /// <summary>
        /// Converti une IP en string
        /// </summary>
        /// <param name="address">Adresse IP</param>
        /// <returns>Chaine représentant l'IP</returns>
        public string IPToString(System.Net.IPAddress address) {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                return address.ToString();
            } else if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                System.Text.StringBuilder Ret = new StringBuilder();
                byte[] addr = address.GetAddressBytes();
                Ret.Append((((int)addr[0x0] << 8) + (int)addr[0x1]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0x2] << 8) + (int)addr[0x3]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0x4] << 8) + (int)addr[0x4]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0x6] << 8) + (int)addr[0x7]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0x8] << 8) + (int)addr[0x9]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0xA] << 8) + (int)addr[0xB]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0xC] << 8) + (int)addr[0xD]).ToString("x"));
                Ret.Append(":");
                Ret.Append((((int)addr[0xE] << 8) + (int)addr[0xf]).ToString("x"));
                return Ret.ToString();
            }
            return "";
        }
        #endregion

        #region Procédure d'écriture et de lecture du DNSRequest sous-jaccent
        public abstract void Write(DNSRequest request);
        public abstract void Read(DNSRequest request);
        #endregion
    }
}
