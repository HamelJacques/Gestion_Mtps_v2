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
    public partial class frmMonInputBx : Form
    {
        public string MotSaisi;
        private enum Mode
        { 
            Ajout = 0,
            modif,
            verif
        }
        private Mode mode;
        public frmMonInputBx()
        {
            InitializeComponent();
            initFenetre();
        }

        private void initFenetre()
        {
            mode = Mode.verif;
            lblMessInput.Text = "Saisissez votre mot de passe";
            txtInput.Text = string.Empty;
            txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
            btnSoumettre.Text = "Soumettre";
            MotSaisi = txtInput.Text;
        }

        private void btnSoumettre_Click(object sender, EventArgs e)
        {
            MotSaisi = txtInput.Text;
            this.Close();
        }
    }
}
