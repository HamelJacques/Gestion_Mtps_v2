using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Mtps_v2
{
    
    internal class AjoutSiteInfos
    {
        #region DONNÉES MEMBRES
        
        #endregion
        public AjoutSiteInfos() 
        {
            //m_siteInfos = new SiteInfos();
        }
        public bool AjouterNouveau(ref Usager_v2 usager, ref CBase BD, ref SiteInfos m_siteInfos)
        {
            try
            {
                bool ret = BD.AjouterCombinaisonSecret(usager, m_siteInfos);
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                throw;
            }
            return false;
        }
       
    }
}
