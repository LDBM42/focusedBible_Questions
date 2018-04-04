using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace capaPresentacion
{
    public partial class P_players : Form
    {
        public P_players()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_focusedBibles pFocusB = new P_focusedBibles();

            pFocusB.lab_Player1.Text = tbx_Player1.Text;
            pFocusB.lab_Player2.Text = tbx_Player2.Text;

            Hide();
            pFocusB.Show();
        }
    }
}
