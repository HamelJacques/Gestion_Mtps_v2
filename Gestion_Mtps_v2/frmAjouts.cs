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
        #region DONNÉES MEMBRES
        private List<string> m_items = new List<string>();
        private CBase m_maBD;
        private string m_Type;
        #endregion
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
                    //ObtenirLesUsagers();
                    break;
            }
            
        }
        public frmAjouts(string type, CBase bd, ref List<string> lst)
        {
            InitializeComponent();
            m_maBD = bd;
            m_Type = type;
            this.Text = type + " avec un objet BD";
            m_items = lst;
            switch (type)
            {
                case "Usager":
                    InitAjouts(type);
                    //ObtenirLesUsagers();
                    break;
            }
        }
        #endregion
        #region MÉTHODES PRIVÉES
        //private void ObtenirLesUsagers()
        //{
        //    Int32 nbU = 0;
        //}
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

            grbxMotPasseUsager.Text = "Mot de passe";
            btnFermer.Top = grbxMotPasseUsager.Top + grbxMotPasseUsager.Height+10;
            btnFermer.Left = txtNouvelleValeur.Left;
            btnFermer.Width = 500;
            btnFermer.Text = "Fermer";
            
            btnAjouter.Text = "Ajouter ";
            this.BackColor = Color.LightSeaGreen;
        }
        #endregion
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // vérifier si la valeur existe déjà dans la liste

            bool valeurExiste = m_items.Contains(txtNouvelleValeur.Text);
            // Récolter la valeur et faire un trim pour elnever les espaces
            string nom = txtNouvelleValeur.Text;

            // appeler la Classe Ajouts avec la valeur
            if (!valeurExiste)
            {
            Ajouts ajouts = new Ajouts(ref m_maBD); //, m_Type,txtNouvelleValeur.Text);
            // La vérification se fera dans Ajouts et retournera un code

            Int32 ret = ajouts.Ajouter(m_Type, txtNouvelleValeur.Text);
            }

                MessageBox.Show("En développement");
        }

        private void txtNouvelleValeur_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNouvelleValeur_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtNouvelleValeur_KeyUp(object sender, KeyEventArgs e)
        {
            //grbxMotPasseUsager.Text = txtNouvelleValeur.TextLength.ToString();
            btnAjouter.Text = "Ajouter " + txtNouvelleValeur.Text;
        }
    }
}
