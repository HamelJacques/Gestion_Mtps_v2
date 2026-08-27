using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Gestion_Mtps_v2
{
    public partial class frmModifFiltres : Form
    {
        #region DONNÉES MEMBRES
        private string m_Filtre;
        private string m_NomFiltreA_Modifier;
        private CBase m_maBase;
        private Usager_v2 m_Usager;
        private string m_ChLog;
        public bool m_ModificationOK;
        #endregion
        #region CONSTRUCTEUR
        public frmModifFiltres(ref Usager_v2 U, string filtre, string nomfiltreAmodifier, ref CBase labase, string chlog)
        {
            InitializeComponent();
            m_Usager = U;
            m_maBase=labase;
            m_Filtre = filtre;
            m_ChLog = chlog;
            txtAncienNom.Text = nomfiltreAmodifier;
            InitFenetre();
        }


        #endregion

        #region MÉTHODES PRIVÉES
        private void InitFenetre()
        {            
            this.Text = "Modification d'un libellé de " + m_Filtre;
            this.BackColor = Color.Aquamarine;
            lblAncienNom.Text  = "Libellé actuel :";
            lblNouveauNom.Text = "Nouveau libellé :";            

            btnSoumettre.Text = "Soumettre";
            btnSoumettre.BackColor = Color.LightSeaGreen;
            btnSoumettre.Enabled = false;
            btnFermer.Text = "Fermer";
            btnFermer.BackColor = Color.LightSteelBlue;
            m_ModificationOK = false;
        }
        #endregion

        #region BOUTONS
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txtNouveauNom_KeyUp(object sender, KeyEventArgs e)
        {
            btnSoumettre.BackColor= Color.LightYellow;
            btnSoumettre.Enabled= true;
        }

        private void btnSoumettre_Click(object sender, EventArgs e)
        {
            int idfiltre = 0;
            int nbOccurencesSites = 0;
            int nbOccurencesCategories = 0;
            int nbOccurencesUsagers = 0;
            string sztext = string.Empty;
            List<string> lstUagersimplique;

            // 1 - Déterminer quel niveau est en modification
            switch (m_Filtre)
            {
                case "Site":
                    // Obtenir le Id du nom à modifier
                    idfiltre = m_maBase.ObtenirIdSite(txtAncienNom.Text);
                    // Obtenir le nombre d'occurences
                    nbOccurencesSites = m_maBase.ObtenirNbOccurences("IdSite", "jctSousCategorieSite", idfiltre);
                    if(nbOccurencesSites > 1)
                    {
                        // Obtenir la liste des usagers autres que l'usager présent
                        // qui utilisent ce nom de filtre (site, et informer l'usager)
                        lstUagersimplique = new List<string>();
                        lstUagersimplique = m_maBase.ObtenirListeUsagers(ref m_Usager, m_Filtre, txtNouveauNom.Text);
                        sztext = string.Format("Information");
                    }
                    break;
                case "SousCategorie":
                    // Obtenir le Id du nom à modifier
                    idfiltre = m_maBase.ObtenirIdSousCategorie(txtAncienNom.Text);
                    // Obtenir le nombre d'Usagers qui utilisent ce filtre
                    nbOccurencesUsagers = m_maBase.ObtenirNbOccurencesUsagers("jctCategorieSousCategorie", idfiltre);
                    // Obtenir le nombre de Cartégories qui utilisent ce filtre
                    nbOccurencesCategories = 0;
                    break;
            }
            string test = m_Filtre + "; " + txtAncienNom.Text;

            
            string sztitre = string.Empty;

            // préparer un messagebox pour s'assurer que le changement est vraiment ce qui est souhaité
            sztext = string.Format("Vous être sur le point de modifier le mot {0} pour {1}{2}{3}", 
                txtAncienNom.Text, txtNouveauNom.Text, Environment.NewLine, "Désires-vous poursuivre?");
            sztitre = string.Format("Modification de {0}", m_Filtre);

            DialogResult dg = MessageBox.Show(sztext, sztitre, MessageBoxButtons.YesNoCancel ,MessageBoxIcon.Question);

            // vérifier le retour
            if(dg == DialogResult.Yes)
            {
                // appeler modif
                try
                {
                    
                    // Vérifier si le texte à modifier estutilisé par un autre usager
                    // si oui, avertir
                    
                    //lstUagersimplique = m_maBase.ObtenirListeUsagerSite(ref m_Usager, m_Filtre, txtNouveauNom.Text);
                    //if (lstUagersimplique.Count > 1)
                    //{
                    //    // avertir
                    //}
                    // sinon, 
                    bool retour = m_maBase.ModifierUnFiltre(ref m_Usager, m_Filtre, txtNouveauNom.Text);
                    if (retour)
                    {
                        m_ModificationOK = true;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                    Logger lg = new Logger(ex.ToString(), m_ChLog);
                }
            }
        }
    }
}
