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
        internal List<string> ObtenirListeSites(Usager_v2 m_usager)
        {
            List<string> lst = new List<string>();
            m_maBD.ObtenirSites(ref lst, m_usager);
            return lst;
//            throw new NotImplementedException();
        }
        public List<string> ObtenirListeSousCategories(Usager_v2 U)
        {
            List<string> lst = new List<string>();
            m_maBD.ObtenirListeSousCategories (ref lst, U);
            //m_maBD.ObtenirSousCategories(ref lst, U.IdUsager);
            return lst;
        }
        internal List<int> ObtenirListeIdInfos(Usager_v2 m_usager)
        {
            List<Int32> lst = new List<Int32>();
            m_maBD.ObtenirListeIdInfos(ref lst, m_usager);
            return lst;
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
        internal int ObtenirIdSousCategorie(string lecture)
        {
            try
            {
                int id = 0;
                id = m_maBD.ObtenirIdSousCategorie(lecture);
                return id;
            }
            catch (Exception e)
            {
                //Logger l'erreur
                return -1;
            }
        }
        internal int ObtenirIdSite(string lecture)
        {

            try
            {
                int id = 0;
                id = m_maBD.ObtenirIdSite(lecture);
                return id;
            }
            catch (Exception e)
            {
                //Logger l'erreur
                return -1;
            }
        }

        internal int ObtenirIdCategorie_UsagerSousCatego(Usager_v2 U)
        {
            try
            {
                int id = 0;
                id = m_maBD.ObtenirIdCategorie_UsagerSousCatego(U);
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
