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
            O= new Ouverture();
            this.Text = string.Concat(m_Titre,"   ", O.ChExe);
        }
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
