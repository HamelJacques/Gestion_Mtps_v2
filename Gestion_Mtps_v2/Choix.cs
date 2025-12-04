using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    internal class Choix
    {
        #region DONNÉES MEMBRES 
        private readonly CBase m_maBD;
        #endregion

        #region CONSTRUCTEURS
        public Choix( ref CBase bd) 
        {
            m_maBD = bd;
        }
        #endregion

        #region MÉTHODES PRIVÉES
        public string ObtenirNomUsager(int id)
        {
            return m_maBD.ObtenirNomUsager(id);
        }
        public List<string> ObtenirListeCategries(Usager_v2 U)
        {
            List<string> lst = new List<string>();
            m_maBD.ObtenirCategories(ref lst, U);
            return lst;
        }
        public List<string> ObtenirListeSousCategories(Usager_v2 U)
        {
            List<string> lst = new List<string>();
            m_maBD.ObtenirSousCategories(ref lst, U.IdUsager);
            return lst;
        }
        internal void AjouterUneCategorie(Usager_v2 m_usager)
        {            
            //throw new NotImplementedException();
        }

        internal int ObtenirIdCategorie(string lecture)
        {
            try
            {
                int id = 0;
                id = m_maBD.ObtenirIdCategorie(lecture);
                return id;
            }
            catch (Exception e)
            {
                //Logger l'erreur
                return -1;
            }
        }
        #endregion
    }
}
