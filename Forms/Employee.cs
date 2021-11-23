using AAVD.Base_de_datos;
using AAVD.Entidades;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;
using System.Text.RegularExpressions;

namespace AAVD.Forms
{
    public partial class Employee : Form
    {
        //Init
        public Employee()
        {
            InitializeComponent();
            consumo_year.CustomFormat = "yyyy";
            consumo_year.Format = DateTimePickerFormat.Custom;
            consumo_month.CustomFormat = "MM";
            consumo_month.Format = DateTimePickerFormat.Custom;

            recibo_year.CustomFormat = "yyyy";
            recibo_year.Format = DateTimePickerFormat.Custom;
            recibo_mes.CustomFormat = "MM";
            recibo_mes.Format = DateTimePickerFormat.Custom;

            year_reciboPDF.CustomFormat = "yyyy";
            year_reciboPDF.Format = DateTimePickerFormat.Custom;
            month_reciboPDF.CustomFormat = "MM";
            month_reciboPDF.Format = DateTimePickerFormat.Custom;

            dtpConsumoH_year.CustomFormat = "yyyy";
            dtpConsumoH_year.Format = DateTimePickerFormat.Custom;

            edc_nacimiento.CustomFormat = "yyyy-MM-dd";
            edc_nacimiento.Format = DateTimePickerFormat.Custom;
            c_nacimiento.CustomFormat = "yyyy-MM-dd";
            c_nacimiento.Format = DateTimePickerFormat.Custom;


            this.contrato_Tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.eb_tipoTarifa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.edc_contrato.DropDownStyle = ComboBoxStyle.DropDownList;
            this.c_contratoTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.c_genero.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CenterToScreen();
            updateDataGrid();
            updateDataGridTarifa();
            updateDataGridConsumos();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //Boton para dar de alta un cliente
        private void button6_Click(object sender, EventArgs e)
        {
            if (c_contratoTipo.Text.Equals(""))
            {
                MessageBox.Show("Ningun espacio puede estar vacio");
                return;
            }


            bool validaruser = true;
            bool validarpassword = true;
            bool validarnombre = true;
            bool validarAP = true;
            bool validarAM = true;
            bool validarCURP = true;

            bool validarCiudad = true;
            bool validarCalle = true;
            bool validarColonia = true;
            bool validarEstado = true;

            bool estabien = true;

            String username = this.c_usuario.Text;
            String password = this.c_password.Text;
            String vnombre = this.c_nombre.Text;
            String vAP = this.c_apellidoP.Text;
            String vAM = this.c_apellidoM.Text;
            //Domicilio
            String vCiudad = this.c_ciudad.Text;
            String vCalle = this.c_calle.Text;
            String vColonia = this.c_colonia.Text;
            String vEstado = this.c_estado.Text;

            //String vRFC = this.eb_rfc_emp.Text;
            //String vFecha = this.dtp_nac_emp.Text;
            String vCurp = this.c_curp.Text;


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
            }

            //Validacion password
            if (Regex.IsMatch(password, regexStringPass))
            {

            }

            else
            {
                validarpassword = false;
            }

            //Validacion nombre
            if (Regex.IsMatch(vnombre, regexStringnombre))
            {

            }

            else
            {
                validarnombre = false;

            }

            //Validacion AP
            if (Regex.IsMatch(vAP, regexStringnombre))
            {

            }

            else
            {
                validarAP = false;

            }

            //Validacion AM
            if (Regex.IsMatch(vAM, regexStringnombre))
            {

            }

            else
            {
                validarAM = false;

            }



            //Validacion CURP
            if (Regex.IsMatch(vCurp, regexStringCurp))
            {

            }

            else
            {
                validarCURP = false;

            }

            //validacion Colonia

            if (Regex.IsMatch(vColonia, regexStringnombre))
            {

            }

            else
            {
                validarColonia = false;

            }

            //Validar Ciudad

            if (Regex.IsMatch(vCiudad, regexStringnombre))
            {

            }

            else
            {
                validarCiudad = false;

            }

            //Validar Calle

            if (Regex.IsMatch(vCalle, regexStringnombre))
            {

            }

            else
            {
                validarCalle = false;

            }

            //Validar Estado

            if (Regex.IsMatch(vEstado, regexStringnombre))
            {

            }

            else
            {
                validarEstado = false;

            }






            //Validacion de todos los campos
            if (validaruser == false || validarpassword == false || validarnombre == false || validarAP == false
                || validarAM == false || validarCURP == false || validarCalle == false || validarCiudad == false
                || validarEstado == false || validarColonia == false)
            {
                estabien = false;
                //Da error
                MessageBox.Show("Error en el llenado de los campos");
            }
            else
            {
                //Aqui podemos asignar un booleano global para permitir o no agregar un empleado
                estabien = true;
            }

            //Validacion de que no se repiten medidores
            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratos();
            foreach (var contrato in contratos)
            {
                if ((contrato.num_medidor.ToString()).Equals(nud_Medidor.Value.ToString()))
                {
                    MessageBox.Show("Ese numero de medidor ya esta en uso");
                    return;
                }
                if ((contrato.num_servicio.ToString()).Equals(nud_Servicio.Value.ToString()))
                {
                    MessageBox.Show("Ese numero de servicio ya esta en uso");
                    return;
                }
            }

            List<Clientes> listaNumClientes = new List<Clientes>();
            listaNumClientes = DatabaseManagement.getInstance().GetClients();
            foreach (var cliente in listaNumClientes)
            {
                if (cliente.num_cliente.ToString().Equals(nud_Cliente.Value.ToString()))
                {
                    MessageBox.Show("Ese numero de cliente ya esta en uso");
                    return;
                }
            }

            if (estabien == true)
            {
                //Quehacer
                //Registramos al cliente en la tbala de usuarios
                DatabaseManagement database = DatabaseManagement.getInstance();
                if (!(database.registerUser(c_usuario.Text, c_password.Text, 2, c_pregunta.Text, c_respuesta.Text)))
                {
                    MessageBox.Show("No se pueden repetir usuarios");
                    return;
                }
                List<Users> user = new List<Users>();
                user = database.getLogin(c_usuario.Text, c_password.Text);
                Guid new_user_id;
                foreach (var data in user)
                {
                    new_user_id = data.user_id;
                    database.registerClient(c_nombre.Text, c_apellidoP.Text, c_apellidoM.Text, c_email.Text, c_curp.Text, c_genero.Text, c_nacimiento.Value.ToString("yyyy-MM-dd"), c_ciudad.Text, c_calle.Text, c_colonia.Text, c_estado.Text, c_contratoTipo.Text, c_usuario.Text, c_password.Text, new_user_id, nud_Medidor.Value.ToString(), nud_Servicio.Value.ToString(), nud_Cliente.Value.ToString());
                }
                MessageBox.Show("Cliente registrado con exito.");
                updateDataGrid();
                //Quehacerfin
            }
            else
            {
                MessageBox.Show("Rellene de forma correcta los campos.");
            }


        }

