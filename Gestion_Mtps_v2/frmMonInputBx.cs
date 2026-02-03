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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestion_Mtps_v2
{
    public partial class frmMonInputBx : Form
    {
        private CBase m_LaBase;
        private Int32 m_IdUsager;
        public string MotSaisi;
        public string AncienMot;
        private string m_ChLog;

        private enum Mode
        { 
            Ajout = 0,
            modif,
            verif
        }
        private Mode mode;
        public frmMonInputBx(Int32 idUsager, CBase labase, string chlog, Int32 lemode = 0)
        {
            InitializeComponent();
            m_LaBase= labase;
            m_IdUsager = idUsager;
            m_ChLog= chlog;
            initFenetre(lemode);
        }

        private void initFenetre(Int32 lemode)
        {
            mode = (Mode)lemode;
            lblMessInput.Text = "Saisissez votre mot de passe";
            txtInput.Text = string.Empty;
            txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
            btnSoumettre.Text = "Soumettre";
            btnAnnuler.Text = "Annuler";
            btnAnnuler.BackColor = Color.LightSalmon;
            MotSaisi = txtInput.Text;
            
            AjusteFentre();
        }

        private void AjusteFentre()
        {
            switch(mode)
            {
                case Mode.Ajout:
                    {
                        lblAncienmps.Visible = false;
                        txtAncienmps.Visible = false;
                        this.BackColor = Color.LightYellow;
                        this.Text = "Ajouter";
                        return;
                    }                    
                case Mode.modif:
                    {
                        lblAncienmps.Visible = true;
                        lblAncienmps.Text = "Ancien mot de passe";
                        txtAncienmps.Visible = true;
                        lblMessInput.Text = "Nouveau mot de passe";

                        txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
                        txtAncienmps.Left = txtInput.Left;

                        MotSaisi = txtInput.Text;
                        AncienMot  = txtAncienmps.Text.Trim();
                        //bool reussite = m_LaBase.ModifierUnMotDePasse(m_IdUsager, AncienMot, MotSaisi);

                        btnSoumettre.BackColor = Color.LightSeaGreen;
                        this.Text = "Modifier";
                        this.BackColor = Color.LightGoldenrodYellow;
                        return;
                    }
                case Mode.verif:
                    {
                        txtAncienmps.PasswordChar = '*';
                        lblAncienmps.Visible = false;
                        txtAncienmps.Visible = false;
                        btnSoumettre.BackColor = Color.LightCyan;
                        
                        this.BackColor = Color.LightGreen;
                        this.Text = "Vérifier";

                        


                        return;
                    }
            }
        }

        private void btnSoumettre_Click(object sender, EventArgs e)
        {
            MotSaisi = txtInput.Text;
            try
            {
                // selon le mode
                switch (mode)
                {
                    case Mode.Ajout:
                        {
                            // Ajouter id et libellé
                            //Int32 unid = m_LaBase.ObtenirIdUsager("");
                            bool reussite = m_LaBase.AjouterMtpsUsager_v2(m_IdUsager, txtInput.Text);
                            this.Close();
                            return;
                        }
                    case Mode.modif:
                        {
                            lblAncienmps.Text = "Ancien mot de passe";
                            lblMessInput.Text = "Nouveau mot de passe";

                            txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
                            txtAncienmps.Left = txtInput.Left;

                            this.BackColor = Color.LightGoldenrodYellow;

                            bool reussite = m_LaBase.ModifierUnMotDePasse(m_IdUsager, AncienMot, MotSaisi);
                            this.Close();
                            return;
                        }
                    case Mode.verif:
                        {
                            this.Close();
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Logger lg = new Logger(msg,m_ChLog);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAncienmps_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtInput.Multiline = false;
            //txtInput.UseSystemPasswordChar = false;
            txtInput.PasswordChar = '*';
        }
    }
}
