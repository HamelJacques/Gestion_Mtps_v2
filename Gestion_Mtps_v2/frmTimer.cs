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
    public partial class frmTimer : Form
    {
        private int attente;
        public frmTimer()
        {
            InitializeComponent();
            InitFenetre();
            timer1.Tick += timer1_Tick;

            timer2.Tick += timer2_Tick;
        }

        private void InitFenetre()
        {
            progressB.Minimum = 0;
            progressB.Maximum = 100;
            attente = 0;
            progressB.Style = ProgressBarStyle.Continuous;

            timer1.Interval = 30; // 30 ms
            timer2.Interval = 10;
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressB.Value < progressB.Maximum)
            {
                progressB.Value += 1;
                progressB.Refresh(); 
            }
            else
            {
                timer1.Stop();
                //timer2 = new Timer();
                timer2.Start();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (attente < 50)
            {
                attente += 1;
            }
            else
            {
                timer2.Stop();
                this.Close();
            }
        }

    }
}
