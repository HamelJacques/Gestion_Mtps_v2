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

        #endregion
        #endregion
        #region MÉTHODES PRIVÉES    
        private void InitOuverture()
        {
            m_CheminExe = string.Empty;
            TestModifString("Chemin exe");
            ObtenirCheminExe();
        }
        private void ObtenirCheminExe()
        {
            m_CheminExe = AppContext.BaseDirectory;
        }
        private void TestModifString(string modifString)
        {
            m_CheminExe = modifString;
        }
        #endregion
    }

}
