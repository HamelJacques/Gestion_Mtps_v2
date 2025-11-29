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
        #endregion
        #region CONSTRUCTEURS
        public Usager_v2()
        {
            IdUsager = 0;
        }


        #endregion
        #region PROPRIÉTÉS
        public int IdUsager { get => m_IdUsager; set => m_IdUsager = value; }
        #endregion
    }
}
