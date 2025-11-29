using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.IO;
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
        private List<string> m_List_Usagers;
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
        public List<string> LstUsagers
        { get { return m_List_Usagers; }
            private set { m_List_Usagers = value;}
        }
        public CBase LaBase
        {
            get { return m_LaBase; }
        }


        #endregion
        #endregion
        #region MÉTHODES PRIVÉES    
        private void InitOuverture()
        {
            m_CheminExe = string.Empty;
            TestModifString("Chemin exe");
            ObtenirCheminExe();
            m_List_Usagers = new List<string>();
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

            // On remonte d'un niveau (Debug)
            string cheminBase = Directory.GetParent(m_CheminExe).FullName;
            cheminBase = Directory.GetParent(cheminBase).FullName;
            cheminBase = Path.Combine(cheminBase, "Base\\");

            //// On remonte d'un niveau (Debug) et on concatène "Base"
            //cheminBase = Path.Combine(
            //Directory.GetParent(m_CheminExe).FullName, "Base\\");


            m_Chemin_BD = cheminBase + NOM_BD;
        }
        private void TestModifString(string modifString)
        {
            m_CheminExe = modifString;
        }
        private void ObtenirLesUsagers()
        {
            LstUsagers = m_LaBase.ObtenirUsagers();
            
        }

        internal int ObtenirIdUsager(string selection)
        {
            int id = 0;
            id = m_LaBase.ObtenirIdUsager(selection);
            return id;
        }
        #endregion
    }

}
