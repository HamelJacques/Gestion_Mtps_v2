using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    internal class Ajouts
    {
        private readonly CBase maBD;
        private readonly string type;
        private string text;
        public string messageRetour;
        #region CONSTRUCTEURS
        public Ajouts() { }

        public Ajouts(ref CBase maBD)
        {
            this.maBD = maBD;
            messageRetour = string.Empty;
        }

        public Ajouts(ref CBase maBD, string type) : this(ref maBD)
        {
            this.type = type;
        }

        public Ajouts(ref CBase maBD, string type, string text) : this(ref maBD, type)
        {
            this.text = text;
        }


        internal int Ajouter(string type, string text, ref Usager_v2 U)
        {
            bool ret = false;
            switch (type)
            {
                case "Usager":
                    ret = maBD.AjouterUsager_v2(text);
                    break;
                case "Categorie":
                    ret = maBD.AjouterCategorie_v2(text, U.IdUsager);
                    break;
                case "SousCategorie":
                    ret = maBD.ajouterSousCatgorie_v2(text, ref U, ref messageRetour);                    
                    break;
            }
            return Convert.ToInt32(ret);
        }
        #endregion
        #region MÉTHODES PUBLIQUES

        public void ObtenirListeCategories(ref List<string> lst, ref Usager_v2 U,  bool Moimeme = true)
        {
            //List<string> lst = new List<string>();
            maBD.ObtenirCategories(ref lst, U, Moimeme);
        }
        public void ObtenirListeSousCategories(ref List<string> lst, ref Usager_v2 U, bool Moimeme = true)
        {
            //List<string> lst = new List<string>();
            //maBD.ObtenirSousCategories(ref lst, U, Moimeme);
            maBD.ObtenirSousCategories(ref lst, U.IdUsager,U.IdCategorie, Moimeme);
        }
        #endregion
    }
}
