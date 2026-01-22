using Gestion_Mtps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gestion_Mtps_v2
{
    public partial class frmOuverture : Form
    {
        #region DONNÉES MEMBRES
        private string m_Titre;
        //private CBase m_LaBase;
        private string m_Chemin_BD;
        private string m_CheminLog;
        private List<string> m_lesUsagers;
        public Usager_v2 m_UsagerSelectionne;
        private Logger m_lg;
        #endregion
        private Ouverture O;
        #region CONSTRUCTEUR
        public frmOuverture()
        {
            
            InitializeComponent();
            
            InitForm();
        }
        #endregion

        #region MÉTHODES PRIVÉES
        private void InitForm()
        {
            string fullUser = WindowsIdentity.GetCurrent().Name;
            string userName = Environment.UserName;


            this.StartPosition = FormStartPosition.CenterScreen;
            m_UsagerSelectionne = new Usager_v2();
            m_Titre = "Ouverture par " + userName;
            this.Text = m_Titre;
            lblUsagers.Text = "Les usagers inscrits";
            btnAjout.Text = "Ajouter un utilisateur";
            m_lesUsagers = new List<string>();

            m_Chemin_BD = ConfigurationManager.AppSettings["CheminBD"];
            //m_CheminLog = O.ChExe + "application.log";
            m_CheminLog = ConfigurationManager.AppSettings["CheminLog"];
            //LogUtilisateurWindows(m_CheminLog);
            //MessageBox.Show("m_Chemin_BD = " + m_Chemin_BD);


            O = new Ouverture(m_Chemin_BD, m_CheminLog);

            foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
            {
                Console.WriteLine($"Nom: {cs.Name}, Connexion: {cs.ConnectionString}");
            }

            string connStr = ConfigurationManager.ConnectionStrings["MaBaseLocale"].ConnectionString;

            ConnectBD();


            

            m_CheminLog = O.ChExe + "application.log";
            //m_lg = new Logger("Ouverture par " + userName, m_CheminLog);
            this.Text = string.Concat(m_Titre, "   ", Environment.MachineName);
            lblChBD.Text = O.ChBD + O.LaBase.BdConnecte.ToString();
            AjusteCouleurFenere();
            AfficheUsagers();
        }

        private static void LogUtilisateurWindows(string chlog)
        {
            //string chLog = ConfigurationManager.AppSettings["CheminLog"];
            //m_CheminLog = chLog;
            string userName = Environment.UserName;
            //MessageBox.Show("Chemin log = " + chLog + Environment.NewLine + "Usager Windows = " + userName);
            Logger lg = new Logger(userName, chlog);
        }

        //private void ObtenirCheminExe()
        //{
        //    m_CheminExe = AppContext.BaseDirectory;
        //    m_Chemin_BD = m_CheminExe + NOM_BD;
        //}
        private void AfficheUsagers()
        {
            lstUsagers.Items.Clear();
            lstUsagers.Items.AddRange (O.LstUsagers.ToArray());
        }

        private void TitreFenetre()
        {
            //if(O.m)
        }
        private void AjusteCouleurFenere()
        {
            this.BackColor = Color.LightPink;
            btnFermer.BackColor = Color.LightGreen;
            btnAjout.BackColor = Color.LightYellow;
        }
        private void ConnectBD()
        {
            try
            {
                //m_LaBase = new CBase(m_Chemin_BD);
                List<string> listUsagers = new List<string>();
                m_lesUsagers = O.LstUsagers;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                AfficheMessErr(msg);
            }
        }
        private void AfficheMessErr(string err)
        {
            lblmessage.ForeColor = Color.Blue;
            lblmessage.Text = "Une erreur s'est produite. Voir application.log dans: ConnectBD()" + Environment.NewLine + err;
            //
        }
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAjout_Click(object sender, EventArgs e)
        {
            frmAjouts A = new frmAjouts("Usager", O.LaBase, ref m_lesUsagers);
            A.ShowDialog();
            AfficheUsagers();
        }

        private void lstUsagers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                m_UsagerSelectionne = new Usager_v2();
                string selection = lstUsagers.SelectedItems[0].ToString();
                // Obtenir le id de la sélection
                Int32 iSelect = O.ObtenirIdUsager(selection);
                if (iSelect == 0)
                {
                    MessageBox.Show("Faites un choix d'usager");
                }
                else
                {
                    DialogResult dr = new DialogResult();
                    m_UsagerSelectionne.IdUsager = iSelect;

                    string motDansBD = O.ObtenirMotPssUsager(iSelect);
                    
                    frmMonInputBx IB = new frmMonInputBx();
                    IB.ShowDialog();
                    string motDemande =  IB.MotSaisi;
                    //m_lg = new Logger("Sélectionné " + iSelect .ToString(), m_CheminLog);
                    frmChoix fen = new frmChoix(ref m_UsagerSelectionne, O.LaBase, m_CheminLog, this.Icon);

                    if( motDansBD == motDemande) 
                    {
                        // Ouvrir la nouvelle fenêtre de choix
                        this.Hide();
                        dr = fen.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mauvais mot de passe.", "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
            }
            
                //MessageBox.Show("En développement" + Environment.NewLine + selection);
        }
    }
}
