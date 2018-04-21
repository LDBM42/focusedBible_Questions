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
        public P_focusedBibles(string player1 = "Player One", string player2 = "Player Two")
        {
            this.player1 = player1;
            this.player2 = player2;
            InitializeComponent();
        }




        //variables
        string player1;
        string player2;
        SoundPlayer sonido;
        int[] noRepetir;
        int numeroPrueba;
        int click50_1 = 0; // para saber si el jugador 1 ya ha entrado al evento click de el comodin 50%
        int click50_2 = 0; // para saber si el jugador 1 ya ha entrado al evento click de el comodin 50%
        int i = 0;
        int countUp = 0;
        int countDownTimer = 2;
        int score_1 = 0;
        int lifes_1 = 3;
        int score_2 = 0;
        int lifes_2 = 3;
        int turno = 1;
        int enumerate = 1; // para ponerle número a las preguntas
        string[] comodin50_1 = new string[] { "0", "+1", "+2", "+3" };
        string[] comodin50_2 = new string[] { "0", "+1", "+2", "+3" };
        char[] desaparecer50 = new char[] { 'a', 'b', 'c', 'd' };
        int countDownComodin_1 = 2;
        int countDownComodin_2 = 2;
        Settings settings = new Settings();
        E_focusedBible objEntidad = new E_focusedBible();
        N_focusedBible objNego = new N_focusedBible();





        private void P_focusedBibles_Load(object sender, EventArgs e)
        {
            lab_Player1.Text = player1;
            lab_Player2.Text = player2;
            reproducirSonido("levelclearer.wav", true);
            noRepetir = new int[objNego.N_NumFilas()]; // el tamaño es el tamaño del numero de filas
            listarFocusedBible(objEntidad);
            focoRbtn();
            bloquear_Btn_Submit();
        }




        void listarFocusedBible(E_focusedBible preg)
        {
            randomQuestions();

            DataTable dt = objNego.N_listado(preg);
            lab_Pregunta.Text = Convert.ToString(enumerate) + ". " + dt.Rows[0]["preg"].ToString();
            rbtn_a.Text = "a)   " + dt.Rows[0]["a"].ToString();
            rbtn_b.Text = "b)   " + dt.Rows[0]["b"].ToString();
            rbtn_c.Text = "c)   " + dt.Rows[0]["c"].ToString();
            rbtn_d.Text = "d)   " + dt.Rows[0]["d"].ToString();
            preg.resp = Convert.ToChar(dt.Rows[0]["resp"].ToString());

            enumerate++;
        }
        void randomQuestions()
        {
            Random random = new Random();

            if (countUp == noRepetir.Length)
            {
                DialogResult respuesta = MessageBox.Show("The Game has Finished!\nDo you want to Play Again!", "Game Over", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    reset_PlayAgain();
                }
                else
                {
                    Application.Exit();
                }
            }

            while (true)
            {
                // numeros aleatorios desde el 1 hasta el tamaño del arreglo
                numeroPrueba = random.Next(1, noRepetir.Length + 1);
                // si existe el código dentro del arreglo se agrega al arreglo, si no existe se crea el random
                if (Array.Exists(noRepetir, codPreg => codPreg == numeroPrueba))
                {
                    if (countUp == noRepetir.Length)
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
                    lab_correctWrong(1);
                }
                else
                {
                    lab_correctWrong(0);
                }
            } else
                if (rbtn_b.Checked == true)
            {
                if (objEntidad.resp == 'b')
                {
                    lab_correctWrong(1);
                }
                else
                {
                    lab_correctWrong(0);
                }
            }
            else
                if (rbtn_c.Checked == true)
            {
                if (objEntidad.resp == 'c')
                {
                    lab_correctWrong(1);
                }
                else
                {
                    lab_correctWrong(0);
                }
            }
            else
                if (rbtn_d.Checked == true)
            {
                if (objEntidad.resp == 'd')
                {
                    lab_correctWrong(1);
                }
                else
                {
                    lab_correctWrong(0);
                }
            }
            

            // Cambio de Jugador
            if (turno == 1)
            {
                countDown.Start();
                turno = 2; //Player 2
            }
            else
            {
                countDown.Start();
                turno = 1; //Player 1
            }

            btn_Submit.Enabled = false;
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



        void perder_Ganar()
        {
            //condicion para perder
            if (lifes_1 == 0 || lifes_2 == 0)
            {
                //condicion para saber quien perdió
                if (turno == 1)
                {
                    reproducirSonido("game-over.wav", false);
                    MessageBox.Show(lab_Player1.Text + " Lose!\n\n" + lab_Player2.Text + " Wins\nLifes: " + lifes_2 + "\nScore: " + score_2);

                    DialogResult respuesta = MessageBox.Show("Do you want to Play Again?", "Game Over", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        reproducirSonido("start-ready-go.wav", true);
                        reset_PlayAgain();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show(lab_Player2.Text + " Lose!\n\n" + lab_Player1.Text + " Wins\nLifes: " + lifes_1 + "\nScore: " + score_1);

                    DialogResult respuesta = MessageBox.Show("Do you want to Play Again?", "Game Over", MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        reproducirSonido("start-ready-go.wav", true);
                        reset_PlayAgain();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
        void reset_PlayAgain()
        {
            i = 0;
            countUp = 0;
            countDownTimer = 2;
            score_1 = 0;
            lifes_1 = 3;
            score_2 = 0;
            lifes_2 = 3;
            turno = 1;
            enumerate = 1; // para ponerle número a las preguntas
            countDownComodin_1 = 2;
            countDownComodin_2 = 2;

            lab_LifesNum.Text = Convert.ToString(lifes_1);
            lab_LifesNum2.Text = Convert.ToString(lifes_2);

            lab_ScoreNum.Text = Convert.ToString(score_1);
            lab_ScoreNum2.Text = Convert.ToString(score_2);

            lab_50_1.Text = "+3";
            lab_50_2.Text = "+3";

            Array.Clear(noRepetir, 0, noRepetir.Length); // vaciar arreglo
        }



        void uncheckRbtn()
        {
            rbtn_a.Checked = false;
            rbtn_b.Checked = false;
            rbtn_c.Checked = false;
            rbtn_d.Checked = false;
        }
        void makeVisibleRbtn_andEnabled()
        {
            rbtn_a.Visible = true;
            rbtn_a.Enabled = true;
            rbtn_b.Visible = true;
            rbtn_b.Enabled = true;
            rbtn_c.Visible = true;
            rbtn_c.Enabled = true;
            rbtn_d.Visible = true;
        }
        void focoRbtn() //para tener el foco en las respuestas
        {
            if (rbtn_a.Visible == true)
            {
                rbtn_a.Focus();
                rbtn_a.Checked = false;
            }
            else
                if (rbtn_b.Visible == true)
            {
                rbtn_b.Focus();
                rbtn_b.Checked = false;
            }
            else
                if (rbtn_c.Visible == true)
            {
                rbtn_c.Focus();
                rbtn_c.Checked = false;
            }
            else
                if (rbtn_d.Visible == true)
            {
                rbtn_d.Focus();
                rbtn_d.Checked = false;
            }
        }



        void correctAnswer()
        {
            if ('a' == objEntidad.resp)
            {
                rbtn_a.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);

                rbtn_b.Enabled = false;
                rbtn_c.Enabled = false;
                rbtn_d.Enabled = false;
            }
            else
                if ('b' == objEntidad.resp)
            {
                rbtn_b.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);

                rbtn_a.Enabled = false;
                rbtn_c.Enabled = false;
                rbtn_d.Enabled = false;
            }
            else
                if ('c' == objEntidad.resp)
            {
                rbtn_c.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_d.ForeColor = Color.FromArgb(225, 225, 225);

                rbtn_a.Enabled = false;
                rbtn_b.Enabled = false;
                rbtn_d.Enabled = false;
            }
            else
                if ('d' == objEntidad.resp)
            {
                rbtn_d.ForeColor = Color.FromArgb(228, 161, 24);

                rbtn_a.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_c.ForeColor = Color.FromArgb(225, 225, 225);
                rbtn_b.ForeColor = Color.FromArgb(225, 225, 225);

                rbtn_a.Enabled = false;
                rbtn_c.Enabled = false;
                rbtn_b.Enabled = false;
            }
        }
        void lab_correctWrong(int answer) // 0 = Wrong, 1 u otro número = Correct
        {
            if (answer == 0)
            {
                correctAnswer();
                reproducirSonido("retro-lose.wav", false);
                lab_Anuncios.ForeColor = Color.Brown;
                lab_Anuncios.Text = "Wrong Answer";
                cambioDeTurno(turno, false);
            }
            else
            {
                correctAnswer();
                correctAnswerSound();
                lab_Anuncios.ForeColor = Color.FromArgb(228, 161, 24);
                lab_Anuncios.Text = "Correct Answer";
                cambioDeTurno(turno, true);
            }

        }
        void answerOriginalColor()
        {
            rbtn_a.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_b.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_c.ForeColor = Color.FromArgb(135, 135, 135);
            rbtn_d.ForeColor = Color.FromArgb(135, 135, 135);

            rbtn_a.Enabled = true;
            rbtn_b.Enabled = true;
            rbtn_c.Enabled = true;
            rbtn_d.Enabled = true;
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
                lab_LifesNum.ForeColor = Color.Brown;
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
                lab_LifesNum2.ForeColor = Color.Brown;
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
            // para desactivar el 50% si ya se ha acabado
            if (lab_50_1.Text == "0")
            {
                pbx_50_1.Enabled = false;
            }
            else
                if (lab_50_2.Text == "0")
            {
                pbx_50_2.Enabled = false;
            }

            //Codigo del metodo
            if (turno == 1)
            {
                click50_2 = 0; // reiniciar a 0 para poder usar el comodin 50% en su proximo turno
                pbx_50_2.Enabled = true; // activar comodin anterior al cambiar de turno

                if (answerCorrect == true)
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
                click50_1 = 0; // reiniciar a 0 para poder usar el comodin 50% en su proximo turno
                pbx_50_1.Enabled = true; // activar comodin anterior al cambiar de turno

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




        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult salir;
            if (turno == 1)
            {
                salir = MessageBox.Show(lab_Player1.Text + ", Are Sure you want to Exit?", "Warning", MessageBoxButtons.YesNo);
            }
            else
            {
                salir = MessageBox.Show(lab_Player2.Text + ", Are Sure you want to Exit?", "Warning", MessageBoxButtons.YesNo);
            }

            if(salir == DialogResult.Yes)
            {
                Application.Exit();
            }          
            
        }




        private void pbx_50_MouseEnter(object sender, EventArgs e)
        {
            pbx_50_1.Image = Properties.Resources._50_percent_MouseOn;
        }
        private void pbx_50_MouseLeave(object sender, EventArgs e)
        {
            pbx_50_1.Image = Properties.Resources._50_percent;
        }
        private void pbx_50_Click(object sender, EventArgs e)
        {
            if (lab_50_1.Text != "0")
            {
                lab_50_1.Text = comodin50_1[countDownComodin_1];
                countDownComodin_1--;
                random50();
                pbx_50_1.Enabled = false;
                focoRbtn();

                btn_Submit.Enabled = false; //para evitar que se presione submit sin estar seleccionada ninguna respuesta
                uncheckRbtn();
            }
        }
        private void pbx_50_2_MouseEnter(object sender, EventArgs e)
        {
            pbx_50_2.Image = Properties.Resources._50_percent_MouseOn;
        }
        private void pbx_50_2_MouseLeave(object sender, EventArgs e)
        {
            pbx_50_2.Image = Properties.Resources._50_percent;
        }
        private void pbx_50_2_Click(object sender, EventArgs e)
        {
            if (lab_50_2.Text != "0")
            {
                lab_50_2.Text = comodin50_2[countDownComodin_2];
                countDownComodin_2--;
                random50();
                pbx_50_2.Enabled = false;
                focoRbtn();
                btn_Submit.Enabled = false; //para evitar que se presione submit sin estar seleccionada ninguna respuesta

                uncheckRbtn();
            }
        }
        void activarComidin(int turno)
        {
            if (turno == 1)
            {
                pbx_50_2.Visible = false;
                lab_50_2.Visible = false;
                pbx_50_1.Visible = true;
                lab_50_1.Visible = true;
            }
            else
            {
                pbx_50_1.Visible = false;
                lab_50_1.Visible = false;
                pbx_50_2.Visible = true;
                lab_50_2.Visible = true;
            }
        }
        void random50()
        {
            Random random = new Random();
            int i = 0;
            int indice;

            while(i != 2)
            {
                indice = random.Next(0, 3);
                if (objEntidad.resp != desaparecer50[indice])
                {
                    if(desaparecer50[indice] == 'a')
                    {
                        if(rbtn_a.Visible == true) // condicion para saber si ya se ha vuelto invisible,
                                                    //para que no lo cuente denuevo
                        {
                            rbtn_a.Enabled = false;
                            rbtn_a.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'b')
                    {
                        if (rbtn_b.Visible == true)
                        {
                            rbtn_b.Enabled = false;
                            rbtn_b.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'c')
                    {
                        if (rbtn_c.Visible == true)
                        {
                            rbtn_c.Enabled = false;
                            rbtn_c.Visible = false;
                            i++;
                        }
                    }
                    else
                        if (desaparecer50[indice] == 'd')
                    {
                        if (rbtn_d.Visible == true)
                        {
                            rbtn_d.Enabled = false;
                            rbtn_d.Visible = false;
                            i++;
                        }
                    }
                }
            }
        }


        private void countDown_Tick(object sender, EventArgs e)
        {
            if(countDownTimer != 1)
            {
                countDownTimer--;
            }
            else
            {
                countDownTimer = 2;
                countDown.Stop();
                lab_Anuncios.Text = "";

                answerOriginalColor(); // aqui cambian las respuestas al color original
                listarFocusedBible(objEntidad); //lista las preguntas y respuestas
                uncheckRbtn(); //desmarca las respuestas
                makeVisibleRbtn_andEnabled();//pone las resuestas visibles y abilitadas
                focoRbtn(); // se pone el foco las respuestas para poder seleccionarlas con el teclado

                bloquear_Btn_Submit();

                if (turno == 1)
                {
                    activarComidin(1);
                    PlayerFocus(1);
                    reproducirSonido("levelclearer.wav", true);
                }
                else
                {
                    activarComidin(2);
                    PlayerFocus(2);
                    reproducirSonido("levelclearer.wav", true);
                }
            }
        }



        //eventos para seleccionar a travez del teclado
        private void rbtn_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }
        private void rbtn_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }
        private void rbtn_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }
        private void rbtn_d_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }
        private void btn_Submit_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }
        private void btn_Exit_KeyPress(object sender, KeyPressEventArgs e)
        {
            selectAnswer(e);
        }

    

        void selectAnswer(KeyPressEventArgs e)
        {

            // 'e' almacena la tecla presionada
            if (e.KeyChar == (char)13 && btn_Submit.Enabled == true) //si la tecla pesionada es igual a ENTER (13)
            {
                e.Handled = true; //.Handled significa que nosotros nos haremos cargo del codigo
                                  //al ser true, evita que apareca la tecla presionada

                // si el foco esta en exit entonces se da clic a Exit, pero si esta en otro lado, da clic en Submit
                if (btn_Exit.Focused == true)
                {
                    btn_Exit.PerformClick();
                }
                else
                {
                    btn_Submit.PerformClick();
                }
            }
            else
                if ((e.KeyChar == (char)49 || e.KeyChar == (char)97 || e.KeyChar == (char)65) && rbtn_a.Visible == true)
            {
                rbtn_a.Focus();
                rbtn_a.Checked = true;
                btn_Submit.Enabled = true;
            }
            else
                if ((e.KeyChar == (char)50 || e.KeyChar == (char)98 || e.KeyChar == (char)66) && rbtn_b.Visible == true)
            {
                rbtn_b.Focus();
                rbtn_b.Checked = true;
                btn_Submit.Enabled = true;
            }
            else
                if ((e.KeyChar == (char)51 || e.KeyChar == (char)99 || e.KeyChar == (char)67) && rbtn_c.Visible == true)
            {
                rbtn_c.Focus();
                rbtn_c.Checked = true;
                btn_Submit.Enabled = true;
            }
            else
                if ((e.KeyChar == (char)52 || e.KeyChar == (char)100 || e.KeyChar == (char)68) && rbtn_d.Visible == true)
            {
                rbtn_d.Focus();
                rbtn_d.Checked = true;
                btn_Submit.Enabled = true;
            }
            else
                if ((e.KeyChar == (char)45 || e.KeyChar == (char)47)) // signos '-' y '/' para el comodin 50%
            {
                if (turno == 1 && click50_1 == 0)
                {
                    click50_1++;
                    pbx_50_Click(this, new EventArgs());
                }
                else
                    if(turno == 2 && click50_2 == 0)
                {
                    click50_2++;
                    pbx_50_2_Click(this, new EventArgs());
                }
            }

        }



        void bloquear_Btn_Submit() // para hacer el submit solo si se ha elegido una respuesta
        {
            if (rbtn_a.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
                if (rbtn_b.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
                if (rbtn_c.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
                if (rbtn_d.Checked == true)
            {
                btn_Submit.Enabled = true;
            }
            else
            {
                btn_Submit.Enabled = false;
            }
        }




        private void rbtn_a_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Submit.Enabled == false)
            btn_Submit.Enabled = true;
        }
        private void rbtn_b_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Submit.Enabled == false)
                btn_Submit.Enabled = true;
        }
        private void rbtn_c_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Submit.Enabled == false)
                btn_Submit.Enabled = true;
        }
        private void rbtn_d_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_Submit.Enabled == false)
                btn_Submit.Enabled = true;
        }




        private void Btn_Settings_Click(object sender, EventArgs e)
        {
            // mostrar los nombres que estan jugando
            settings.tbx_Player1.Text = lab_Player1.Text;
            settings.tbx_Player2.Text = lab_Player2.Text;

            try
            {   // para saber si el formulario existe, o sea si está abierto o cerrado
                Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Settings").SingleOrDefault<Form>();

                if (existe != null)

                {
                    settings.Show();
                }
            }
            catch (Exception)
            {
                settings.Show();
            }

            
        }
        private void Btn_Settings_MouseEnter(object sender, EventArgs e)
        {
            Btn_Settings.Image = Properties.Resources.Settings_MouseUp;
        }
        private void Btn_Settings_MouseLeave(object sender, EventArgs e)
        {
            Btn_Settings.Image = Properties.Resources.Settings;
        }
    }
}
