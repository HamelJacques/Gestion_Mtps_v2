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
        public bool AjoutOk = false; 
        private enum UneDonnee 
        {
            Usager =1,
            Categorie,
            SousCategorie,
            Site
        }

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
            lblerr.Text = string.Empty;
            m_maBD = bd;
            m_Type = type;
            m_Usager = U;
            this.Text = type + " avec un objet BD";
            m_items = lst;

            InitAjouts(type);
            this.DialogResult = DialogResult.OK;

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
                    m_Ajouts.ObtenirListeCategories(ref m_items, ref m_Usager, false);
                    AfficherListeItems();
                    break;
                case "SousCategorie":
                    AjusteFenetreSousCategories();
                    m_Ajouts.ObtenirListeSousCategories(ref m_items,ref m_Usager, false);
                    AfficherListeItems();
                    break;
                case "Site":
                    AjusteFenetreSite();
                    m_Ajouts.ObtenirListeSites(ref m_items,ref m_Usager,false);
                    AfficherListeItems();
                    break;
            }
            txtNouvelleValeur.Text = "";
            btnFermer.Text = "Fermer";
            btnAjouter.Text = "Ajouter";
            btnAjouter.Enabled = false;
        }

        private void AfficherListeItems()
        {
            lstValsDispo.Items.Clear();
            lstValsDispo.Items.AddRange(m_items.ToArray());
        }
        private void AjusteFenetreUsager()
        {
            this.Width = 600;
            this.Height = 300;            
            
            btnFermer.Top = grbxMotPasseUsager.Top + grbxMotPasseUsager.Height+10;
            btnFermer.Left = txtNouvelleValeur.Left;
            btnFermer.Width = 500;
            btnFermer.Text = "Fermer";
            
            btnAjouter.Text = "Ajouter ";
            this.BackColor = Color.LightSeaGreen;

            txtNouvelleValeur.Focus();
            txtNouvelleValeur.Select();

            PlaceGroupBoxes(UneDonnee.Usager);
            PlaceBoutons(UneDonnee.Usager);
        }
        private void PlaceGroupBoxes(UneDonnee donnee)
        {
            switch (donnee) 
            { 
                case (UneDonnee)1:
                    grbxLstValsDispo.Visible = false;
                    grbxMotPasseUsager.Text = "Mot de passe";
                    break;
                    case (UneDonnee)2:
                    grbxMotPasseUsager.Visible = false;
                    grbxLstValsDispo.Text = "Valeurs disponibles";
                    grbxLstValsDispo.BackColor = Color.LightSkyBlue;
                    break;
                    case(UneDonnee)3:
                    grbxMotPasseUsager.Visible = false;
                    grbxLstValsDispo.Text = "Valeurs disponibles";
                    grbxLstValsDispo.BackColor = Color.LightSalmon;
                    break;
                case (UneDonnee)4:
                    grbxMotPasseUsager.Visible = false;
                    grbxLstValsDispo.Text = "Valeurs disponibles";
                    grbxLstValsDispo.BackColor = Color.LightCoral;
                    break;
            }
        }
        private void AlimenteGroupBox(UneDonnee donnee)
        {
            switch (donnee)
            {
                case (UneDonnee)1:
                    break;
                    case (UneDonnee)2:
                    m_items.Clear();
                    break;
                case (UneDonnee)3:
                    m_items.Clear();
                    break;
                case (UneDonnee)4:
                    m_items.Clear();
                    break;
            }
        }
        private void PlaceBoutons(UneDonnee quoi)
        {
            btnAjouter.Left = txtNouvelleValeur.Left;
            btnAjouter.Top = txtNouvelleValeur.Top + 100;
            btnFermer.Left = btnAjouter.Left;
            btnFermer.Top = btnAjouter.Top + btnAjouter.Height + 15;
            btnAjouter.BackColor = Color.LightGreen;
            btnFermer.BackColor = Color.LightGreen;
        }
        private void AjusteFenetreCategories()
        {
            this.Width = 600;
            this.Height = 300;
            
            BackColor = Color.LightYellow;
            txtNouvelleValeur.Focus();
            txtNouvelleValeur.Select();

            AlimenteGroupBox(UneDonnee.Categorie);
            PlaceGroupBoxes(UneDonnee.Categorie);
            PlaceBoutons(UneDonnee.Categorie);
        }
        private void AjusteFenetreSousCategories()
        {
            this.Width = 600;  
            this.Height = 300;                              
            BackColor = Color.LightCyan;

            txtNouvelleValeur.Select();

            AlimenteGroupBox(UneDonnee.SousCategorie);
            PlaceGroupBoxes(UneDonnee.SousCategorie);
            PlaceBoutons(UneDonnee.SousCategorie);
        }
        private void AjusteFenetreSite()
        {
            this.Width = 600;
            this.Height = 310;
            BackColor = Color.Yellow;

            txtNouvelleValeur.Select();
            AlimenteGroupBox(UneDonnee.Site);
            PlaceGroupBoxes(UneDonnee.Site);
            PlaceBoutons(UneDonnee.Site);
        }

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
            // La vérification se fera dans Ajouts et retournera un code

            AjoutOk = m_Ajouts.Ajouter(m_Type, txtNouvelleValeur.Text, ref m_Usager);
            if (AjoutOk) 
            {
                frmTimer tmr = new frmTimer();
                tmr.ShowDialog();
                this.Close();
            }
            else
            {
                lblerr.Text = "ERREUR! Vérifier le fichier de log";
            }
        }

        private void txtNouvelleValeur_KeyUp(object sender, KeyEventArgs e)
        {
            //grbxMotPasseUsager.Text = txtNouvelleValeur.TextLength.ToString();
            btnAjouter.Text = "Ajouter " + txtNouvelleValeur.Text;
        }
        private void txtNouvelleValeur_TextChanged(object sender, EventArgs e)
        {
            btnAjouter.Enabled = txtNouvelleValeur.Text.Length > 0;
        }


        #endregion

        private void lstValsDispo_DoubleClick(object sender, EventArgs e)
        {
            txtNouvelleValeur.Text = (string)lstValsDispo.SelectedItem;
        }
    }
}