        //Funcion que envia los datos al datagrid
        public void updateDataGrid()
        {

            List<Clientes> clientes = new List<Clientes>();
            clientes = DatabaseManagement.getInstance().GetClients();

            List<ClientesDTG> cntDataGrid = new List<ClientesDTG>();
            foreach (var cliente in clientes)
            {
                ClientesDTG clienteDTG = new ClientesDTG();
                clienteDTG.name = cliente.name;
                clienteDTG.last_name = cliente.last_name;
                clienteDTG.mother_last_name = cliente.mother_last_name;
                clienteDTG.user = cliente.user;
                clienteDTG.password = cliente.password;
                clienteDTG.date_of_birth = cliente.date_of_birth.ToString();
                clienteDTG.gender = cliente.gender;
                clienteDTG.contract_type = cliente.contract_type;
                clienteDTG.street = cliente.street;
                clienteDTG.colony = cliente.colony;
                clienteDTG.city = cliente.city;
                clienteDTG.state = cliente.state;
                clienteDTG.email = cliente.email;
                clienteDTG.curp = cliente.curp;
                clienteDTG.user_id = cliente.user_id;
                clienteDTG.num_cliente = cliente.num_cliente.ToString();
                clienteDTG.client_id = cliente.client_id;
                cntDataGrid.Add(clienteDTG);

            }

            clientesDTGWN.DataSource = cntDataGrid;
            ClientesBorrarDTG.DataSource = cntDataGrid;

            int i = 0;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            List<Clientes> clientes = new List<Clientes>();
            clientes = DatabaseManagement.getInstance().GetClients();
            updateDataGrid();
            int i = 0;
        }

        private void clientesDTGWN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string id_seleccionado;
        string id_seleccionado_borrar;
        string user;
        string password;
        //Envia los datos del datagrid a la ventana
        //Los indices de Cells[] son dependiendo del orden en el que fueron declaradas las variables en ClientesDTG.cs
        private void clientesDTGWN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0)
            {
                MessageBox.Show("Selecciona a un empleado");
                return;
            }
            DataGridViewRow row = clientesDTGWN.Rows[indexRow];
            if (row == null)
                return;

