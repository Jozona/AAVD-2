
namespace AAVD.Forms
{
    partial class Admin
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
        ///Probando probando
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_activar = new System.Windows.Forms.Button();
            this.eb_reactivar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Validar = new System.Windows.Forms.Button();
            this.e_respuesta = new System.Windows.Forms.TextBox();
            this.e_pregunta = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btn_emp_user = new System.Windows.Forms.TextBox();
            this.btn_emp_pass = new System.Windows.Forms.TextBox();
            this.eb_rfc_emp = new System.Windows.Forms.TextBox();
            this.eb_curp_emp = new System.Windows.Forms.TextBox();
            this.eb_am_emp = new System.Windows.Forms.TextBox();
            this.eb_ap_emp = new System.Windows.Forms.TextBox();
            this.eb_name_emp = new System.Windows.Forms.TextBox();
            this.btn_borrar_emp = new System.Windows.Forms.Button();
            this.btn_editar_emp = new System.Windows.Forms.Button();
            this.EmployeesWinDtg = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOTHER_LAST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMPLOYEE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClavesUnicas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_OF_BIRTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUESTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANSWER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_nac_emp = new System.Windows.Forms.DateTimePicker();
            this.btn_alta_empleado = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesWinDtg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_activar);
            this.tabPage3.Controls.Add(this.eb_reactivar);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1192, 593);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Opciones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_activar
            // 
            this.btn_activar.Location = new System.Drawing.Point(545, 183);
            this.btn_activar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_activar.Name = "btn_activar";
            this.btn_activar.Size = new System.Drawing.Size(75, 23);
            this.btn_activar.TabIndex = 6;
            this.btn_activar.Text = "Ok";
            this.btn_activar.UseVisualStyleBackColor = true;
            this.btn_activar.Click += new System.EventHandler(this.btn_activar_Click);
            // 
            // eb_reactivar
            // 
            this.eb_reactivar.Location = new System.Drawing.Point(469, 137);
            this.eb_reactivar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_reactivar.Name = "eb_reactivar";
            this.eb_reactivar.Size = new System.Drawing.Size(224, 22);
            this.eb_reactivar.TabIndex = 5;
            this.eb_reactivar.TextChanged += new System.EventHandler(this.eb_reactivar_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(529, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Reactivar usuario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(529, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Reiniciar sistema";
            this.label10.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(545, 386);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Reiniciar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(545, 276);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Salir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(533, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Salir de sesion";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Validar);
            this.tabPage1.Controls.Add(this.e_respuesta);
            this.tabPage1.Controls.Add(this.e_pregunta);
            this.tabPage1.Controls.Add(this.label45);
            this.tabPage1.Controls.Add(this.label44);
            this.tabPage1.Controls.Add(this.btn_emp_user);
            this.tabPage1.Controls.Add(this.btn_emp_pass);
            this.tabPage1.Controls.Add(this.eb_rfc_emp);
            this.tabPage1.Controls.Add(this.eb_curp_emp);
            this.tabPage1.Controls.Add(this.eb_am_emp);
            this.tabPage1.Controls.Add(this.eb_ap_emp);
            this.tabPage1.Controls.Add(this.eb_name_emp);
            this.tabPage1.Controls.Add(this.btn_borrar_emp);
            this.tabPage1.Controls.Add(this.btn_editar_emp);
            this.tabPage1.Controls.Add(this.EmployeesWinDtg);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtp_nac_emp);
            this.tabPage1.Controls.Add(this.btn_alta_empleado);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1192, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Agregar empleados";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // Validar
            // 
            this.Validar.Location = new System.Drawing.Point(33, 475);
            this.Validar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Validar.Name = "Validar";
            this.Validar.Size = new System.Drawing.Size(113, 42);
            this.Validar.TabIndex = 26;
            this.Validar.Text = "button1";
            this.Validar.UseVisualStyleBackColor = true;
            this.Validar.Click += new System.EventHandler(this.Validar_Click);
            // 
            // e_respuesta
            // 
            this.e_respuesta.Location = new System.Drawing.Point(133, 361);
            this.e_respuesta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.e_respuesta.Name = "e_respuesta";
            this.e_respuesta.Size = new System.Drawing.Size(347, 22);
            this.e_respuesta.TabIndex = 25;
            // 
            // e_pregunta
            // 
            this.e_pregunta.FormattingEnabled = true;
            this.e_pregunta.Items.AddRange(new object[] {
            "¿En que primaria estudiaste?",
            "¿Cual es tu pelicula favortia?",
            "¿Que harias con un millon de pesos?"});
            this.e_pregunta.Location = new System.Drawing.Point(133, 306);
            this.e_pregunta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.e_pregunta.Name = "e_pregunta";
            this.e_pregunta.Size = new System.Drawing.Size(347, 24);
            this.e_pregunta.TabIndex = 24;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(44, 361);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(76, 17);
            this.label45.TabIndex = 23;
            this.label45.Text = "Respuesta";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(44, 309);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(66, 17);
            this.label44.TabIndex = 22;
            this.label44.Text = "Pregunta";
            // 
            // btn_emp_user
            // 
            this.btn_emp_user.Location = new System.Drawing.Point(133, 239);
            this.btn_emp_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_emp_user.Name = "btn_emp_user";
            this.btn_emp_user.Size = new System.Drawing.Size(100, 22);
            this.btn_emp_user.TabIndex = 13;
            // 
            // btn_emp_pass
            // 
            this.btn_emp_pass.Location = new System.Drawing.Point(380, 236);
            this.btn_emp_pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_emp_pass.Name = "btn_emp_pass";
            this.btn_emp_pass.Size = new System.Drawing.Size(100, 22);
            this.btn_emp_pass.TabIndex = 12;
            // 
            // eb_rfc_emp
            // 
            this.eb_rfc_emp.Location = new System.Drawing.Point(380, 179);
            this.eb_rfc_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_rfc_emp.Name = "eb_rfc_emp";
            this.eb_rfc_emp.Size = new System.Drawing.Size(100, 22);
            this.eb_rfc_emp.TabIndex = 11;
            // 
            // eb_curp_emp
            // 
            this.eb_curp_emp.Location = new System.Drawing.Point(133, 182);
            this.eb_curp_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_curp_emp.Name = "eb_curp_emp";
            this.eb_curp_emp.Size = new System.Drawing.Size(100, 22);
            this.eb_curp_emp.TabIndex = 10;
            // 
            // eb_am_emp
            // 
            this.eb_am_emp.Location = new System.Drawing.Point(133, 109);
            this.eb_am_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_am_emp.Name = "eb_am_emp";
            this.eb_am_emp.Size = new System.Drawing.Size(100, 22);
            this.eb_am_emp.TabIndex = 9;
            // 
            // eb_ap_emp
            // 
            this.eb_ap_emp.Location = new System.Drawing.Point(380, 42);
            this.eb_ap_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_ap_emp.Name = "eb_ap_emp";
            this.eb_ap_emp.Size = new System.Drawing.Size(100, 22);
            this.eb_ap_emp.TabIndex = 8;
            // 
            // eb_name_emp
            // 
            this.eb_name_emp.Location = new System.Drawing.Point(133, 46);
            this.eb_name_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eb_name_emp.Name = "eb_name_emp";
            this.eb_name_emp.Size = new System.Drawing.Size(100, 22);
            this.eb_name_emp.TabIndex = 7;
            // 
            // btn_borrar_emp
            // 
            this.btn_borrar_emp.Location = new System.Drawing.Point(371, 412);
            this.btn_borrar_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_borrar_emp.Name = "btn_borrar_emp";
            this.btn_borrar_emp.Size = new System.Drawing.Size(91, 36);
            this.btn_borrar_emp.TabIndex = 21;
            this.btn_borrar_emp.Text = "Eliminar";
            this.btn_borrar_emp.UseVisualStyleBackColor = true;
            this.btn_borrar_emp.Click += new System.EventHandler(this.btn_borrar_emp_Click);
            // 
            // btn_editar_emp
            // 
            this.btn_editar_emp.Location = new System.Drawing.Point(239, 412);
            this.btn_editar_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_editar_emp.Name = "btn_editar_emp";
            this.btn_editar_emp.Size = new System.Drawing.Size(91, 36);
            this.btn_editar_emp.TabIndex = 20;
            this.btn_editar_emp.Text = "Editar";
            this.btn_editar_emp.UseVisualStyleBackColor = true;
            this.btn_editar_emp.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // EmployeesWinDtg
            // 
            this.EmployeesWinDtg.AllowUserToAddRows = false;
            this.EmployeesWinDtg.AllowUserToDeleteRows = false;
            this.EmployeesWinDtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesWinDtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.Password,
            this.Nombre,
            this.last_name,
            this.MOTHER_LAST_NAME,
            this.EMPLOYEE_ID,
            this.ClavesUnicas,
            this.DATE_OF_BIRTH,
            this.QUESTION,
            this.ANSWER});
            this.EmployeesWinDtg.Location = new System.Drawing.Point(520, 22);
            this.EmployeesWinDtg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmployeesWinDtg.Name = "EmployeesWinDtg";
            this.EmployeesWinDtg.ReadOnly = true;
            this.EmployeesWinDtg.RowHeadersWidth = 51;
            this.EmployeesWinDtg.RowTemplate.Height = 24;
            this.EmployeesWinDtg.Size = new System.Drawing.Size(643, 517);
            this.EmployeesWinDtg.TabIndex = 19;
            this.EmployeesWinDtg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeesWinDtg_CellClick);
            // 
            // User
            // 
            this.User.DataPropertyName = "USER";
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 125;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "PASSWORD";
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "NAME";
            this.Nombre.HeaderText = "Name";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // last_name
            // 
            this.last_name.DataPropertyName = "LAST_NAME";
            this.last_name.HeaderText = "last_name";
            this.last_name.MinimumWidth = 6;
            this.last_name.Name = "last_name";
            this.last_name.ReadOnly = true;
            this.last_name.Width = 125;
            // 
            // MOTHER_LAST_NAME
            // 
            this.MOTHER_LAST_NAME.DataPropertyName = "MOTHER_LAST_NAME";
            this.MOTHER_LAST_NAME.HeaderText = "MOTHER_LAST_NAME";
            this.MOTHER_LAST_NAME.MinimumWidth = 6;
            this.MOTHER_LAST_NAME.Name = "MOTHER_LAST_NAME";
            this.MOTHER_LAST_NAME.ReadOnly = true;
            this.MOTHER_LAST_NAME.Width = 125;
            // 
            // EMPLOYEE_ID
            // 
            this.EMPLOYEE_ID.DataPropertyName = "EMPLOYEE_ID";
            this.EMPLOYEE_ID.HeaderText = "EMPLOYEE_ID";
            this.EMPLOYEE_ID.MinimumWidth = 6;
            this.EMPLOYEE_ID.Name = "EMPLOYEE_ID";
            this.EMPLOYEE_ID.ReadOnly = true;
            this.EMPLOYEE_ID.Width = 125;
            // 
            // ClavesUnicas
            // 
            this.ClavesUnicas.DataPropertyName = "CLAVES_UNICAS";
            this.ClavesUnicas.HeaderText = "Claves unicas";
            this.ClavesUnicas.MinimumWidth = 6;
            this.ClavesUnicas.Name = "ClavesUnicas";
            this.ClavesUnicas.ReadOnly = true;
            this.ClavesUnicas.Width = 125;
            // 
            // DATE_OF_BIRTH
            // 
            this.DATE_OF_BIRTH.DataPropertyName = "DATE_OF_BIRTH";
            this.DATE_OF_BIRTH.HeaderText = "Fecha de nacimiento";
            this.DATE_OF_BIRTH.MinimumWidth = 6;
            this.DATE_OF_BIRTH.Name = "DATE_OF_BIRTH";
            this.DATE_OF_BIRTH.ReadOnly = true;
            this.DATE_OF_BIRTH.Width = 125;
            // 
            // QUESTION
            // 
            this.QUESTION.DataPropertyName = "QUESTION";
            this.QUESTION.HeaderText = "Pregunta";
            this.QUESTION.MinimumWidth = 6;
            this.QUESTION.Name = "QUESTION";
            this.QUESTION.ReadOnly = true;
            this.QUESTION.Width = 125;
            // 
            // ANSWER
            // 
            this.ANSWER.DataPropertyName = "ANSWER";
            this.ANSWER.HeaderText = "Respuesta";
            this.ANSWER.MinimumWidth = 6;
            this.ANSWER.Name = "ANSWER";
            this.ANSWER.ReadOnly = true;
            this.ANSWER.Width = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "nacimiento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(284, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Fecha de ";
            // 
            // dtp_nac_emp
            // 
            this.dtp_nac_emp.Location = new System.Drawing.Point(380, 112);
            this.dtp_nac_emp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_nac_emp.Name = "dtp_nac_emp";
            this.dtp_nac_emp.Size = new System.Drawing.Size(100, 22);
            this.dtp_nac_emp.TabIndex = 16;
            // 
            // btn_alta_empleado
            // 
            this.btn_alta_empleado.Location = new System.Drawing.Point(113, 412);
            this.btn_alta_empleado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_alta_empleado.Name = "btn_alta_empleado";
            this.btn_alta_empleado.Size = new System.Drawing.Size(91, 36);
            this.btn_alta_empleado.TabIndex = 15;
            this.btn_alta_empleado.Text = "Registrar";
            this.btn_alta_empleado.UseVisualStyleBackColor = true;
            this.btn_alta_empleado.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(169, 479);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "CURP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Apellido materno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Apellido Paterno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Contrasena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "RFC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 622);
            this.tabControl1.TabIndex = 1;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 630);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Admin";
            this.Text = "Admin";
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesWinDtg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox btn_emp_user;
        private System.Windows.Forms.TextBox btn_emp_pass;
        private System.Windows.Forms.TextBox eb_rfc_emp;
        private System.Windows.Forms.TextBox eb_curp_emp;
        private System.Windows.Forms.TextBox eb_am_emp;
        private System.Windows.Forms.TextBox eb_ap_emp;
        private System.Windows.Forms.TextBox eb_name_emp;
        private System.Windows.Forms.Button btn_borrar_emp;
        private System.Windows.Forms.Button btn_editar_emp;
        private System.Windows.Forms.DataGridView EmployeesWinDtg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtp_nac_emp;
        private System.Windows.Forms.Button btn_alta_empleado;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox e_respuesta;
        private System.Windows.Forms.ComboBox e_pregunta;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOTHER_LAST_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLOYEE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClavesUnicas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_OF_BIRTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUESTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANSWER;
        private System.Windows.Forms.Button btn_activar;
        private System.Windows.Forms.TextBox eb_reactivar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Validar;
    }
}
