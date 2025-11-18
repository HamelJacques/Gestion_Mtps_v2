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
            ConnectBD();
            this.Text = string.Concat(m_Titre,"   ", O.ChExe);
            lblChBD.Text = O.ChBD;
            AjusteCouleurFenere();
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


    }
}
