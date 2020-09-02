using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1v3
{
    /// <summary>
    /// This class contains start button and proggress bar forms.
    /// </summary>
    public partial class ButtonAndProgressBar : Form
    {
        /// <summary>
        /// Button and Progress bar form.
        /// </summary>
        public ButtonAndProgressBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set form parameters.
        /// </summary>
        private void ButtonAndProgressBar_Load(object sender, EventArgs e)
        {
            timer1.Interval = 700;
            timer1.Tick += new EventHandler(timer1_Tick);
            progressBar.Step = 1;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
        }

        /// <summary>
        /// Timer starts after we press this. 
        /// </summary>
        private void IndicatorButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// Progress bar.
        /// </summary>
        private void progressBar_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Appears when the progress bar is completely full 
        /// and gives an opportunuty to close the program. 
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// The purpose of the existance of this timer is to fill profress bar.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar.Maximum - 1 < progressBar.Value)
            {
                CloseButton.Visible = true;
                timer1.Enabled = false;
            }

            progressBar.PerformStep();
        }
    }
}
