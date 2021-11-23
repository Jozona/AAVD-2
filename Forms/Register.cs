using AAVD.Base_de_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAVD.Forms
{
    //ESTA VENTANA ES DE PRUEBA. Eliminar eventualmente.
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        //Codigo para regresar a la primer ventana.
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (object sender2, EventArgs e2) => this.Close();
            form1.Show();
        }

        //Cuando le da el click al boton ejecuta la funcion en DatabaseManagement que registra a un usuario.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            DatabaseManagement database = DatabaseManagement.getInstance();
            database.registerUser(txtUser.Text, txtPassword.Text, 1, "yes", "yes");
            int i = 0;
        }
    }
}
