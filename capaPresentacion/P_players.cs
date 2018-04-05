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

        private void tbx_Player1_TextChanged(object sender, EventArgs e)
        {
            if(tbx_Player1.Text == "")
            {
                tbx_Player1.Text = "Player One";
                tbx_Player1.SelectAll();
            }
        }

        private void tbx_Player1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 'e' almacena la tecla presionada
            if (e.KeyChar == (char)13) //si la tecla pesionada es igual a ENTER (13)
            {
                e.Handled = true; //.Handled significa que nosotros nos haremos cargo del codigo
                                  //al ser true, evita que apareca la tecla presionada
                tbx_Player2.Focus();
            }
        }

        private void tbx_Player2_TextChanged(object sender, EventArgs e)
        {
            if (tbx_Player1.Text == "")
            {
                tbx_Player1.Text = "Player One";
                tbx_Player1.SelectAll();
            }
        }

        private void tbx_Player2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 'e' almacena la tecla presionada
            if (e.KeyChar == (char)13) //si la tecla pesionada es igual a ENTER (13)
            {
                e.Handled = true; //.Handled significa que nosotros nos haremos cargo del codigo
                                  //al ser true, evita que apareca la tecla presionada
                btn_submit.PerformClick();
            }
        }
    }
}
