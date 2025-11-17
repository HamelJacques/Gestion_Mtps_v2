using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    internal class Ouverture
    {
        #region DONNÉES MEMBRES
        private string m_CheminExe;
        private string m_Chemin_BD;
        private CBase m_LaBase;
        private const string NOM_BD = "G_Mtps.accdb";
        #endregion
        #region CONSTRUCTEURS
        public Ouverture() 
        {
            InitOuverture();
        }
        #region PROPRIÉTÉS
        public string ChExe
        {
            get { return m_CheminExe; }
            private set { m_CheminExe = value?.Trim(); } // exemple : on nettoie les espaces
        }
        public string ChBD
        {
            get { return m_Chemin_BD; }
            private set { m_Chemin_BD = value?.Trim(); } 
        }

        #endregion
        #endregion
        #region MÉTHODES PRIVÉES    
        private void InitOuverture()
        {
            m_CheminExe = string.Empty;
            TestModifString("Chemin exe");
            ObtenirCheminExe();
            Init_LaBD();
            ObtenirLesUsagers();
        }

        private void Init_LaBD()
        {
            try
            {
                m_LaBase = new CBase(m_Chemin_BD);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            //throw new NotImplementedException();
        }

        private void ObtenirCheminExe()
        {
            m_CheminExe = AppContext.BaseDirectory;
            m_Chemin_BD = m_CheminExe + NOM_BD;
        }
        private void TestModifString(string modifString)
        {
            m_CheminExe = modifString;
        }
        private void ObtenirLesUsagers()
        {
            List<string> list = new List<string>();
            list = m_LaBase.ObtenirUsagers();
        }
        #endregion
    }

}
