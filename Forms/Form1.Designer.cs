
namespace AAVD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.eb_pregunta = new System.Windows.Forms.TextBox();
            this.eb_respuesta = new System.Windows.Forms.TextBox();
            this.btn_recordar = new System.Windows.Forms.Button();
            this.btn_responder = new System.Windows.Forms.Button();
            this.cb_recuerdame = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(89, 127);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 22);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "empleado";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(102, 232);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 164);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // eb_pregunta
            // 
            this.eb_pregunta.Location = new System.Drawing.Point(350, 127);
            this.eb_pregunta.Name = "eb_pregunta";
            this.eb_pregunta.ReadOnly = true;
            this.eb_pregunta.Size = new System.Drawing.Size(300, 22);
            this.eb_pregunta.TabIndex = 5;
            this.eb_pregunta.Visible = false;
            // 
            // eb_respuesta
            // 
            this.eb_respuesta.Location = new System.Drawing.Point(350, 178);
            this.eb_respuesta.Name = "eb_respuesta";
            this.eb_respuesta.Size = new System.Drawing.Size(300, 22);
            this.eb_respuesta.TabIndex = 6;
            this.eb_respuesta.Visible = false;
            // 
            // btn_recordar
            // 
            this.btn_recordar.Location = new System.Drawing.Point(492, 343);
            this.btn_recordar.Name = "btn_recordar";
            this.btn_recordar.Size = new System.Drawing.Size(193, 26);
            this.btn_recordar.TabIndex = 7;
            this.btn_recordar.Text = "Recordar contraseña";
            this.btn_recordar.UseVisualStyleBackColor = true;
            this.btn_recordar.Click += new System.EventHandler(this.btn_recordar_Click);
            // 
            // btn_responder
            // 
            this.btn_responder.Location = new System.Drawing.Point(468, 232);
            this.btn_responder.Name = "btn_responder";
            this.btn_responder.Size = new System.Drawing.Size(75, 23);
            this.btn_responder.TabIndex = 8;
            this.btn_responder.Text = "Ok";
            this.btn_responder.UseVisualStyleBackColor = true;
            this.btn_responder.Visible = false;
            this.btn_responder.Click += new System.EventHandler(this.btn_responder_Click);
            // 
            // cb_recuerdame
            // 
            this.cb_recuerdame.AutoSize = true;
            this.cb_recuerdame.ForeColor = System.Drawing.Color.Coral;
            this.cb_recuerdame.Location = new System.Drawing.Point(78, 205);
            this.cb_recuerdame.Name = "cb_recuerdame";
            this.cb_recuerdame.Size = new System.Drawing.Size(111, 21);
            this.cb_recuerdame.TabIndex = 9;
            this.cb_recuerdame.Text = "Recuerdame";
            this.cb_recuerdame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::AAVD.Properties.Resources.League_of_Legends_Ashe_League_of_Legends_mountains_sky_1894075_jpg_d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(721, 403);
            this.Controls.Add(this.cb_recuerdame);
            this.Controls.Add(this.btn_responder);
            this.Controls.Add(this.btn_recordar);
            this.Controls.Add(this.eb_respuesta);
            this.Controls.Add(this.eb_pregunta);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUser);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox eb_pregunta;
        private System.Windows.Forms.TextBox eb_respuesta;
        private System.Windows.Forms.Button btn_recordar;
        private System.Windows.Forms.Button btn_responder;
        private System.Windows.Forms.CheckBox cb_recuerdame;
    }
}

