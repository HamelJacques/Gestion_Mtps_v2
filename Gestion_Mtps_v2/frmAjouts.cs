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
        private Usager_v2 m_Usager;
        private string m_Type;
        private Ajouts m_Ajouts;
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
        public frmAjouts(string type, CBase bd, ref List<string> lst, ref Usager_v2 U)
        {
            InitializeComponent();
            m_maBD = bd;
            m_Type = type;
            m_Usager = U;
            this.Text = type + " avec un objet BD";
            m_items = lst;

            InitAjouts(type);

        }
        #endregion
        #region MÉTHODES PRIVÉES
        //private void ObtenirLesUsagers()
        //{
        //    Int32 nbU = 0;
        //}
        private void InitAjouts(string type)
        {
            m_Ajouts = new Ajouts(ref m_maBD);
            lblTypeAjout.Text = type;
            switch (type)
            {
                case "Usager":
                    AjusteFenetreUsager();
                    break;
                case "Categorie":
                    AjusteFenetreCategories();
                    break;
            }
            txtNouvelleValeur.Text = "";
            btnFermer.Text = "Fermer";
            btnAjouter.Text = "Ajouter";
        }
        private void AjusteFenetreUsager()
        {
            this.Width = 600;
            this.Height = 300;
            grbxLstValsDispo.Visible = false;
            grbxMotPasseUsager.Text = "Mot de passe";
            btnFermer.Top = grbxMotPasseUsager.Top + grbxMotPasseUsager.Height+10;
            btnFermer.Left = txtNouvelleValeur.Left;
            btnFermer.Width = 500;
            btnFermer.Text = "Fermer";
            
            btnAjouter.Text = "Ajouter ";
            this.BackColor = Color.LightSeaGreen;
        }
        private void AjusteFenetreCategories()
        {
            this.Width = 600;
            this.Height = 300;
            grbxMotPasseUsager.Visible = false;
            grbxLstValsDispo.Text = "Valeurs disponibles";
            grbxLstValsDispo.BackColor = Color.LightSkyBlue;
            BackColor = Color.LightYellow;
            txtNouvelleValeur.Focus();
            txtNouvelleValeur.Select();
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
            // La vérification se fera dans Ajouts et retournera un code

            Int32 ret = m_Ajouts.Ajouter(m_Type, txtNouvelleValeur.Text, ref m_Usager);
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
