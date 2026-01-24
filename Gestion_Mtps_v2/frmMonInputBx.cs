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
    public partial class frmMonInputBx : Form
    {
        private CBase m_LaBase;
        private Int32 m_IdUsager;
        public string MotSaisi;
        public string AncienMot;

        private enum Mode
        { 
            Ajout = 0,
            modif,
            verif
        }
        private Mode mode;
        public frmMonInputBx(Int32 idUsager, CBase labase, Int32 lemode = 0)
        {
            InitializeComponent();
            m_LaBase= labase;
            m_IdUsager = idUsager;
            initFenetre(lemode);
        }

        private void initFenetre(Int32 lemode)
        {
            mode = (Mode)lemode;
            lblMessInput.Text = "Saisissez votre mot de passe";
            txtInput.Text = string.Empty;
            txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
            btnSoumettre.Text = "Soumettre";
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
                        bool reussite = m_LaBase.ModifierUnMotDePasse(m_IdUsager, AncienMot, MotSaisi);

                        this.BackColor = Color.LightGoldenrodYellow;
                        return;
                    }
                case Mode.verif:
                    {
                        return;
                    }
            }
        }

        private void btnSoumettre_Click(object sender, EventArgs e)
        {
            MotSaisi = txtInput.Text;
            // selon le mode
            switch (mode)
            {
                case Mode.Ajout:
                    {
                        // Ajouter id et libellé
                        return;
                    }
                case Mode.modif:
                    {
                        lblAncienmps.Text = "Ancien mot de passe";
                        lblMessInput.Text = "Nouveau mot de passe";

                        txtInput.Left = lblMessInput.Left + lblMessInput.Width + 15;
                        txtAncienmps.Left = txtInput.Left;

                        this.BackColor = Color.LightGoldenrodYellow;
                        return;
                    }
                case Mode.verif:
                    {
                        return;
                    }
            }

            this.Close();
        }
    }
}
