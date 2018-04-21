using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        E_focusedBible objEntidad = new E_focusedBible();
        N_focusedBible objNego = new N_focusedBible();
        P_focusedBibles PfocusedB;
        string p1_Name;
        string p2_Name;


        private void button1_Click(object sender, EventArgs e)
        {

            p1_Name = tbx_Player1.Text;
            p2_Name = tbx_Player2.Text;

            // para saber si el formulario existe, o sea si está abierto o cerrado
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "P_focusedBibles").SingleOrDefault<Form>();

            if (existe != null)

            {
                existe.Close();
            }

            PfocusedB = new P_focusedBibles(p1_Name, p2_Name);
            this.Hide();
            PfocusedB.Show();

        }


        void Insertar()
        {
            objEntidad.preg = tbx_Preg.Text;
            objEntidad.a = tbx_a.Text;
            objEntidad.b = tbx_b.Text;
            objEntidad.c = tbx_c.Text;
            objEntidad.d = tbx_d.Text;
            objEntidad.resp = Convert.ToChar(tbx_Resp.Text);

            objNego.N_Insertar(objEntidad);

            MessageBox.Show("Registro Insertado con exito");
        }

        private void tbx_Player1_TextChanged(object sender, EventArgs e)
        {
            if (tbx_Player1.Text == "")
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


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult salir;

            salir = MessageBox.Show("Are Sure you want to Exit?", "Warning", MessageBoxButtons.YesNo);


            if (salir == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {   // para saber si el formulario existe, o sea si está abierto o cerrado
                Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "P_focusedBibles").SingleOrDefault<Form>();

                if (existe != null)

                {
                    this.Hide();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                this.Hide();
            }
           

        }


        private void btn_NewQuests_Click(object sender, EventArgs e)
        {
            DialogResult confirm;

            confirm = MessageBox.Show("Are you sure you want to add this question?", "Confirmation", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                Insertar();
            }
        }

        private void tbx_Preg_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_Preg.SelectAll();
        }

        private void tbx_a_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_a.SelectAll();
        }

        private void tbx_b_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_b.SelectAll();
        }

        private void tbx_c_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_c.SelectAll();
        }

        private void tbx_d_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_d.SelectAll();
        }

        private void tbx_Resp_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_Resp.SelectAll();
        }

        private void tbx_Player1_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_Player1.SelectAll();
        }

        private void tbx_Player2_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_Player2.SelectAll();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
        }
    }
}
