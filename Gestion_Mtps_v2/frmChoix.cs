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
        private Choix m_Choix;
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
            m_Choix = new Choix(ref m_maBD);
            this.Text = " Choix pour " + ObtenirNomUsager();
            this.BackColor = Color.LightPink;
            this.StartPosition = FormStartPosition.CenterScreen;
            btnFermer.BackColor = Color.LightGreen;
            btnFermer.Text = "Fermer - retour à Ouverture - Changer d'usager";
            InitCategories();
        }
        private void InitCategories()
        {
            grbxCategories.Text = "Categories";
            grbxCategories.BackColor = Color.LightBlue;
            btnAjoutCatego.BackColor = Color.LightGreen;
            btnAjoutCatego.Text = "Ajout";
        }
        private string ObtenirNomUsager()
        {
            return m_Choix.ObtenirNomUsager(m_usager.IdUsager);
        }

        private List<string> ListerCategories()
        {
            List<string> lst = new List<string>();
            return lst;
        }
        #endregion#

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjoutCatego_Click(object sender, EventArgs e)
        {
            // passer par la classe Choix pour ajouter une catégorie

        }
    }
}
