namespace capaPresentacion
{
    partial class P_focusedBibles
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_Pregunta = new System.Windows.Forms.Label();
            this.rbtn_a = new System.Windows.Forms.RadioButton();
            this.rbtn_b = new System.Windows.Forms.RadioButton();
            this.rbtn_c = new System.Windows.Forms.RadioButton();
            this.rbtn_d = new System.Windows.Forms.RadioButton();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab_Pregunta
            // 
            this.lab_Pregunta.AutoSize = true;
            this.lab_Pregunta.Location = new System.Drawing.Point(39, 41);
            this.lab_Pregunta.Name = "lab_Pregunta";
            this.lab_Pregunta.Size = new System.Drawing.Size(46, 17);
            this.lab_Pregunta.TabIndex = 0;
            this.lab_Pregunta.Text = "label1";
            // 
            // rbtn_a
            // 
            this.rbtn_a.AutoSize = true;
            this.rbtn_a.Location = new System.Drawing.Point(42, 96);
            this.rbtn_a.Name = "rbtn_a";
            this.rbtn_a.Size = new System.Drawing.Size(110, 21);
            this.rbtn_a.TabIndex = 1;
            this.rbtn_a.TabStop = true;
            this.rbtn_a.Text = "radioButton1";
            this.rbtn_a.UseVisualStyleBackColor = true;
            // 
            // rbtn_b
            // 
            this.rbtn_b.AutoSize = true;
            this.rbtn_b.Location = new System.Drawing.Point(42, 133);
            this.rbtn_b.Name = "rbtn_b";
            this.rbtn_b.Size = new System.Drawing.Size(110, 21);
            this.rbtn_b.TabIndex = 2;
            this.rbtn_b.TabStop = true;
            this.rbtn_b.Text = "radioButton2";
            this.rbtn_b.UseVisualStyleBackColor = true;
            // 
            // rbtn_c
            // 
            this.rbtn_c.AutoSize = true;
            this.rbtn_c.Location = new System.Drawing.Point(42, 170);
            this.rbtn_c.Name = "rbtn_c";
            this.rbtn_c.Size = new System.Drawing.Size(110, 21);
            this.rbtn_c.TabIndex = 3;
            this.rbtn_c.TabStop = true;
            this.rbtn_c.Text = "radioButton3";
            this.rbtn_c.UseVisualStyleBackColor = true;
            // 
            // rbtn_d
            // 
            this.rbtn_d.AutoSize = true;
            this.rbtn_d.Location = new System.Drawing.Point(42, 207);
            this.rbtn_d.Name = "rbtn_d";
            this.rbtn_d.Size = new System.Drawing.Size(110, 21);
            this.rbtn_d.TabIndex = 4;
            this.rbtn_d.TabStop = true;
            this.rbtn_d.Text = "radioButton4";
            this.rbtn_d.UseVisualStyleBackColor = true;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(42, 249);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(110, 23);
            this.btn_Submit.TabIndex = 5;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // P_focusedBibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 310);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.rbtn_d);
            this.Controls.Add(this.rbtn_c);
            this.Controls.Add(this.rbtn_b);
            this.Controls.Add(this.rbtn_a);
            this.Controls.Add(this.lab_Pregunta);
            this.Name = "P_focusedBibles";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.P_focusedBibles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Pregunta;
        private System.Windows.Forms.RadioButton rbtn_a;
        private System.Windows.Forms.RadioButton rbtn_b;
        private System.Windows.Forms.RadioButton rbtn_c;
        private System.Windows.Forms.RadioButton rbtn_d;
        private System.Windows.Forms.Button btn_Submit;
    }
}

