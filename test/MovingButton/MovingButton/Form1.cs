using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingButton
{
    /// <summary>
    /// Moving button form.
    /// </summary>
    public partial class MovingButton : Form
    {
        public MovingButton()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        private int Mod(int value)
        {
            if (value < 0)
            {
                return -value;
            }
            return value;
        }

        /// <summary>
        /// Random sign
        /// </summary>
        /// <returns>1 or -1</returns>
        private int RandomSign()
        {
            return rnd.Next() > 0 ? 1 : -1;
        }

        /// <summary>
        /// Change onr coordinate of the point.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private int ChangeCoordinates(int coordinate)
        {
            if (coordinate < 60)
            {
                return coordinate + 70 + Mod(rnd.Next() % 30);
            }
            if (coordinate > 170)
            {
                return coordinate - 70 - rnd.Next() % 30;
            }
            return coordinate + RandomSign() * (30 + Mod(rnd.Next()) % 50);
        }

        /// <summary>
        /// Move the  button when hovering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Location = new Point(ChangeCoordinates(button1.Location.X), ChangeCoordinates(button1.Location.Y));
        }

        /// <summary>
        /// Show the message box and exit from the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Over");
            Application.Exit();
        }
    }
}
