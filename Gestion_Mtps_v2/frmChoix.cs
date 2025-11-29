using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Mtps_v2
{
    public partial class frmChoix : Form
    {
        #region DONNÉES MEMBRES
        private Usager_v2 m_usager;
        private CBase m_maBD;
        #endregion
        #region CONSTRUCTEURS
        public frmChoix(ref Usager_v2 U, CBase bd)
        {
            InitializeComponent();
            m_usager = new Usager_v2();
            m_usager = U;
            m_maBD = bd;
            InitChoix();
        }
        #endregion
        #region MÉTHODES PRIVÉES
        private void InitChoix()
        {
            this.Text = " Choix pour " + ObtenirNomUsager();
        }
        private string ObtenirNomUsager()
        {
            return m_maBD.ObtenirNomUsager(m_usager.IdUsager);
        }
        #endregion#
    }
}
