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
        public frmAjoutSiteInfos()
        {
            InitializeComponent();
            InitFenetre();
        }

        private void InitFenetre()
        {
            btnFermer.Text = "Fermer";
            btnSauvegarde.Text = "Sauvegarde";
            this.BackColor = Color.LightSalmon;
            btnSauvegarde.BackColor = Color.LightGreen;
            lblAdresse.Text = "Adresse:";
            lblIdentifiant.Text = "Identifiant:";
            lblMotPassse.Text = "Mot de passe:";
            lblNomSite.Text = "Nom du site:";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
