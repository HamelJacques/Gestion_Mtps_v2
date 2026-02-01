using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string sztext = string.Empty;
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
                    List<string> lstUagersimplique;
                    // Vérifier si le texte à modifier estutilisé par un autre usager
                    // si oui, avertir
                    lstUagersimplique = new List<string>();
                    //lstUagersimplique = m_maBase.ObtenirListeUsagers(ref m_Usager, m_Filtre, txtNouveauNom.Text);
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
