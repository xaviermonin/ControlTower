using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Loader
{
    public class Loader<BaseClass> 
    {
        private Dictionary<string, Type> creatable;
        private Type BaseType;
        private string defaultElement;

        #region constructeurs

        /// <summary>
        /// Créé un chargeur de classe
        /// </summary>
        public Loader() {
            this.BaseType = typeof(BaseClass);
            creatable = new Dictionary<string, Type>();

            AddType(typeof(RFC1035.A));
            AddType(typeof(RFC1035.PTR));
            AddType(typeof(RFC1035.INFO));
            AddType(typeof(RFC1035.MX));
            AddType(typeof(RFC1035.TXT));
            AddType(typeof(RFC1035.CNAME));
            /*AddType(typeof(RFC1035.MB));
            AddType(typeof(RFC1035.MD));
            AddType(typeof(RFC1035.MF));
            AddType(typeof(RFC1035.MG));
            AddType(typeof(RFC1035.MINFO));
            AddType(typeof(RFC1035.NULL));
            AddType(typeof(RFC1035.NS));
            AddType(typeof(RFC1035.SOA));*/
        }

        #endregion

        #region gestion des types

        /// <summary>
        /// Ajoute un type
        /// </summary>
        /// <param name="type">Type à ajouter</param>
        public void AddType(Type type) {
            //vérifie que le type n'est pas une interface ou une classe abstraite
            if (!type.IsClass || type.IsInterface || type.IsAbstract) return;
            //Vérifie que le type dérive bien de la classe de base
            if (!IsBasedOn(type, BaseType)) return;
            //Récupère la valeur clef (nom de la classe si le nom est null)
            string key = type.FullName;

            try {
                Type oldType = this[key];
                if (oldType != null)
                if (OnIndexChange != null)
                        OnIndexChange.Invoke(this, new IndexChangeEventArg(IndexChangeEventArg.ChangeType.Created, oldType));
            } catch {
            }

            //inscrit la classe dans la liste
            creatable[key] = type;

            if (OnIndexChange != null)
                OnIndexChange.Invoke(this, new IndexChangeEventArg(IndexChangeEventArg.ChangeType.Created, type));
        }

        /// <summary>
        /// Ajoute un type
        /// </summary>
        /// <param name="Path">Chemin de l'assembly contenant la classe</param>
        /// <param name="ClassName">Nom de la classe</param>
        private void AddType(string Path, string ClassName) {
            //Charge l'assembly
            Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(Path));
            //charge le type particulier
            Type type = assembly.GetType(ClassName);
            //Ajoute le type
            AddType(type);

        }

        /// <summary>
        /// Retire un type de la liste
        /// </summary>
        /// <param name="Id">Clef du type à enlever</param>
        public void RemoveType(string Id) {
            this.OnIndexChange(this, new IndexChangeEventArg(IndexChangeEventArg.ChangeType.Deleted, this[Id]));
            creatable.Remove(Id);
        }                                                        


        public Type this[string Key] {
            get { return creatable[Key]; }
        }
        #endregion

        #region divers
        /// <summary>
        /// Défini une classe par défaut si la classe recherchée n'existe pas
        /// </summary>
        public string DefaultElement {
            get { return defaultElement; }
            set { defaultElement = value; }
        }

        /// <summary>
        /// Vérifie si une classe est basée ou dérivée d'un type particulier
        /// </summary>
        /// <param name="TestType">Type à tester</param>
        /// <param name="BaseType">Référence</param>
        /// <returns></returns>
        private bool IsBasedOn(Type TestType, Type BaseType) {
            if (TestType.IsSubclassOf(BaseType)) return true;
            if (TestType.FullName == BaseType.FullName) return true;
            if (Type.Equals(TestType, typeof(System.Object))) return false;
            return IsBasedOn(TestType.BaseType, BaseType);
        }
        #endregion

        #region Invocation d'élements statiques
        public object Invoke(string Key, string CommandName, params object[] parameters) {
            Type type = creatable[Key];
            return type.InvokeMember(CommandName, BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy | BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public, null, null, parameters);
        }
        #endregion

        #region Création d'index
        /// <summary>
        /// Modèle de fonction appelée lors d'une modification d'index
        /// </summary>
        /// <param name="sender"></param>
        internal delegate void ChangedIndex(Loader<BaseClass> sender, IndexChangeEventArg e);

        /// <summary>
        /// Evenement qui s'exécute lorsqu'un type a été rajouté
        /// </summary>
        event ChangedIndex OnIndexChange;

        /// <summary>
        /// Créé un index à partir d'une valeur statique du type
        /// </summary>
        /// <typeparam name="TKey">Type de la clef retournée</typeparam>
        /// <param name="KeyName">Nom de la clef retrounée</param>
        /// <returns>Index</returns>
        public Index<BaseClass, TKey> CreateIndex<TKey>(string KeyName, params Object[] parameters) {
            Index<BaseClass, TKey> ret = new Index<BaseClass, TKey>(KeyName, parameters);
            OnIndexChange +=new ChangedIndex(ret.IndexChanged);
            foreach (KeyValuePair<string,Type> type in this.creatable) {
                TKey key = (TKey)type.Value.InvokeMember(KeyName, BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy | BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public, null, null, null);
                ret[key] = type.Key;
            }
            return ret;
        }

        #endregion

        #region creation de types
        /// <summary>
        /// Créé une instance de l'élément demandé, s'il n'existe pas, créé une instance de l'élément par défaut.
        /// </summary>
        /// <param name="Id">Identifiant de l'élément à créer</param>
        /// <param name="parameters">Paramètres du constructeur</param>
        /// <returns>Objet de la classe de base</returns>
        public BaseClass Create(string Id, params object[] parameters) {
            object Obj;
            try {
                Obj = Activator.CreateInstance(creatable[Id], parameters);
            } catch {
                try {
                    Obj = Activator.CreateInstance(creatable[defaultElement], parameters);
                } catch {
                    throw new System.Reflection.ReflectionTypeLoadException(null, null, "Impossible de créer l'objet, la clef n'existe pas");
                }
            }
            return (BaseClass)Obj;
        }

        #endregion
    }

    internal class IndexChangeEventArg : EventArgs
    {
        /// <summary>
        /// Type de changement constaté
        /// </summary>
        public enum ChangeType
        {
            Created,
            Deleted
        }

        /// <summary>
        /// Constructeur avec valeurs
        /// </summary>
        /// <param name="Change">Changement effectué</param>
        /// <param name="Key">Clef sur laquelle s'effectue ce changement</param>
        public IndexChangeEventArg(ChangeType Change, Type type) {
            this.Change = Change;
            this.type = type;
        }

        public ChangeType Change;
        public Type type;
    }

    /// <summary>
    /// Créé un nouvel index pour la librairie de type
    /// </summary>
    /// <typeparam name="BaseClass"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class Index<BaseClass, TKey> : Dictionary<TKey, string>
    {
        private string IndexKey;
        private object[] parameters;

        private Index() {}

        /// <summary>
        /// Créé un objet index, n'est accessible que par le loader
        /// </summary>
        /// <param name="IndexKey"></param>
        /// <param name="parameters"></param>
        internal Index(string IndexKey, object[] parameters) {
            this.IndexKey = IndexKey;
            this.parameters = parameters;
        }

        /// <summary>
        /// Modification dynamique de l'index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void IndexChanged(Loader<BaseClass> sender, IndexChangeEventArg e) {
            TKey key = (TKey)e.type.InvokeMember(IndexKey, BindingFlags.InvokeMethod | BindingFlags.FlattenHierarchy | BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public, null, null, parameters);
            if (e.Change == IndexChangeEventArg.ChangeType.Created) {
                this[key] = e.type.Name;
            } else {
                this.Remove(key);
            }

        }

        /// <summary>
        /// Modification de l'indexeur
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new string this[TKey index] {
            get { try { return base[index]; } catch { return ""; } }
            set { base[index] = value; }
        }


    }
}
