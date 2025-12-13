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


        internal bool Ajouter(string type, string text, ref Usager_v2 U)
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
            return ret;
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
            // Obtenir la liste des sous ctégories pour et usager et la catégorie sélectionnée
            // pour exclue ces valeurs de la liste des sous catégories disponibles
            maBD.ObtenirSousCategoriesPourAjouts(ref lst, U);
        }
        public void ObtenirListeSites(ref List<string> lst, ref Usager_v2 U, bool Moimeme = true)
        {
            //List<string> lst = new List<string>();
            maBD.ObtenirSites(ref lst, U, Moimeme);
        }
        #endregion
    }
}
