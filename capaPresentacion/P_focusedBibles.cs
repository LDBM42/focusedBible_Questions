using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Media;

using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class P_focusedBibles : Form
    {
        public P_focusedBibles()
        {
            InitializeComponent();
        }

        SoundPlayer sonido;
        int[] noRepetir;
        int numeroPrueba;
        int i = 0;
        int countUp = 0; 
        E_focusedBible objEntidad = new E_focusedBible();
        N_focusedBible objNego = new N_focusedBible();

        private void P_focusedBibles_Load(object sender, EventArgs e)
        {
            noRepetir = new int[objNego.N_NumFilas()]; // el tamaño es el tamaño del numero de filas
            listarFocusedBible(objEntidad);
        }

        void listarFocusedBible(E_focusedBible preg)
        {
            random();

            DataTable dt = objNego.N_listado(preg);
            lab_Pregunta.Text = dt.Rows[0]["preg"].ToString();
            rbtn_a.Text = "a)   " + dt.Rows[0]["a"].ToString();
            rbtn_b.Text = "b)   " + dt.Rows[0]["b"].ToString();
            rbtn_c.Text = "c)   " + dt.Rows[0]["c"].ToString();
            rbtn_d.Text = "d)   " + dt.Rows[0]["d"].ToString();
            preg.resp = Convert.ToChar(dt.Rows[0]["resp"].ToString());
        }

        void random()
        {
            Random random = new Random();

            if (countUp == noRepetir.Length)
            {
                DialogResult respuesta = MessageBox.Show("The Game has Finished!\nDo you want to Play Again!", "Game Over", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    i = 0;
                    countUp = 0;
                    Array.Clear(noRepetir, 0, noRepetir.Length); // vaciar arreglo
                }
                else
                {
                    Application.Exit();
                }
            }

            while (true)
            {
                // numeros aleatorios desde el 1 hasta el tamaño del arreglo
                numeroPrueba = random.Next(1, noRepetir.Length+1);
                // si existe el código dentro del arreglo se agrega al arreglo, si no existe se crea el random
                if (Array.Exists(noRepetir, codPreg => codPreg == numeroPrueba))
                {
                    if(countUp == noRepetir.Length)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else //si el código no eiste en el arreglo
                {
                    noRepetir[i] = numeroPrueba; //agregar código al arreglo para que nunca se repitan
                    objEntidad.codPreg = numeroPrueba; // numeros aleatorios del 1 al numero de filas
                    i++;
                    countUp++;
                    break;
                }
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (rbtn_a.Checked == true)
            {
                if (objEntidad.resp == 'a')
                {
                    correctAnswer();
                    MessageBox.Show("Correct Answer");
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                }
            }else
                if (rbtn_b.Checked == true)
            {
                if (objEntidad.resp == 'b')
                {
                    correctAnswer();
                    MessageBox.Show("Correct Answer");
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                }
            }
            else
                if (rbtn_c.Checked == true)
            {
                if (objEntidad.resp == 'c')
                {
                    correctAnswer();
                    MessageBox.Show("Correct Answer");
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                }
            }
            else
                if (rbtn_d.Checked == true)
            {
                if (objEntidad.resp == 'd')
                {
                    correctAnswer();
                    MessageBox.Show("Correct Answer");
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                }
            }


            listarFocusedBible(objEntidad);
        }

        private void reproducirSonido(string nombreArchivo, bool loop)
        {
            if (sonido != null)
            {
                sonido.Stop();
            }
            //SystemSounds.Hand.Play(); // Sonido de windows
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\" + nombreArchivo);
                if (loop == true)
                {
                    sonido.PlayLooping();
                }
                else
                {
                    sonido.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        void correctAnswer()
        {
            reproducirSonido("correctAnswer3.wav", false);
            Thread.Sleep(400);
            reproducirSonido("cheering-and-clapping2.wav", false);
        }
    }
}
