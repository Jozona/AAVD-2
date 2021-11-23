using AAVD.Base_de_datos;
using AAVD.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AAVD.Forms
{
   
    public partial class Admin : Form
    {
        bool estabien = true;
        public Admin()
        {
            InitializeComponent(); 
            dtp_nac_emp.CustomFormat = "yyyy-MM-dd";
            dtp_nac_emp.Format = DateTimePickerFormat.Custom;
            this.CenterToScreen();
            updateDataGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Dar de alta un empleado
        private void button1_Click(object sender, EventArgs e)
        {
            bool validaruser = true;
            bool validarpassword = true;
            bool validarnombre = true;
            bool validarAP = true;
            bool validarAM = true;
            bool validarRFC = true;
            //bool validarfecha = false;
            bool validarCURP = true;

            String username = this.btn_emp_user.Text;
            String password = this.btn_emp_pass.Text;
            String vnombre = this.eb_name_emp.Text;
            String vAP = this.eb_ap_emp.Text;
            String vAM = this.eb_am_emp.Text;
            String vRFC = this.eb_rfc_emp.Text;
            String vFecha = this.dtp_nac_emp.Text;
            String vCurp = this.eb_curp_emp.Text;


            string regexString = /*@"/^[A-Za-z]$/"*/ "[A-Za-z]"; //Permite letras y numeros
            string regexStringPass = "[0-9]";
            string regexStringRFC = "^[0-9]*$";
            string regexStringnombre = "^[A-Za-z]*$";
            string regexStringCurp = "[A-Za-z]";


            //Validacion username
            if (Regex.IsMatch(username, regexString))
            {
               
                //validaruser = true;

            }

            else
            {
                validaruser = false;
                MessageBox.Show("Solo se permiten letras y numeros. Ej: Luis123");
            }

            //Validacion password
            if (Regex.IsMatch(password, regexStringPass))
            {

                
            }

            else
            {
                MessageBox.Show("Solo se permiten numeros y letras. Ej: 123Pass");
                validarpassword = false;
            }

            //Validacion nombre
            if (Regex.IsMatch(vnombre, regexStringnombre))
            {

                
            }

            else
            {
                validarnombre = false;
                MessageBox.Show("Solo se permiten letras");

            }

            //Validacion AP
            if (Regex.IsMatch(vAP, regexStringnombre))
            {

               
            }

            else
            {
                validarAP = false;
                MessageBox.Show("Solo se permiten letras");

            }

            //Validacion AM
            if (Regex.IsMatch(vAM, regexStringnombre))
            {

               
            }

            else
            {
                validarAM = false;
                MessageBox.Show("Solo se permiten letras");

            }

            //Validacion RFC
            if (Regex.IsMatch(vRFC, regexStringRFC))
            {

                
            }

            else
            {
                validarRFC = false;
                MessageBox.Show("Solo se permiten numeros");

            }

            //Validacion CURP
            if (Regex.IsMatch(vCurp, regexStringCurp))
            {

               
            }

            else
            {
                validarCURP = false;
                MessageBox.Show("Solo se permiten letras y numeros. Ej: IBP505");

            }

            if (validaruser == false || validarpassword == false || validarnombre == false || validarAP == false || validarAM == false || validarRFC == false || validarCURP == false)
            {
                //Da error
                estabien = false;
                MessageBox.Show("Falla en el rellenado del campo");
            }
            else
            {
                //Aqui podemos asignar un booleano global para permitir o no agregar un empleado
                estabien = true;
                
            }




            if (estabien == true)
            {

                // El sandwich
                DatabaseManagement database = DatabaseManagement.getInstance();
                if (!(database.registerUser(btn_emp_user.Text, btn_emp_pass.Text, 1, e_pregunta.Text, e_respuesta.Text)))
                {
                    MessageBox.Show("No se pueden repetir usuarios");
                    return;
                }
                List<Users> user = new List<Users>();
                user = database.getLogin(btn_emp_user.Text, btn_emp_pass.Text);
                Guid new_user_id;
                foreach (var data in user)
                {
                    new_user_id = data.user_id;
                    database.registerEmployee(btn_emp_user.Text, btn_emp_pass.Text, eb_name_emp.Text, eb_ap_emp.Text, eb_am_emp.Text, eb_curp_emp.Text, eb_rfc_emp.Text, dtp_nac_emp.Value.ToString("yyyy-MM-dd"), new_user_id, e_pregunta.Text, e_respuesta.Text);
                }
                MessageBox.Show("Empleado registrado con exito.");
                updateDataGrid();
                //Fin del sandwich

            }
            else
            {
                MessageBox.Show("Esta muy mal");
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        int indexRow;
        string id_empleadoSelect;

        //Si la click a editar al empleado, lo buscamos por medio de su usuario y hacemos un UPDATE.
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (id_empleadoSelect == null) {
                MessageBox.Show("Selecciona un empleado");
                return;
            }
            DatabaseManagement.getInstance().updateEmployee(btn_emp_user.Text, btn_emp_pass.Text, eb_name_emp.Text, eb_ap_emp.Text, eb_am_emp.Text, eb_curp_emp.Text, eb_rfc_emp.Text, dtp_nac_emp.Value.ToString("yyyy-MM-dd"), id_empleadoSelect, e_pregunta.Text, e_respuesta.Text);
            MessageBox.Show("Empleado actualizado");
            updateDataGrid();
            id_empleadoSelect = null;
        }

        private void EmployeesWinDtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (indexRow < 0) { 
                MessageBox.Show("Selecciona a un empleado");
                return;
            }
            DataGridViewRow row = EmployeesWinDtg.Rows[indexRow];
            if (row == null)
                return;

            btn_emp_user.Text = row.Cells[2].Value.ToString();
            btn_emp_pass.Text = row.Cells[3].Value.ToString();
            eb_name_emp.Text = row.Cells[4].Value.ToString();
            eb_ap_emp.Text = row.Cells[5].Value.ToString();
            eb_am_emp.Text = row.Cells[6].Value.ToString();
            dtp_nac_emp.Text = row.Cells[8].Value.ToString();
            e_pregunta.Text = row.Cells[9].Value.ToString();
            e_respuesta.Text = row.Cells[10].Value.ToString();
            id_empleadoSelect = row.Cells[0].Value.ToString();

            //Pasar las claves unicas del map a las editbox
            //Este fix es ridiculo pero funciona
            string claves_unicas = row.Cells[7].Value.ToString();
            string[] claves = claves_unicas.Split(':');
            string[] clavevs2 = claves[1].Split(' ');
            string[] elRfc = claves[2].Split(' ');
            eb_rfc_emp.Text = elRfc[1];
            eb_curp_emp.Text = clavevs2[1];
        }

        private void btn_borrar_emp_Click(object sender, EventArgs e)
        {
            if (id_empleadoSelect == null)
            {
                MessageBox.Show("Selecciona un empleado");
                return;
            }
            DatabaseManagement.getInstance().eraseEmployee(id_empleadoSelect, btn_emp_user.Text, btn_emp_pass.Text);
            MessageBox.Show("Empleado eliminado");
            updateDataGrid();
            id_empleadoSelect = null;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        public void updateDataGrid() {
            List<Employees> empleados = new List<Employees>();
            empleados = DatabaseManagement.getInstance().GetEmployees();

            List<EmployeesDTG> empDataGrid = new List<EmployeesDTG>();
            foreach (var empleado in empleados)
            {
                EmployeesDTG empleadoDTG = new EmployeesDTG();
                empleadoDTG.employee_id = empleado.employee_id;
                empleadoDTG.user_id = empleado.user_id;
                empleadoDTG.user = empleado.user;
                empleadoDTG.password = empleado.password;
                empleadoDTG.name = empleado.name;
                empleadoDTG.last_name = empleado.last_name;
                empleadoDTG.mother_last_name = empleado.mother_last_name;
                empleadoDTG.question = empleado.question;
                empleadoDTG.answer = empleado.answer;
                foreach (KeyValuePair<string, string> key in empleado.claves_unicas)
                {
                    empleadoDTG.claves_unicas += key.Key.ToString();
                    empleadoDTG.claves_unicas += " : ";
                    empleadoDTG.claves_unicas += key.Value.ToString();
                    empleadoDTG.claves_unicas += " ";
                }
                empleadoDTG.date_of_birth = empleado.date_of_birth.ToString();
                empDataGrid.Add(empleadoDTG);

            }

            EmployeesWinDtg.DataSource = empDataGrid;

            int i = 0;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //Activar un usuario
        private void btn_activar_Click(object sender, EventArgs e)
        {
            DatabaseManagement.getInstance().userUnban(eb_reactivar.Text);
            MessageBox.Show("Usuario reactivado");
        }

        private void Validar_Click(object sender, EventArgs e)
        {
            
                bool validaruser = true;
                bool validarpassword = true;
                bool validarnombre = true;
                bool validarAP = true;
                bool validarAM = true;
                bool validarRFC = true;
                //bool validarfecha = false;
                bool validarCURP = true;

                String username = this.btn_emp_user.Text;
                String password = this.btn_emp_pass.Text;
                String vnombre = this.eb_name_emp.Text;
                String vAP = this.eb_ap_emp.Text;
                String vAM = this.eb_am_emp.Text;
                String vRFC = this.eb_rfc_emp.Text;
                String vFecha = this.dtp_nac_emp.Text;
                String vCurp = this.eb_curp_emp.Text;


                string regexString = /*@"/^[A-Za-z]$/"*/ "^[A-Za-z0-9]*$"; //Permite letras y numeros
                string regexStringPass = "^[0-9A-Za-z]*$";
                string regexStringRFC = "^[0-9]*$";
                string regexStringnombre = "^[A-Za-z]*$";  //Codigo a poner !/^\s
                // string regexStringnombre = "^[A-Za-z]*$";
                string regexStringCurp = "[A-Za-z0-9]";


                //Validacion username
                if (Regex.IsMatch(username, regexString))
                {
                    MessageBox.Show("Muito bien");
                    //validaruser = true;

                }

                else
                {
                    validaruser = false;
                    MessageBox.Show("Solo se permiten letras y numeros. Ej: Luis123");
                }

                //Validacion password
                if (Regex.IsMatch(password, regexStringPass))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    MessageBox.Show("Solo se permiten numeros y letras. Ej: 123Pass");
                    validarpassword = false;
                }

                //Validacion nombre
                if (Regex.IsMatch(vnombre, regexStringnombre))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    validarnombre = false;
                    MessageBox.Show("Solo se permiten letras");

                }

                //Validacion AP
                if (Regex.IsMatch(vAP, regexStringnombre))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    validarAP = false;
                    MessageBox.Show("Solo se permiten letras");

                }

                //Validacion AM
                if (Regex.IsMatch(vAM, regexStringnombre))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    validarAM = false;
                    MessageBox.Show("Solo se permiten letras");

                }

                //Validacion RFC
                if (Regex.IsMatch(vRFC, regexStringRFC))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    validarRFC = false;
                    MessageBox.Show("Solo se permiten numeros");

                }

                //Validacion CURP
                if (Regex.IsMatch(vCurp, regexStringCurp))
                {

                    MessageBox.Show("Muito bien");
                }

                else
                {
                    validarCURP = false;
                    MessageBox.Show("Solo se permiten letras y numeros. Ej: IBP505");

                }

                if (validaruser == false || validarpassword == false || validarnombre == false || validarAP == false || validarAM == false || validarRFC == false || validarCURP == false)
                {
                //Da error
                estabien = false;
                    MessageBox.Show("ESTO DA ERROR");
                }
                else
                {
                //Aqui podemos asignar un booleano global para permitir o no agregar un empleado
                estabien = true;
                    MessageBox.Show("Esto no da error");
                }






            }
        
    }
}
