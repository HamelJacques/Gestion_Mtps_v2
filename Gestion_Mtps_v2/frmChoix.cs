using Gestion_Mtps;
using System;
using System.CodeDom;
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
    public partial class frmChoix : Form
    {
        #region DONNÉES MEMBRES
        private Usager_v2 m_usager;
        private Choix m_Choix;
        private CBase m_maBD;
        private Ajouts m_Ajouts;
        #endregion
        #region CONSTRUCTEURS
        public frmChoix(ref Usager_v2 U, CBase bd)
        {
            InitializeComponent();
            m_usager = new Usager_v2();
            m_usager = U;
            m_maBD = bd;
            InitChoix();
        }
        #endregion
        #region MÉTHODES PRIVÉES
        private void InitChoix()
        {
            m_Choix = new Choix(ref m_maBD);
            m_Ajouts = new Ajouts();
            this.Text = " Choix pour " + ObtenirNomUsager();
            this.BackColor = Color.LightPink;
            this.StartPosition = FormStartPosition.CenterScreen;
            btnFermer.BackColor = Color.LightGreen;
            btnFermer.Text = "Fermer - retour à Ouverture - Changer d'usager";
            InitCategories();
            InitSousCategories();
            InitSites();
        }       
        private void InitCategories()
        {
            grbxCategories.Text = "Categories";
            grbxCategories.BackColor = Color.LightBlue;
            btnAjoutCatego.BackColor = Color.LightGreen;
            btnAjoutCatego.Text = "Ajout";
            m_usager.IdSousCategorie = 0;
            ListerCategories();
        }
        private void InitSousCategories()
        {
            grbxSousCategories.Text = "Sous catégories";
            grbxSousCategories.BackColor = Color.LightBlue;
            btnAjoutSousCatego.Text = "Ajouter";
            btnAjoutSousCatego.BackColor = Color.LightGreen;
            ListerSousCategories();
        }
        private void InitSites()
        {
            grbxSites.Text = "Sites";
            grbxSites.BackColor = Color.LavenderBlush;
            btnAjoutSite.Text = "Ajouter";
            btnAjoutSite.BackColor = Color.LightGreen;
            ListerLesSites();
        }
        private string ObtenirNomUsager()
        {
            return m_Choix.ObtenirNomUsager(m_usager.IdUsager);
        }
        private void ListerLesSites()
        {
            List<string> lst = new List<string>();
            lstBxSites.Items.Clear();
            lst = m_Choix.ObtenirListeSites(m_usager);
            lstBxSites.Items.AddRange(lst.ToArray());
        }
        private void ListerSousCategories()
        {
            List<string> lst = new List<string>();
            lst = m_Choix.ObtenirListeSousCategories(m_usager);
            lstBxSousCategories.Items.Clear();
            lstBxSousCategories.Items.AddRange(lst.ToArray());
        }
        private void ListerCategories()
        {
            List<string> lst = new List<string>();
            lst = m_Choix.ObtenirListeCategries(m_usager);
            lstBxCategories.Items.Clear();
            lstBxCategories.Items.AddRange(lst.ToArray());
            //return lst;
        }

        #region LES BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjoutCatego_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            // passer par la classe Ajouts pour ajouter une catégorie
            frmAjouts aj = new frmAjouts("Categorie", m_maBD, ref lst, ref m_usager);
            aj.ShowDialog();
            if(aj.AjoutOk)
            {
                ListerCategories();
            }
        }

        private void btnAjoutSousCatego_Click(object sender, EventArgs e)
        {
            // Vérifier si une catégorie est sélectionnée, forcer la sélection
            bool selectione = lstBxCategories.SelectedIndex >= 0;
            if (lstBxCategories.SelectedIndex >= 0)
            {
                List<string> lst = new List<string>();
                frmAjouts aj = new frmAjouts("SousCategorie", m_maBD, ref lst, ref m_usager);
                aj.ShowDialog();

                if (aj.AjoutOk)
                {
                    ListerSousCategories();
                }
                return;
            }

            MessageBox.Show("Vous devez sélectionner une catégorie", "Ajout de sous catégorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAjoutSite_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            // Vérifier si une sous-catégorie est sélectionnée, forcer la sélection
            bool selectione = lstBxSousCategories.SelectedIndex >= 0;
            if(m_usager.IdCategorie == 0)
            {
                message = "Vous devez sélectionner une catégorie pour poursuivre.";
                MessageBox.Show(message,"OUPS",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (m_usager.IdSousCategorie == 0)
                {
                    message = "Vous devez sélectionner une sous-catégorie pour poursuivre.";
                    MessageBox.Show(message, "OUPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    List<string> lst = new List<string>();

                    frmAjouts aj = new frmAjouts("Site", m_maBD, ref lst, ref m_usager);
                    aj.ShowDialog();
                }
            }
            //if (lstBxSousCategories.SelectedIndex >= 0)
            //{
            //    List<string> lst = new List<string>();

            //    frmAjouts aj = new frmAjouts("Site", m_maBD, ref lst, ref m_usager);
            //    aj.ShowDialog();
            //}
        }
        #endregion
        #region LES LISTBOXES
        private void lstBxCategories_Click(object sender, EventArgs e)
        {
            // lire la sélection
            try
            {
                string lecture = lstBxCategories.SelectedItem.ToString();
                m_usager.IdCategorie = m_Choix.ObtenirIdCategorie(lecture);

                // Afficher les sous catégories pour cet usager et la catégorie sélectionnée
                ListerSousCategories();
                ListerLesSites();
            }
            catch (Exception ex) { string msg = ex.Message.ToString(); }
        }
        private void lstBxSousCategories_Click(object sender, EventArgs e)
        {
            // lire la sélection
            try
            {
                if (!string.IsNullOrEmpty((string)lstBxSousCategories.SelectedItem))
                {
                    string lecture = lstBxSousCategories.SelectedItem.ToString();
                    //string lecture = lstBxSousCategories.SelectedItem.ToString();
                    m_usager.IdSousCategorie = m_Choix.ObtenirIdSousCategorie(lecture);
                    // vérifier si une catégorie est sélectionnée
                    // si non, déterminer à quelle catégorie appartient cette sous catégorie pour cet usager
                    if (m_usager.IdCategorie == 0)
                    {
                        m_usager.IdCategorie = m_Choix.ObtenirIdCategorie_UsagerSousCatego(m_usager);
                    }
                    ListerLesSites();
                }                
            }
            catch (NullReferenceException nre) { return; }
            catch (Exception ex) { string msg = ex.Message.ToString(); }
        }


        #endregion

        #endregion

        
    }
}
