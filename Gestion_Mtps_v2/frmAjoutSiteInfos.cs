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
    public partial class frmAjoutSiteInfos : Form
    {
        private Usager_v2 usager;
        private CBase maBD;
        private int m_mode;
        private string m_NomSite;
        private string m_AdresseSite;
        private string m_cheminLog;
        SiteInfos m_siteInfos;
        AjoutSiteInfos m_ASI;
        private enum Mode
        {
            Ajout = 0,
            Modif
        }
        private enum UneDonnee
        {
            Usager = 1,
            Categorie,
            SousCategorie,
            Site
        }

        public frmAjoutSiteInfos(ref Usager_v2 m_usager)
        {
            InitializeComponent();
            //InitFenetre();
        }

        public frmAjoutSiteInfos(ref Usager_v2 usager, ref CBase maBD, FormStartPosition pos, int mode, string chlog)
        {
            this.usager = usager;
            this.m_cheminLog = chlog;
            this.maBD = maBD;
            InitializeComponent();
            InitFenetre(pos);
            m_mode = mode;
            m_siteInfos = new SiteInfos();
        }

        private void InitFenetre(FormStartPosition pos)
        {
            btnFermer.Text = "Fermer";
            btnSauvegarde.Text = "Sauvegarde";
            this.BackColor = Color.LightSalmon;
            btnSauvegarde.BackColor = Color.LightGreen;
            lblAdresse.Text = "Adresse:";
            lblIdentifiant.Text = "Identifiant:";
            lblMotPassse.Text = "Mot de passe:";
            lblNomSite.Text = "Nom du site:";
            this.StartPosition = pos;
        }
        #region LES BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSauvegarde_Click(object sender, EventArgs e)
        {
            bool reussite = false;
            // Récolter les informations
            LireLaPage();
            m_ASI = new AjoutSiteInfos();
            //Je veux vérifier si on est en more ajout ou en mode modif
            try
            {
                if (m_mode == 0)
                {
                    // on ajoute
                    reussite = m_ASI.AjouterNouveau(ref usager, ref maBD, ref m_siteInfos);
                }
                else
                {
                    if (m_mode == 1)
                    {
                        // on modifie
                    }
                }
                // puis appeler CBase en conséquence
            }
            catch (Exception ex)
            {
                Logger lg = new Logger(ex.ToString(), m_cheminLog);
            }
            
        }

        private void LireLaPage()
        {
            m_siteInfos.NomSite=txtNomSite.Text;
            //throw new NotImplementedException();
        }
        #endregion
    }
}
