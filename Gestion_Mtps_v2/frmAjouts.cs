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
        #endregion
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