            edc_nombre.Text = row.Cells[2].Value.ToString();
            edc_apellidoP.Text = row.Cells[3].Value.ToString();
            edc_apellidoM.Text = row.Cells[4].Value.ToString();
            edc_nacimiento.Text = row.Cells[5].Value.ToString();
            edc_genero.Text = row.Cells[6].Value.ToString();
            edc_ciudad.Text = row.Cells[7].Value.ToString();
            edc_calle.Text = row.Cells[8].Value.ToString();
            edc_colonia.Text = row.Cells[9].Value.ToString();
            edc_estado.Text = row.Cells[10].Value.ToString();
            edc_contrato.Text = row.Cells[11].Value.ToString();
            edc_usuario.Text = row.Cells[12].Value.ToString();
            edc_password.Text = row.Cells[13].Value.ToString();
            edc_email.Text = row.Cells[14].Value.ToString();
            edc_curp.Text = row.Cells[15].Value.ToString();
            edc_numCliente.Text = row.Cells[16].Value.ToString();
            id_seleccionado = row.Cells[1].Value.ToString();
        }

        //Click al boton de actualizar cliente
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (id_seleccionado == null)
            {
                MessageBox.Show("No has seleccionando ningun cliente.");
                return;
            }
            DatabaseManagement.getInstance().updateClient(edc_nombre.Text, edc_apellidoP.Text, edc_apellidoM.Text, edc_email.Text, edc_curp.Text, edc_genero.Text, edc_nacimiento.Value.ToString("yyyy-MM-dd"), edc_ciudad.Text, edc_calle.Text, edc_colonia.Text, edc_estado.Text, edc_contrato.Text, edc_usuario.Text, edc_password.Text, id_seleccionado, edc_numCliente.Text);
            id_seleccionado = null;
            MessageBox.Show("Cliente actualizado con exito.");
            updateDataGrid();
        }

        //Seleccionar un cliente para borrar
        private void ClientesBorrarDTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = clientesDTGWN.Rows[indexRow];
            if (row == null)
                return;
            id_seleccionado_borrar = row.Cells[1].Value.ToString();
            user = row.Cells[12].Value.ToString();
            password = row.Cells[14].Value.ToString();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (id_seleccionado_borrar == null)
            {
                MessageBox.Show("No has seleccionando ningun cliente.");
                return;
            }
            DatabaseManagement.getInstance().eraseClient(id_seleccionado_borrar, user, password);
            id_seleccionado_borrar = null;
            MessageBox.Show("Cliente borrado con exito.");
            updateDataGrid();
        }


        //Definir las tarifas
        private void btn_agregar_tarifa_Click(object sender, EventArgs e)
        {
            DatabaseManagement.getInstance().crearTarifa(eb_tipoTarifa.Text, eb_TarifaBasica.Text, eb_TarifaIntermedia.Text, eb_TarifaExcedente.Text);
            MessageBox.Show("Tarifa actualizada");
            updateDataGridTarifa();
            updateDataGridReporteTarifa();
        }

        //Poner las tarifas en ventana
        public void updateDataGridTarifa()
        {

            List<Tarifas> tarifas = new List<Tarifas>();
            tarifas = DatabaseManagement.getInstance().GetTarifas();

            List<Tarifas> tfDTG = new List<Tarifas>();
            foreach (var tarifa in tarifas)
            {
                Tarifas tarifaDTG = new Tarifas();
                tarifaDTG.tipo = tarifa.tipo;
                tarifaDTG.basico = tarifa.basico;
                tarifaDTG.intermedio = tarifa.intermedio;
                tarifaDTG.excedente = tarifa.excedente;
                tfDTG.Add(tarifaDTG);

            }
            TarifasFTG_WN.DataSource = tfDTG;
        }

        public void updateDataGridReporteTarifa()
        {

            List<Tarifas> tarifas = new List<Tarifas>();
            tarifas = DatabaseManagement.getInstance().GetTarifas();

            List<Tarifas> tfDTG = new List<Tarifas>();
            foreach (var tarifa in tarifas)
            {
                Tarifas tarifaDTG = new Tarifas();
                tarifaDTG.tipo = tarifa.tipo;
                tarifaDTG.basico = tarifa.basico;
                tarifaDTG.intermedio = tarifa.intermedio;
                tarifaDTG.excedente = tarifa.excedente;
                tfDTG.Add(tarifaDTG);

            }
            dataGridView2.DataSource = tfDTG;
        }




        private void csv_tarifas_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string csvPath = "";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos de informacion excel (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                csvPath = openFileDialog1.FileName;
            }
            var result = csvPath.Substring(csvPath.Length - 3);
            if (result != "csv")
            {
                MessageBox.Show("Escoge un direccion valida");
                return;
            }

            if (csvPath.Equals(""))
            {
                return;
            }

            var reader = File.OpenText(csvPath);
            var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
            var tarifasCSV = csvReader.GetRecords<TarifasCSV>();
            foreach (var tarifa in tarifasCSV)
            {
                DatabaseManagement.getInstance().crearTarifa(tarifa.tipo, tarifa.basico.ToString(), tarifa.intermedio.ToString(), tarifa.excedente.ToString());
            }
            MessageBox.Show("Listo, tarifas cargadas...");
        }


        //Generar el pdf del recibo
        //Este codigo parece confeti, ayuuudaaaaaa
        private void button7_Click(object sender, EventArgs e)
        {
            if (eb_user_recibo.Text.Equals("")) {
                MessageBox.Show("Ingresa un medidor");
                return;
            }



            string id_usuario = "";
            List<Users> users = new List<Users>();
            users = DatabaseManagement.getInstance().getRemember(eb_user_recibo.Text);
            foreach (var usuarioSimple in users)
            {
                List<Users> usersFull = new List<Users>();
                usersFull = DatabaseManagement.getInstance().getLogin(usuarioSimple.user_name, usuarioSimple.password);
                foreach (var fullUser in usersFull)
                {
                    id_usuario = fullUser.user_id.ToString();
                }
            }

            string id_cliente = "";
            string tipo = "";
            string no_servicio = "";
            int creacionYear = 0;
            int creacionMonth = 0;
            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratosMedidorTipo();
            foreach (var contrato in contratos)
            {
                if ((contrato.num_medidor.ToString()).Equals(eb_user_recibo.Text))
                {
                    id_cliente = contrato.id_cliente.ToString();
                    tipo = contrato.tipo;
                    no_servicio = contrato.num_servicio.ToString();
                    creacionYear = int.Parse(contrato.creation_year);
                    creacionMonth = int.Parse(contrato.creation_month);
                }
            }

            if (no_servicio.Equals(""))
            {
                MessageBox.Show("Ese medidor no existe en la base de datos");
                return;
            }

            bool consumoExiste = false;
            List<Consumos> consumoValidacion = new List<Consumos>();
            consumoValidacion = DatabaseManagement.getInstance().getConsumos();
            foreach (var consumo in consumoValidacion)
            {
                if (consumo.num_medidor.ToString().Equals(eb_user_recibo.Text) && consumo.year.ToString().Equals(year_reciboPDF.Text) && consumo.month.ToString().Equals(month_reciboPDF.Text))
                {
                    consumoExiste = true;
                }
            }

            if (!consumoExiste)
            {
                MessageBox.Show("No hay ningun consumo en esa fecha");
                return;
            }


            //Checa si el medidor tiene consumos
            bool hayConsumos = false;
            double cuentaTotal = 0;
            List<Consumos> consumosMedidor = new List<Consumos>();
            consumosMedidor = DatabaseManagement.getInstance().getConsumos();
            foreach (var consumos in consumosMedidor)
            {
                if (consumos.num_medidor.ToString().Equals(no_servicio))
                {
                    hayConsumos = true;
                    DateTime inicioFactura = new DateTime(creacionYear, creacionMonth, 4);
                    DateTime facturaActual = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 4);
                    DateTime iteradorFactura = new DateTime(int.Parse(consumos.year), int.Parse(consumos.month), 4);
                    int cuando = DateTime.Compare(iteradorFactura, facturaActual);
                    if (cuando < 0)
                    {
                        cuentaTotal = consumos.consumo + cuentaTotal;
                    }
                }
            }

            if (!hayConsumos)
            {
                MessageBox.Show("Ese medidor no tiene consumos");
                return;
            }

            //Encontramos la tarifa que usamos
            List<Tarifas> tarifas = new List<Tarifas>();
            tarifas = DatabaseManagement.getInstance().GetTarifas();
            double tarifaBasica, tarifaIntermedia, tarifaExcedente;
            tarifaExcedente = tarifaIntermedia = tarifaBasica = 0;
            foreach (var tarifa in tarifas)
            {
                if (tarifa.tipo.Equals(tipo))
                {
                    tarifaExcedente = tarifa.excedente;
                    tarifaIntermedia = tarifa.intermedio;
                    tarifaBasica = tarifa.basico;
                }
            }

            List<Clientes> cliente = new List<Clientes>();
            cliente = DatabaseManagement.getInstance().getContratoConClientID(id_cliente);
            foreach (var dato in cliente)
            {
                //Prepara todas las variables para el pdf
                Document pdfDocument = new Document();
                Page page1 = pdfDocument.Pages.Add();

                BackgroundArtifact bg = new BackgroundArtifact();
                bg.BackgroundImage = File.OpenRead("CFE.png");

                page1.Artifacts.Add(bg);
                string nombreFull = dato.name + " " + dato.last_name + " " + dato.mother_last_name;
                agregarTexto(117, 715, nombreFull, page1);
                string direccion = dato.street + " " + dato.colony + " " + dato.city + " " + dato.state + " ";
                agregarTexto(105, 680, direccion, page1);
                //Numero de servicio
                agregarTexto(115, 600, no_servicio, page1);
                //RMU
                agregarTexto(50, 578, id_cliente, page1);

                if (tipo.Equals("Industrial"))
                {
                    //Limite de pago 
                    DateTime limiteDePago = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 3);
                    limiteDePago = limiteDePago.AddDays(20);
                    agregarTexto(110, 530, limiteDePago.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    //Corte a partir de 
                    DateTime corteLimite = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 4);
                    corteLimite = corteLimite.AddDays(21);
                    agregarTexto(10, 480, corteLimite.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    //Tiempo de facturacion:
                    DateTime fechaFacturacion = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 3);
                    fechaFacturacion = fechaFacturacion.AddMonths(-1);
                    agregarTexto(135, 380, fechaFacturacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    agregarTexto(200, 380, "-", page1);
                    fechaFacturacion = fechaFacturacion.AddMonths(1);
                    agregarTexto(208, 380, fechaFacturacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                }
                else if (tipo.Equals("Domestico"))
                {
                    //Limite de pago 
                    DateTime limiteDePago = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 3);
                    limiteDePago = limiteDePago.AddDays(20);
                    limiteDePago = limiteDePago.AddMonths(1);
                    agregarTexto(110, 530, limiteDePago.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    //Corte a partir de 
                    DateTime corteLimite = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 4);
                    corteLimite = corteLimite.AddDays(21);
                    corteLimite = corteLimite.AddMonths(1);
                    agregarTexto(10, 480, corteLimite.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    //Tiempo de facturacion:
                    DateTime fechaFacturacion = new DateTime(int.Parse(year_reciboPDF.Text), int.Parse(month_reciboPDF.Text), 3);
                    fechaFacturacion = fechaFacturacion.AddMonths(-1);
                    agregarTexto(135, 380, fechaFacturacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                    agregarTexto(200, 380, "-", page1);
                    fechaFacturacion = fechaFacturacion.AddMonths(2);
                    agregarTexto(208, 380, fechaFacturacion.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), page1);
                }
                //Encontrar el recibo especifico
                List<Recibos> recibos = new List<Recibos>();
                recibos = DatabaseManagement.getInstance().getReciboEspecifico(eb_user_recibo.Text, year_reciboPDF.Text, month_reciboPDF.Text);
                foreach (var recibo in recibos)
                {
                    double totalAPagar = Math.Round(recibo.pagar_total_iva, 3);
                    agregarTexto(400, 705, totalAPagar.ToString(), page1);
                    //Imprimir el total en letras
                    decimal totalTransformarEnteros = (decimal)totalAPagar;
                    string enteros = totalAPagar.ToString();
                    string[] numEnteros = enteros.Split('.');
                    decimal letrasTransformarEnteros = decimal.Parse(numEnteros[0]);

                    string totalLetras = Conversiones.NumeroALetras(letrasTransformarEnteros);
                    //agregarTexto(400, 690, totalLetras, page1);
                    TextFragment totalImprimir = new TextFragment(totalLetras);
                    totalImprimir.Position = new Position(400, 685);
                    totalImprimir.TextState.FontSize = 10;
                    totalImprimir.TextState.Font = FontRepository.FindFont("Arial");
                    totalImprimir.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
                    TextBuilder txtBuild = new TextBuilder(page1);
                    txtBuild.AppendText(totalImprimir);


                    decimal totalTransformarDecimales = (decimal)(totalAPagar - Math.Truncate(totalAPagar));

                    string totalEnString = totalAPagar.ToString();
                    if ((totalEnString.IndexOf('.') != -1))
                    {
                        string[] separarNumeros = totalEnString.Split('.');
                        decimal numeroDecimal = decimal.Parse(separarNumeros[1]);
                        string totalLetrasDecimales = "PUNTO " + Conversiones.NumeroALetras(numeroDecimal);
                        TextFragment totalImprimirDecimal = new TextFragment(totalLetrasDecimales);
                        totalImprimirDecimal.Position = new Position(400, 675);
                        totalImprimirDecimal.TextState.FontSize = 10;
                        totalImprimirDecimal.TextState.Font = FontRepository.FindFont("Arial");
                        totalImprimirDecimal.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
                        TextBuilder txtBuildDecimal = new TextBuilder(page1);
                        txtBuildDecimal.AppendText(totalImprimirDecimal);
                    }



                    agregarTexto(175, 427, recibo.num_medidor.ToString(), page1);
                    string totalKw = (recibo.kw_basico + recibo.kw_intermedio + recibo.kw_excedente).ToString();
                    agregarTexto(382, 305, totalKw, page1);
                    agregarTexto(382, 290, recibo.kw_basico.ToString(), page1);
                    agregarTexto(382, 275, recibo.kw_intermedio.ToString(), page1);
                    agregarTexto(382, 263, recibo.kw_excedente.ToString(), page1);
                    agregarTexto(382, 250, totalKw.ToString(), page1);
                    //Imprimir tarifas
                    tarifaBasica = Math.Round(tarifaBasica, 4);
                    tarifaIntermedia = Math.Round(tarifaIntermedia, 4);
                    tarifaExcedente = Math.Round(tarifaExcedente, 4);
                    agregarTexto(450, 290, tarifaBasica.ToString(), page1);
                    agregarTexto(450, 275, tarifaIntermedia.ToString(), page1);
                    agregarTexto(450, 263, tarifaExcedente.ToString(), page1);

                    //Imprimimos los precios
                    agregarTexto(520, 290, (Math.Round(recibo.pagar_basico, 3)).ToString(), page1);
                    agregarTexto(520, 275, (Math.Round(recibo.pagar_intermedio, 3)).ToString(), page1);
                    agregarTexto(520, 263, (Math.Round(recibo.pagar_excedente, 3)).ToString(), page1);
                    double total = Math.Round(recibo.pagar_basico + recibo.pagar_intermedio + recibo.pagar_excedente, 3);
                    agregarTexto(520, 250, total.ToString(), page1);

                    //Pago por energia
                    agregarTexto(520, 120, total.ToString(), page1);
                    //El iva
                    double impuesto = Math.Round(total * 0.16, 3);
                    agregarTexto(520, 105, impuesto.ToString(), page1);
                    //Fac del periodo 
                    double totalConIva = Math.Round(recibo.pagar_total_iva, 3);
                    agregarTexto(520, 87, totalConIva.ToString(), page1);



                    //Adeudo anterior
                    double adeudo = 0;
                    double adeudoSinSigno = 0;
                    List<Recibos> anteriores = new List<Recibos>();
                    anteriores = DatabaseManagement.getInstance().getRecibos();
                    foreach (var reciboAnterior in anteriores)
                    {
                        if (reciboAnterior.num_medidor.ToString().Equals(recibo.num_medidor.ToString()))
                        {
                            DateTime reciboAnteriorFecha = new DateTime(int.Parse(reciboAnterior.year), int.Parse(reciboAnterior.month), 3);
                            DateTime reciboActualFecha = new DateTime(int.Parse(recibo.year), int.Parse(recibo.month), 3);
                            int comparacion = DateTime.Compare(reciboAnteriorFecha, reciboActualFecha);
                            if (comparacion < 0)
                            {
                                if (reciboAnterior.pagado.Equals("SIN PAGAR"))
                                {
                                    adeudo = reciboAnterior.pagar_total_iva;
                                    adeudoSinSigno = reciboAnterior.pagar_total_iva;
                                }
                                else if (reciboAnterior.pagado.Equals("PAGADO"))
                                {
                                    adeudo = -1.0f * (reciboAnterior.pagar_total_iva);
                                    adeudoSinSigno = reciboAnterior.pagar_total_iva;
                                }
                            }
                        }
                    }
                    double adeudoSinSignoDecimales = Math.Round(adeudoSinSigno, 3);
                    agregarTexto(520, 73, adeudoSinSignoDecimales.ToString(), page1);
                    double adeudoDecimales = Math.Round(adeudo, 3);
                    //Su pago

                    agregarTexto(520, 57, adeudoDecimales.ToString(), page1);


                    //Total
                    if (adeudo > 0)
                    {
                        double totalConDeuda = totalConIva + adeudo;
                        totalConDeuda = Math.Round(totalConDeuda, 3);
                        agregarTexto(520, 43, totalConDeuda.ToString(), page1);
                    }
                    else
                    {
                        agregarTexto(520, 43, totalConIva.ToString(), page1);
                    }

                    //Lectura anterior
                    agregarTexto(250, 305, cuentaTotal.ToString(), page1);
                    //Lectura actual
                    cuentaTotal += double.Parse(totalKw);
                    agregarTexto(150, 305, cuentaTotal.ToString(), page1);
                }

                string folderPath = "";
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog1.SelectedPath;
                }

                String pdfName = folderPath + "\\LmadEstadoDeCuenta_.pdf";
                if (folderPath.Equals(""))
                {
                    return;
                }
                pdfDocument.Save(pdfName);
                MessageBox.Show("Recibo creado");
            }
        }


        public void agregarTexto(int x, int y, string texto, Page pagina)
        {
            TextFragment txtName = new TextFragment(texto);
            txtName.Position = new Position(x, y);
            txtName.TextState.FontSize = 12;
            txtName.TextState.Font = FontRepository.FindFont("Arial");
            txtName.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            TextBuilder txtBuild = new TextBuilder(pagina);
            txtBuild.AppendText(txtName);
        }

        //Cargar un consumo
        private void btn_consumo_Click(object sender, EventArgs e)
        {
            //Checamos si ya existe un consumo para esos datos
            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();
            foreach (var consumo in consumos)
            {
                if ((consumo.num_medidor.ToString() == consumo_medidor.Text) && (consumo.year == consumo_year.Text) && (consumo.month == consumo_month.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Este periodo ya tiene valores asignados. ¿Deseas sobreescribirlos?", "Existente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //Se regresa
                        return;
                    }
                }

            }

            //Checamos si el medidor existe
            bool existe = false;
            List<Contratos> medidores = new List<Contratos>();
            medidores = DatabaseManagement.getInstance().numerosMedidores();
            foreach (var medidor in medidores)
            {
                if (medidor.num_medidor.ToString().Equals(consumo_medidor.Text))
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                MessageBox.Show("Medidor invalido");
                return;
            }

            //Encontramos si la fecha es valida


            //Encontramos el tipo de contrato al que esta asignado el medidor
            string tipo_contrato = "";
            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratosMedidorTipo();
            foreach (var contrato in contratos)
            {
                if (contrato.num_medidor.ToString().Equals(consumo_medidor.Text))
                {
                    tipo_contrato = contrato.tipo;
                }
                if ((int.Parse(contrato.creation_year) > int.Parse(consumo_year.Text)) && (int.Parse(contrato.creation_month) > int.Parse(consumo_month.Text)))
                {
                    MessageBox.Show("El contrato no cubre esa fecha.");
                    return;
                }

                if ((int.Parse(contrato.creation_year) == int.Parse(consumo_year.Text)) && (int.Parse(contrato.creation_month) > int.Parse(consumo_month.Text)))
                {
                    MessageBox.Show("El contrato no cubre esa fecha.");
                    return;
                }

            }

            if (tipo_contrato == "Domestico")
            {
                List<Consumos> consumos2 = new List<Consumos>();
                consumos2 = DatabaseManagement.getInstance().getConsumoMeses(consumo_medidor.Text);
                foreach (var consumo in consumos2)
                {
                    if (int.Parse(consumo.month) + 1 == int.Parse(consumo_month.Text))
                    {
                        MessageBox.Show("Este mes ya esta tomado en cuenta.");
                        return;
                    }
                }
            }

            DatabaseManagement.getInstance().insertConsumo(consumo_medidor.Text, consumo_kw.Text, consumo_year.Text, consumo_month.Text);
            MessageBox.Show("Consumo registrado");
            updateDataGridConsumos();
        }

        //Poner los consumos en el data grid
        public void updateDataGridConsumos()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                Consumos consumoDTG = new Consumos();
                consumoDTG.num_medidor = consumo.num_medidor;
                consumoDTG.consumo = consumo.consumo;
                consumoDTG.month = consumo.month;
                consumoDTG.year = consumo.year;
                csmDTG.Add(consumo);

            }
            ConsumosDTG_WN.DataSource = csmDTG;
        }

        public void updateDataGridReportesConsumos()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                Consumos consumoDTG = new Consumos();
                consumoDTG.num_medidor = consumo.num_medidor;
                consumoDTG.consumo = consumo.consumo;
                consumoDTG.month = consumo.month;
                consumoDTG.year = consumo.year;
                csmDTG.Add(consumo);

            }
            dataGridView1.DataSource = csmDTG;
        }

        //Carga masiva de consumos
        private void carga_consumos_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string csvPath = "";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos de informacion excel (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                csvPath = openFileDialog1.FileName;
            }
            var result = csvPath.Substring(csvPath.Length - 3);
            if (result != "csv")
            {
                MessageBox.Show("Escoge un direccion valida");
                return;
            }

            if (csvPath.Equals(""))
            {
                return;
            }

            var reader = File.OpenText(csvPath);
            var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
            var consumosCSV = csvReader.GetRecords<ConsumosCSV>();
            foreach (var consumo in consumosCSV)
            {
                DatabaseManagement.getInstance().insertConsumo(consumo.numMedidor.ToString(), consumo.consumo.ToString(), consumo.year, consumo.month);
            }
            MessageBox.Show("Listo, consumos cargados...");
            updateDataGridConsumos();
        }

        //Mostrar un recibo en la pantalla
        private void button7_Click_1(object sender, EventArgs e)
        {

            string id_cliente = "";
            string tipo = "";
            string no_servicio = "";
            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratosMedidorTipo();
            foreach (var contrato in contratos)
            {
                if ((contrato.num_medidor.ToString()).Equals(tb_medidor.Text))
                {
                    id_cliente = contrato.id_cliente.ToString();
                    tipo = contrato.tipo;
                    no_servicio = contrato.num_servicio.ToString();
                }
            }

            if (no_servicio.Equals(""))
            {
                MessageBox.Show("Ese medidor no existe en la base de datos");
                return;
            }


            //Checa si el medidor tiene consumos
            bool hayConsumos = false;
            List<Consumos> consumosMedidor = new List<Consumos>();
            consumosMedidor = DatabaseManagement.getInstance().getConsumos();
            foreach (var consumos in consumosMedidor)
            {
                if (consumos.num_medidor.ToString().Equals(no_servicio))
                {
                    hayConsumos = true;
                }
            }

            if (!hayConsumos)
            {
                MessageBox.Show("Ese medidor no tiene consumos");
                return;
            }

            bool consumoExiste = false;
            List<Consumos> consumoValidacion = new List<Consumos>();
            consumoValidacion = DatabaseManagement.getInstance().getConsumos();
            foreach (var consumo in consumoValidacion)
            {
                if (consumo.num_medidor.ToString().Equals(tb_medidor.Text) && consumo.year.ToString().Equals(recibo_year.Text) && consumo.month.ToString().Equals(recibo_mes.Text))
                {
                    consumoExiste = true;
                }
            }

            if (!consumoExiste)
            {
                MessageBox.Show("No hay ningun consumo en esa fecha");
                return;
            }


            double adeudo = 0;
            List<Recibos> recibosAnteriores = new List<Recibos>();
            recibosAnteriores = DatabaseManagement.getInstance().getRecibos();
            List<Recibos> recibosActual = new List<Recibos>();
            recibosActual = DatabaseManagement.getInstance().getReciboEspecifico(tb_medidor.Text, recibo_year.Text, recibo_mes.Text);
            foreach (var recibo2 in recibosAnteriores)
            {
                foreach (var reciboActual in recibosActual)
                {
                    if (recibo2.num_medidor.ToString().Equals(reciboActual.num_medidor.ToString()))
                    {
                        DateTime reciboAnteriorFecha = new DateTime(int.Parse(recibo2.year), int.Parse(recibo2.month), 3);
                        DateTime reciboActualFecha = new DateTime(int.Parse(reciboActual.year), int.Parse(reciboActual.month), 3);
                        int comparacion = DateTime.Compare(reciboAnteriorFecha, reciboActualFecha);
                        if (comparacion < 0)
                        {
                            if (recibo2.pagado.Equals("SIN PAGAR"))
                            {
                                adeudo = recibo2.pagar_total_iva;
                            }
                            else if (recibo2.pagado.Equals("PAGADO"))
                            {
                                adeudo = 0;
                            }
                        }
                    }
                }
            }


            List<Recibos> recibo = new List<Recibos>();
            recibo = DatabaseManagement.getInstance().getReciboEspecifico(tb_medidor.Text, recibo_year.Text, recibo_mes.Text);
            foreach (var reciboNode in recibo)
            {
                recibo_kwBasicos.Text = reciboNode.kw_basico.ToString();
                recibo_kwIntermedios.Text = reciboNode.kw_intermedio.ToString();
                recibo_kwExcedentes.Text = reciboNode.kw_excedente.ToString();
                recibos_kwTotales.Text = (reciboNode.kw_basico + reciboNode.kw_intermedio + reciboNode.kw_excedente).ToString();
                double tBasico = Math.Round(reciboNode.pagar_basico, 4);
                tx_totalBasico.Text = tBasico.ToString();
                double tIntermedio = Math.Round(reciboNode.pagar_intermedio, 4);
                tx_totalIntermedio.Text = tIntermedio.ToString();
                double tExedente = Math.Round(reciboNode.pagar_excedente, 4);
                tx_totalExcedente.Text = tExedente.ToString();
                double total = Math.Round(reciboNode.pagar_total_iva + adeudo, 4);
                tx_totalFinal.Text = total.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //Asignar un contrato
        private void button9_Click(object sender, EventArgs e)
        {
            if (contrato_Tipo.Text.Equals("")) {
                MessageBox.Show("Ningun espacio puede estar vacio");
                return;
            }

            if (nud_ClienteNC.Value <= 0) {
                MessageBox.Show("Numero de cliente invalido");
                return;
            }
            if (nud_MedidorNC.Value <= 0)
            {
                MessageBox.Show("Numero de medidor invalido");
                return;
            }
            if (nud_ServicioNC.Value <= 0)
            {
                MessageBox.Show("Numero de servicio invalido");
                return;
            }

            List <Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratos();
            foreach (var contrato in contratos)
            {
                if ((contrato.num_medidor.ToString()).Equals(nud_MedidorNC.Value.ToString()))
                {
                    MessageBox.Show("Ese numero de medidor ya esta en uso");
                    return;
                }
                if ((contrato.num_servicio.ToString()).Equals(nud_ServicioNC.Value.ToString()))
                {
                    MessageBox.Show("Ese numero de servicio ya esta en uso");
                    return;
                }
            }
            DatabaseManagement.getInstance().updateContratos(nud_ClienteNC.Value.ToString(), contrato_Tipo.Text, nud_MedidorNC.Value.ToString(), nud_ServicioNC.Value.ToString());
            MessageBox.Show("Nuevo contrato asociado a el cliente.");
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void TarifasFTG_WN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AQUI


            updateDataGridReporteTarifa();
        }

        private void ConsumosDTG_WN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDataGridReportesConsumos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Se cambia el a;o en el reporte de consumo historico
        private void dtpConsumoH_year_ValueChanged(object sender, EventArgs e)
        {
            List<Contratos> contracts = new List<Contratos>();
            contracts = DatabaseManagement.getInstance().GetContratos();
            double medidorServicio = 0;

            List<Recibos> recibos = new List<Recibos>();
            recibos = DatabaseManagement.getInstance().getRecibos();

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                foreach (var contract in contracts)
                {
                    if (contract.num_medidor.ToString().Equals(consumo.num_medidor.ToString()))
                    {
                        medidorServicio = contract.num_servicio;
                        consumo.num_servicio = medidorServicio;
                    }
                }

                if (dtpConsumoH_year.Text.Equals(consumo.year)){
                    Consumos consumoDTG = new Consumos();
                    consumoDTG.num_medidor = consumo.num_medidor;
                    consumoDTG.consumo = consumo.consumo;
                    consumoDTG.month = consumo.month;
                    consumoDTG.num_servicio = consumo.num_servicio;
                    consumoDTG.year = consumo.year;

                    consumoDTG.kw_basico = 100;
                    foreach (var contract in contracts)
                    {
                        if (contract.num_medidor == consumo.num_medidor)
                        {
                            consumo.num_servicio = (int)contract.num_servicio;
                            consumoDTG.num_servicio = consumo.num_servicio;
                        }
                    }

                    foreach (var recibo in recibos) {
                        if (recibo.year.Equals(consumo.year) && recibo.month.Equals(consumo.month) && recibo.num_medidor.ToString().Equals(consumo.num_medidor.ToString())) {
                            if (recibo.pagado.Equals("SIN PAGAR")){
                                consumo.pendiente_pago = recibo.pagar_total_iva;
                                consumoDTG.pendiente_pago = Math.Round(consumo.pendiente_pago,4);
                            }
                        }
                    }

                    csmDTG.Add(consumo);
                }

            }
            
            consumoHistorico_EMPGTD.DataSource = csmDTG;
            consumoHistorico_EMPGTD.Columns[4].Visible = false;
            consumoHistorico_EMPGTD.Columns[5].Visible = false;
            consumoHistorico_EMPGTD.Columns[6].Visible = false;
            consumoHistorico_EMPGTD.Columns[7].Visible = false;
            consumoHistorico_EMPGTD.Columns[8].Visible = false;
        }

        private void nudConsumoH_medidor_ValueChanged(object sender, EventArgs e)
        {
            List<Contratos> contracts = new List<Contratos>();
            contracts = DatabaseManagement.getInstance().GetContratos();
            double medidorServicio = 0;

            List<Recibos> recibos = new List<Recibos>();
            recibos = DatabaseManagement.getInstance().getRecibos();

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                

                if (nudConsumoH_medidor.Text.Equals(consumo.num_medidor.ToString()))
                {

                    foreach (var contract in contracts)
                    {
                        if (contract.num_medidor.ToString().Equals(consumo.num_medidor.ToString()))
                        {
                            medidorServicio = contract.num_servicio;
                            consumo.num_servicio = medidorServicio;
                            break;
                        }
                    }


                    Consumos consumoDTG = new Consumos();
                    consumoDTG.num_medidor = consumo.num_medidor;
                    consumoDTG.consumo = consumo.consumo;
                    consumoDTG.month = consumo.month;
                    consumoDTG.num_servicio = consumo.num_servicio;
                    consumoDTG.year = consumo.year;

                    consumoDTG.kw_basico = 100;
                    foreach (var contract in contracts)
                    {
                        if (contract.num_medidor == consumo.num_medidor)
                        {
                            consumo.num_servicio = (int)contract.num_servicio;
                            consumoDTG.num_servicio = consumo.num_servicio;
                        }
                    }

                    foreach (var recibo in recibos)
                    {
                        if (recibo.year.Equals(consumo.year) && recibo.month.Equals(consumo.month) && recibo.num_medidor.ToString().Equals(consumo.num_medidor.ToString()))
                        {
                            if (recibo.pagado.Equals("SIN PAGAR"))
                            {
                                consumo.pendiente_pago = recibo.pagar_total_iva;
                                consumoDTG.pendiente_pago = Math.Round(consumo.pendiente_pago, 4);
                            }
                        }
                    }

                    csmDTG.Add(consumo);
                }

            }

            consumoHistorico_EMPGTD.DataSource = csmDTG;
            consumoHistorico_EMPGTD.Columns[4].Visible = false;
            consumoHistorico_EMPGTD.Columns[5].Visible = false;
            consumoHistorico_EMPGTD.Columns[6].Visible = false;
            consumoHistorico_EMPGTD.Columns[7].Visible = false;
            consumoHistorico_EMPGTD.Columns[8].Visible = false;
        }

        private void nudConsumoH_servcio_ValueChanged(object sender, EventArgs e)
        {
            List<Contratos> contracts = new List<Contratos>();
            contracts = DatabaseManagement.getInstance().GetContratos();
            double medidorServicio = 0;
            
            List<Recibos> recibos = new List<Recibos>();
            recibos = DatabaseManagement.getInstance().getRecibos();

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                foreach (var contract in contracts)
                {
                    if (contract.num_medidor.ToString().Equals(consumo.num_medidor.ToString())) {
                        medidorServicio = contract.num_servicio;
                        consumo.num_servicio = medidorServicio;
                    }
                }


                if (nudConsumoH_servcio.Value.ToString().Equals(consumo.num_servicio.ToString()))
                {
                    Consumos consumoDTG = new Consumos();
                    consumoDTG.num_medidor = consumo.num_medidor;
                    consumoDTG.consumo = consumo.consumo;
                    consumoDTG.month = consumo.month;
                    consumoDTG.year = consumo.year;
                    consumoDTG.num_servicio = consumo.num_servicio;
                    consumoDTG.kw_basico = 100;
                    foreach (var contract in contracts)
                    {
                        if (contract.num_medidor == consumo.num_medidor)
                        {
                            consumo.num_servicio = (int)contract.num_servicio;
                            consumoDTG.num_servicio = consumo.num_servicio;
                        }
                    }

                    foreach (var recibo in recibos)
                    {
                        if (recibo.year.Equals(consumo.year) && recibo.month.Equals(consumo.month) && recibo.num_medidor.ToString().Equals(consumo.num_medidor.ToString()))
                        {
                            if (recibo.pagado.Equals("SIN PAGAR"))
                            {
                                consumo.pendiente_pago = recibo.pagar_total_iva;
                                consumoDTG.pendiente_pago = Math.Round(consumo.pendiente_pago, 4);
                            }
                        }
                    }

                    csmDTG.Add(consumo);
                }

            }

            consumoHistorico_EMPGTD.DataSource = csmDTG;
            consumoHistorico_EMPGTD.Columns[4].Visible = false;
            consumoHistorico_EMPGTD.Columns[5].Visible = false;
            consumoHistorico_EMPGTD.Columns[6].Visible = false;
            consumoHistorico_EMPGTD.Columns[7].Visible = false;
            consumoHistorico_EMPGTD.Columns[8].Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }

            String pdfName = folderPath + "\\ReporteConsumosEmployee.csv";
            if (folderPath.Equals(""))
            {
                return;
            }
            writeCSV(consumoHistorico_EMPGTD, pdfName);
            MessageBox.Show("Csv generado");
        }


        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();

            }
        }

    }
}
