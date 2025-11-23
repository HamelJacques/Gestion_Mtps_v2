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
    public partial class frmOuverture : Form
    {
        #region DONNÉES MEMBRES
        private string m_Titre;
        private List<string> m_lesUsagers;
        #endregion
        private Ouverture O;
        #region CONSTRUCTEUR
        public frmOuverture()
        {
            InitializeComponent();
            InitForm();
        }
        #endregion

        #region MÉTHODES PRIVÉES
        private void InitForm()
        {
            m_Titre = "Ouverture";
            this.Text = m_Titre;
            lblUsagers.Text = "Les usagers inscrits";
            btnAjout.Text = "Ajouter";
            m_lesUsagers = new List<string>();
            ConnectBD();
            this.Text = string.Concat(m_Titre,"   ", O.ChExe);
            lblChBD.Text = O.ChBD;
            AjusteCouleurFenere();
            AfficheUsagers();
        }

        private void AfficheUsagers()
        {
            lstUsagers.Items.AddRange (O.LstUsagers.ToArray());
        }

        private void TitreFenetre()
        {
            //if(O.m)
        }
        private void AjusteCouleurFenere()
        {
            this.BackColor = Color.LightPink;
        }
        private void ConnectBD()
        {
            try
            {
                O = new Ouverture();
                List<string> listUsagers = new List<string>();
                m_lesUsagers = O.LstUsagers;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AfficheMessErr(msg);
            }
        }
        private void AfficheMessErr(string err)
        {
            lblmessage.ForeColor = Color.Blue;
            lblmessage.Text = "Une erreur s'est produite. Voir application.log dans: " + O.ChExe;
            //
        }
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAjout_Click(object sender, EventArgs e)
        {
            frmAjouts A = new frmAjouts("Usager");
            A.ShowDialog();
            //O.AjoutUsager();
            //MessageBox.Show("En développement","Ajout d'un usager",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
