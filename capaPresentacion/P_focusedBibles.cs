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
        int score_1 = 0;
        int lifes_1 = 3;
        int score_2 = 0;
        int lifes_2 = 3;
        int turno = 1;
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
                    correctAnswerSound();
                    MessageBox.Show("Correct Answer");
                    cambioDeTurno(turno, true);
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                    cambioDeTurno(turno, false);
                }
            }else
                if (rbtn_b.Checked == true)
            {
                if (objEntidad.resp == 'b')
                {
                    correctAnswerSound();
                    MessageBox.Show("Correct Answer");
                    cambioDeTurno(turno, true);
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                    cambioDeTurno(turno, false);
                }
            }
            else
                if (rbtn_c.Checked == true)
            {
                if (objEntidad.resp == 'c')
                {
                    correctAnswerSound();
                    MessageBox.Show("Correct Answer");
                    cambioDeTurno(turno, true);
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                    cambioDeTurno(turno, false);
                }
            }
            else
                if (rbtn_d.Checked == true)
            {
                if (objEntidad.resp == 'd')
                {
                    correctAnswerSound();
                    MessageBox.Show("Correct Answer");
                    cambioDeTurno(turno, true);
                }
                else
                {
                    reproducirSonido("retro-lose.wav", false);
                    MessageBox.Show("Wrong Answer");
                    cambioDeTurno(turno, false);
                }
            }

            // Cambio de Jugador
            if(turno == 1)
            {
                PlayerFocus(2);
                turno = 2; //Player 2
            }
            else
            {
                PlayerFocus(1);
                turno = 1; //Player 1
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

        void correctAnswerSound()
        {
            reproducirSonido("correctAnswer3.wav", false);
            Thread.Sleep(400);
            reproducirSonido("cheering-and-clapping2.wav", false);
        }

        void PlayerFocus(int turno)
        {
            if (turno == 1)
            {
                //para poder cambiar el tamaño de la fuente hay que instanciarla y pasarle los parametros siguientes.
                lab_Player1.Font = new Font(lab_Player1.Font.Name, 20, lab_Player1.Font.Style, lab_Player1.Font.Unit);
                //para cambiar el color a gris
                lab_Player1.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Player2.Font = new Font(lab_Player2.Font.Name, 10, lab_Player2.Font.Style, lab_Player2.Font.Unit);
                //para cambiar el color a orange
                lab_Player2.ForeColor = Color.FromArgb(237, 237, 237);


                cambiarColoryJugador(turno);

            }
            else // si el turno es 2
            {
                lab_Player2.Font = new Font(lab_Player2.Font.Name, 20, lab_Player2.Font.Style, lab_Player2.Font.Unit);
                lab_Player2.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Player1.Font = new Font(lab_Player1.Font.Name, 10, lab_Player1.Font.Style, lab_Player1.Font.Unit);
                lab_Player1.ForeColor = Color.FromArgb(237, 237, 237);

                cambiarColoryJugador(turno);
            }
        }

        void cambiarColoryJugador(int turno)
        {
            if (turno == 1)
            {
                lab_Lifes.ForeColor = Color.FromArgb(135, 135, 135);
                lab_LifesNum.ForeColor = Color.FromArgb(228, 161, 24);
                lab_Score.ForeColor = Color.FromArgb(135, 135, 135);
                lab_ScoreNum.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Lifes2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_LifesNum2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_Score2.ForeColor = Color.FromArgb(237, 237, 237);
                lab_ScoreNum2.ForeColor = Color.FromArgb(237, 237, 237);
            }
            else // si el turno es 2
            {
                lab_Lifes2.ForeColor = Color.FromArgb(135, 135, 135);
                lab_LifesNum2.ForeColor = Color.FromArgb(228, 161, 24);
                lab_Score2.ForeColor = Color.FromArgb(135, 135, 135);
                lab_ScoreNum2.ForeColor = Color.FromArgb(228, 161, 24);

                lab_Lifes.ForeColor = Color.FromArgb(237, 237, 237);
                lab_LifesNum.ForeColor = Color.FromArgb(237, 237, 237);
                lab_Score.ForeColor = Color.FromArgb(237, 237, 237);
                lab_ScoreNum.ForeColor = Color.FromArgb(237, 237, 237);
            }
        }

        void cambioDeTurno(int turno, bool answerCorrect) // si el turno es uno y la respuesta fue correcta
        {
            if(turno == 1)
            {
                if(answerCorrect == true)
                {
                    score_1++;
                    lab_ScoreNum.Text = Convert.ToString(score_1);
                }
                else
                {
                    lifes_1--;
                    lab_LifesNum.Text = Convert.ToString(lifes_1);
                    perder_Ganar();
                }
            }
            else
            {
                if (answerCorrect == true)
                {
                    score_2++;
                    lab_ScoreNum2.Text = Convert.ToString(score_2);
                }
                else
                {
                    lifes_2--;
                    lab_LifesNum2.Text = Convert.ToString(lifes_2);
                    perder_Ganar();
                }
            }
        }

        void perder_Ganar()
        {
            //condicion para perder
            if (lifes_1 == 0 || lifes_2 == 0)
            {
                //condicion para saber quien perdió
                if (turno == 1)
                {
                    MessageBox.Show(lab_Player1.Text +" Lose!\n\n"+ lab_Player2.Text +" Wins\nLifes: " + lifes_2 + "\nScore: " + score_2);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(lab_Player2.Text + " Lose!\n\n"+ lab_Player1.Text +" Wins\nLifes: " + lifes_1 + "\nScore: " + score_1);
                    Application.Exit();
                }
            }
        }
    }
}
