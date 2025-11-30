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
        #endregion
    }
}
