using Gestion_Mtps;
using System;
using System.Collections.Generic;
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
        private string m_CheminLog;
        private Usager_v2 m_usager;
        private Choix m_Choix;
        private CBase m_maBD;
        //private Ajouts m_Ajouts;
        private List<SiteInfos> m_lstSiteInfos;
        private int m_NumSiteEnModif;
        private enum Mode
        {
            Ajout = 0,
            Modif
        }
        #endregion
        #region CONSTRUCTEURS
        public frmChoix(ref Usager_v2 U, CBase bd, string chlog)
        {
            InitializeComponent();
            m_usager = new Usager_v2();
            m_usager = U;
            m_maBD = bd;
            m_CheminLog = chlog;
            m_lstSiteInfos = new List<SiteInfos>();
            InitChoix();
        }
        #endregion
        #region MÉTHODES PRIVÉES
        private void InitChoix()
        {
            m_Choix = new Choix(ref m_maBD);
            //m_Ajouts = new Ajouts();
            this.Text = " Choix pour " + ObtenirNomUsager();
            this.BackColor = Color.LightPink;
            this.StartPosition = FormStartPosition.CenterScreen;
            btnFermer.BackColor = Color.LightGreen;
            btnFermer.Text = "Fermer - retour à Ouverture - Changer d'usager";
            InitCategories();
            InitSousCategories();
            InitSites();
            InitInfoSites();
        }       
        private void InitCategories()
        {
            grbxCategories.Text = "Categories";
            grbxCategories.BackColor = Color.LightBlue;
            btnAjoutCatego.BackColor = Color.LightGreen;
            btnAjoutCatego.Text = "Ajouter";
            m_usager.IdSousCategorie = 0;
            ListerCategories();
        }
        private void InitSousCategories()
        {
            grbxSousCategories.Text = "Sous catégories";
            grbxSousCategories.BackColor = Color.LightCyan;
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
        private void InitInfoSites()
        {
            grbxInfosSites.Text = "Informations";
            grbxInfosSites.BackColor = Color.Yellow;
            btnAjoutInfos.Text = "Ajouter";
            btnAjoutInfos.BackColor = Color.LightGreen;
            btnModifInfos.Text = "Modifier";
            btnModifInfos.BackColor = Color.LemonChiffon;
            ActiveBtns();
            InitDatagridInfos();
            // Lire jctTblInfos pour voir si on a au moins une ligne pour l'usager
            // lister les IdInfos en vue d'obtenir la liste correspondnte dans la table tblInfos
            ListerLesIdInfos();
            // Lister les informatons de la table tblInfos ayant les Ids de la liste des m_lstInfoSites
            ListerLesInfosSites();
        }
        private void ActiveBtns()
        {
            // Pour ajouter un ensemble d'informations, on doit avoir les 4 niveaux de sélectionnés
            btnAjoutInfos.Enabled = (m_usager.IdUsager > 0 
                && m_usager.IdCategorie > 0 && m_usager.IdSousCategorie > 0 && m_usager.IdSite > 0);

            btnModifInfos.Enabled=false;
        }
        private void InitDatagridInfos()
        {
            dgInfos.Columns[0].Visible = false;
        }
        private string ObtenirNomUsager()
        {
            return m_Choix.ObtenirNomUsager(m_usager.IdUsager);
        }
        private void ListerLesIdInfos()
        {
            List<Int32 > lst = new List<Int32>();
            lst = m_Choix.ObtenirListeIdInfos(m_usager);
        }
        private void ListerLesSites()
        {
            List<string> lst = new List<string>();
            lstBxSites.Items.Clear();
            lst = m_Choix.ObtenirListeSites(m_usager);
            lstBxSites.Items.AddRange(lst.ToArray());
        }
        private void ListerLesInfosSites()
        {
            List<string> lst = new List<string>();
            m_lstSiteInfos = new List<SiteInfos>();
            dgInfos.Rows.Clear();
            txtInfosSupp.Text = string.Empty;
            //dgInfos.Columns.Clear();

            m_Choix.ObtenirLesSitesInfos(ref m_lstSiteInfos, m_usager);
            AfficherLesInfosSites();
        }
        private void AfficherLesInfosSites()
        {
            dgInfos.Rows.Clear();
            foreach(SiteInfos siteInfo in m_lstSiteInfos)
            {
                dgInfos.Rows.Add(
                    siteInfo.Id.ToString(),
                    siteInfo.NomSite,
                    siteInfo.Adresse,
                    siteInfo.Identifiant,
                    siteInfo.MotPass
                    );
            }
            //dgInfos.DataSource = m_lstSiteInfos;

            //dgInfos.Columns["IdInfos"].HeaderText = "Id";
            //dgInfos.Columns["IdInfos"].Width = 25;
            dgInfos.Columns["NomSite"].HeaderText = "Nom du site";
            dgInfos.Columns["NomSite"].Width = 150;
            dgInfos.Columns["Adresse"].Width = 230;

            dgInfos.Columns["Identifiant"].Width = 225; 
            dgInfos.Columns["MotPass"].Width = 225;
            dgInfos.Columns["MotPass"].HeaderText = "Mot de passe";

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
            this.DialogResult = DialogResult.OK;
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
        }
        private void btnAjoutInfos_Click(object sender, EventArgs e)
        {
            // On a un usager, on veux ajouter une ligne de jctTblInfos et une ligne tblInfos
            // J'aurai besoin d'iune fenêtre frmAjoutSiteInfos
            frmAjoutSiteInfos AjoutSiteInfos = new frmAjoutSiteInfos(ref m_usager, ref m_maBD, this.StartPosition,(int)Mode.Ajout, m_CheminLog);
            AjoutSiteInfos .ShowDialog();
            
        }
        private void btnModifInfos_Click(object sender, EventArgs e)
        {
            // appeler la fenêtre AjoutSiteInfos en mode modification
            frmAjoutSiteInfos ModifSiteInfos = new frmAjoutSiteInfos(ref m_usager, ref m_maBD, this.StartPosition, (int)Mode.Modif, m_CheminLog, m_NumSiteEnModif);
            ModifSiteInfos.ShowDialog();
        }

        #endregion
        #region LES LISTBOXES
        private void lstBxCategories_Click(object sender, EventArgs e)
        {
            // lire la sélection
            try
            {
                if (lstBxCategories.SelectedItem != null)
                {
                    string lecture = lstBxCategories.SelectedItem.ToString();
                    m_usager.IdCategorie = m_Choix.ObtenirIdCategorie(lecture);
                    m_usager.IdSousCategorie = 0;
                    m_usager.IdSite = 0;

                    // Afficher les sous catégories pour cet usager et la catégorie sélectionnée
                    ListerSousCategories();
                    ListerLesSites();
                    ListerLesInfosSites();
                    ActiveBtns();
                }
                else
                { // Aucun item sélectionné
                }                
            }
            catch (Exception ex) { 
                string msg = ex.Message.ToString();
                Logger lg = new Logger(ex.ToString(), m_CheminLog);
            }
        }
        private void lstBxSousCategories_Click(object sender, EventArgs e)
        {
            m_usager.IdSite = 0;
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
                    ListerLesInfosSites();
                    ActiveBtns();
                }                
            }
            catch (NullReferenceException nre) { Logger lg = new Logger(nre.ToString(), m_CheminLog); }
            catch (Exception ex) { 
                string msg = ex.Message.ToString();
                Logger lg = new Logger(ex.ToString(), m_CheminLog);
            }
        }
        private void lstBxSites_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty((string)lstBxSites.SelectedItem))
                {
                    string lecture = lstBxSites.SelectedItem.ToString();
                    m_usager.IdSite = m_Choix.ObtenirIdSite(lecture);
                    ListerLesInfosSites();
                    ActiveBtns();
                }
                    
            }
            catch (Exception ex) { 
                Logger lg = new Logger(ex.ToString(), m_CheminLog);
            }
            
        }
        #endregion

        #region LE DATAGRID
        private void dgInfos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 unid = 0;
            // Vérifier que l’index est valide
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgInfos.Rows[e.RowIndex];
                // Exemple : récupérer des valeurs par nom de colonne
                string id = row.Cells["Id"].Value?.ToString();
                unid = Convert.ToInt32(id);
                m_NumSiteEnModif = unid;
            }
            string infosCompl = string.Empty;
            try
            {
                infosCompl = m_Choix.ObtenirInfosCompl(unid);
                txtInfosSupp.Text = infosCompl;
                btnModifInfos.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger lg = new Logger(ex.ToString(), m_CheminLog);
            }
            
            //lignechoisie = dgInfos.Rows
        }
        #endregion

        #endregion
                
    }
}
