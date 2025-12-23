using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    public class Usager_v2
    {
        #region DONNÉES MEMBRES
        private int m_IdUsager;
        private int m_IdCategorie;
        private int m_IdSousCategorie;
        private int m_IdSite;
        #endregion
        #region CONSTRUCTEURS
        public Usager_v2()
        {
            IdUsager = 0;
            IdCategorie = 0;
            IdSousCategorie = 0;
            IdSite = 0;
        }


        #endregion
        #region PROPRIÉTÉS
        public int IdUsager { get => m_IdUsager; set => m_IdUsager = value; }
        public int IdCategorie { get => m_IdCategorie; set => m_IdCategorie = value; }
        public int IdSousCategorie { get => m_IdSousCategorie; set => m_IdSousCategorie = value; }
        public int IdSite { get => m_IdSite; set => m_IdSite = value; }
        #endregion
    }
}
