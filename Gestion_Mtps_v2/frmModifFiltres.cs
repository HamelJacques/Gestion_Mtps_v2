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
    public partial class frmModifFiltres : Form
    {
        #region DONNÉES MEMBRES
        private string m_Filtre;
        private string m_NomFiltreA_Modifier;
        #endregion
        #region CONSTRUCTEUR
        public frmModifFiltres(string filtre, string nomfiltreAmodifier)
        {
            InitializeComponent();
            InitFenetre(filtre, nomfiltreAmodifier);
        }


        #endregion

        #region MÉTHODES PRIVÉES
        private void InitFenetre(string filtre, string nomfiltreAmodifier)
        {
            m_Filtre = filtre;
            this.Text = "Modification d'un libellé de " + m_Filtre;
            this.BackColor = Color.Aquamarine;
            lblAncienNom.Text  = "Libellé actuel :";
            lblNouveauNom.Text = "Nouveau libellé :";
            txtAncienNom.Text=  nomfiltreAmodifier;

            btnSoumettre.Text = "Soumettre";
            btnSoumettre.BackColor = Color.LightSeaGreen;
            btnSoumettre.Enabled = false;
            btnFermer.Text = "Fermer";
            btnFermer.BackColor = Color.LightSteelBlue;
        }
        #endregion

        #region BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txtNouveauNom_KeyUp(object sender, KeyEventArgs e)
        {
            btnSoumettre.BackColor= Color.LightYellow;
            btnSoumettre.Enabled= true;
        }

        private void btnSoumettre_Click(object sender, EventArgs e)
        {
            // préparer un messagebox pour s'assurer que le changement est vraiment ce qui est souhaité
            DialogResult = MessageBox.Show("text","Caption",MessageBoxButtons.OKCancel ,MessageBoxIcon.Question);
        }
    }
}
