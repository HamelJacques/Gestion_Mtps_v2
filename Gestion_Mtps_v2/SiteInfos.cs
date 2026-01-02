using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    internal class SiteInfos
    {
        #region DONNÉES MEMBRES
        private Int32 m_Id;
        private string m_NomSite;
        private string m_AdresseSite;
        private string m_Identifiant;
        private string m_MtPss;
        #endregion
        #region PROPRIÉTÉS
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        public string NomSite
        {
            get { return m_NomSite; }
            set { m_NomSite = value; }
        }


        #endregion
        #region CONSTRUCTEURS
        public SiteInfos() 
        { 
        }
        #endregion
    }
}
