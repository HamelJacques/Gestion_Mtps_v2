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
    public partial class frmAjoutSiteInfos : Form
    {
        private Usager_v2 usager;
        private CBase maBD;
        private enum Mode
        {
            Ajout = 0,
            Modif
        }
        private enum UneDonnee
        {
            Usager = 1,
            Categorie,
            SousCategorie,
            Site
        }

        public frmAjoutSiteInfos(ref Usager_v2 m_usager)
        {
            InitializeComponent();
            //InitFenetre();
        }

        public frmAjoutSiteInfos(ref Usager_v2 usager, ref CBase maBD, FormStartPosition pos, int mode)
        {
            this.usager = usager;
            this.maBD = maBD;
            InitializeComponent();
            InitFenetre(pos);
        }

        private void InitFenetre(FormStartPosition pos)
        {
            btnFermer.Text = "Fermer";
            btnSauvegarde.Text = "Sauvegarde";
            this.BackColor = Color.LightSalmon;
            btnSauvegarde.BackColor = Color.LightGreen;
            lblAdresse.Text = "Adresse:";
            lblIdentifiant.Text = "Identifiant:";
            lblMotPassse.Text = "Mot de passe:";
            lblNomSite.Text = "Nom du site:";
            this.StartPosition = pos;
        }
        #region LES BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSauvegarde_Click(object sender, EventArgs e)
        {
            //Je veux vérifier si on est en more ajout ou en mode modif
            // puis appeler CBase en conséquence
        }
        #endregion
    }
}
