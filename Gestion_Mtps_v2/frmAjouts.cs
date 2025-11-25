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
    public partial class frmAjouts : Form
    {
        #region CONSTRUCTEURS
        public frmAjouts()
        {
            InitializeComponent();
        }
        public frmAjouts(string type)
        {
            InitializeComponent();
            this.Text = type;
        }
        public frmAjouts(string type, CBase bd)
        {
            InitializeComponent();
            this.Text = type + " avec un objer BD";
            switch (type)
            {
                case "Usager":
                    InitAjouts(type);
                    ObtenirLesUsagers();
                    break;
            }
            
        }
        #endregion
        #region MÉTHODES PRIVÉES
        private void ObtenirLesUsagers()
        {
            Int32 nbU = 0;
        }
        private void InitAjouts(string type)
        {
            switch (type)
            {
                case "Usager":
                    lblTypeAjout.Text = type;
                    AjusteFenetreUsager();
                    break;
            }
            txtNouvelleValeur.Text = "";
        }
        private void AjusteFenetreUsager()
        {
            this.Width = 600;
            this.Height = 300;
            btnFermer.Width = 500;
            btnFermer.Top = 150;
            this.BackColor = Color.LightSeaGreen;
        }
        #endregion
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
