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
        //private CBase m_LaBase;
        //private string m_CheminExe;
        //private string m_Chemin_BD;
        //private const string NOM_BD = "G_Mtps.accdb";
        private List<string> m_lesUsagers;
        private Usager_v2 m_UsagerSelectionne;
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
            m_UsagerSelectionne = new Usager_v2();
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
        //private void ObtenirCheminExe()
        //{
        //    m_CheminExe = AppContext.BaseDirectory;
        //    m_Chemin_BD = m_CheminExe + NOM_BD;
        //}
        private void AfficheUsagers()
        {
            lstUsagers.Items.Clear();
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
                //m_LaBase = new CBase(m_Chemin_BD);
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
            lblmessage.Text = "Une erreur s'est produite. Voir application.log dans: ConnectBD()" + Environment.NewLine + err;
            //
        }
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAjout_Click(object sender, EventArgs e)
        {
            frmAjouts A = new frmAjouts("Usager", O.LaBase, ref m_lesUsagers);
            A.ShowDialog();
            AfficheUsagers();
        }

        private void lstUsagers_DoubleClick(object sender, EventArgs e)
        {
            string selection = lstUsagers.SelectedItems[0].ToString();
            // Obtenir le id de la sélection
            Int32 isselect = O.ObtenirIdUsager(selection);
            if (isselect == 0)
            {
                MessageBox.Show("Faites un choix d'usager"); 
            }
            else
            {
                m_UsagerSelectionne.IdUsager = isselect;
            }
                MessageBox.Show("En développement" + Environment.NewLine + selection);
        }
    }
}
