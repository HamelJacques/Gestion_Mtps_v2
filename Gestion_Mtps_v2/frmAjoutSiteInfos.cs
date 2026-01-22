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
        }

        public frmAjoutSiteInfos(ref Usager_v2 usager, ref CBase maBD, FormStartPosition pos, int mode, string chlog, int unid = 0)
        {
            this.usager = usager;
            this.m_cheminLog = chlog;
            this.maBD = maBD;
            m_siteInfos = new SiteInfos();
            m_siteInfos.Id = unid;
            m_mode = mode;
            InitializeComponent();
            InitFenetre(pos, GetM_mode());            
            
            this.DialogResult = DialogResult.No;
        }

        private int GetM_mode()
        {
            return m_mode;
        }

        private void InitFenetre(FormStartPosition pos, int m_mode)
        {
            btnFermer.Text = "Fermer";
            lblErr.Text = "";
            if(m_mode == (int)Mode.Ajout)
            {
                this.BackColor = Color.LightSalmon;
                btnSauvegarde.Text = "Sauvegarde les nouvelles informations";
            }
            if (m_mode == (int)Mode.Modif)
            {
                this.BackColor = Color.LightSalmon;
                btnSauvegarde.Text = "Sauvegarde les modifications";
                RecupererUnEnregistrement(m_siteInfos);
                AfficherInfos();
            }

            btnSauvegarde.BackColor = Color.LightGreen;
            lblAdresse.Text = "Adresse:";
            lblIdentifiant.Text = "Identifiant:";
            lblMotPassse.Text = "Mot de passe:";
            lblNomSite.Text = "Nom du site:";
            lblInfosCompl.Text = "Informations" + Environment.NewLine +"complémemntaires";
            this.StartPosition = pos;
        }

        private void AfficherInfos()
        {
            txtAdresse.Text = m_siteInfos.Adresse;
            txtIdentifiant.Text = m_siteInfos.Identifiant;
            txtInfosComplementaires.Text=   m_siteInfos.InfosCompl.ToString();
            txtMotPass.Text= m_siteInfos.MotPass;
            txtNomSite.Text= m_siteInfos.NomSite;
        }

        private void RecupererUnEnregistrement(SiteInfos m_siteInfos)
        {
            try
            {
                maBD.RecupererUnEnregistrement(m_siteInfos);
            }
            catch(Exception ex)
            {
                Logger lg = new Logger(ex.ToString(), m_cheminLog);
            }            
        }
        #region LES BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSauvegarde_Click(object sender, EventArgs e)
        {
            bool reussite = false;
            frmTimer timer = new frmTimer();
            
            // Récolter les informations
            LireLaPage();
            m_ASI = new AjoutSiteInfos();
            //Je veux vérifier si on est en more ajout ou en mode modif
            // puis appeler CBase en conséquence
            try
            {
                if (m_mode == 0)
                {
                    // on ajoute
                    reussite = m_ASI.AjouterNouveau(ref usager, ref maBD, ref m_siteInfos);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (m_mode == 1)
                    {
                        // on modifie
                        reussite = m_ASI.ModifierSiteInfos(ref maBD,ref m_siteInfos);//     ModifierNouveau(ref maBD, ref m_siteInfos);
                    }
                }
                if (reussite)
                {
                    timer.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblErr.Text = "Une erreur est survenue";
                }
            }
            catch (Exception ex)
            {
                Logger lg = new Logger(ex.ToString(), m_cheminLog);
                lblErr.Text = "Une erreur est survenue au cours de l'enregistrement";
            }
            
        }

        /// <summary>
        /// Lecture des informations en vue de la sauvegarde
        /// </summary>
        private void LireLaPage()
        {
            m_siteInfos.NomSite=txtNomSite.Text;
            m_siteInfos.Adresse = txtAdresse.Text;
            m_siteInfos.Identifiant = txtIdentifiant.Text;
            m_siteInfos.MotPass = txtMotPass.Text;
            m_siteInfos.InfosCompl = txtInfosComplementaires .Text;
        }
        #endregion
    }
}
