using AAVD.Base_de_datos;
using AAVD.Entidades;
using Aspose.Pdf;
using Aspose.Pdf.Text;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AAVD.Forms
{
    public partial class Client : Form
    {

        string currentUserClien = Form1.currentUserId.ToString();
        bool fechaCambiada = false;
        public Client()
        {
            InitializeComponent();
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.num_medidorH.DropDownStyle = ComboBoxStyle.DropDownList;
            this.no_servicioH.DropDownStyle = ComboBoxStyle.DropDownList;
            this.medidores.DropDownStyle = ComboBoxStyle.DropDownList;
            this.medidor_pdf.DropDownStyle = ComboBoxStyle.DropDownList;
            this.medidor_wn.DropDownStyle = ComboBoxStyle.DropDownList;
             
            tarjeta_fecha.Format = DateTimePickerFormat.Custom;
            tarjeta_fecha.CustomFormat = "MM/yyyy";

            pagar_year.Format = DateTimePickerFormat.Custom;
            pagar_year.CustomFormat = "yyyy";

            pagar_mes.Format = DateTimePickerFormat.Custom;
            pagar_mes.CustomFormat = "MM";

            consumoH_fecha.Format = DateTimePickerFormat.Custom;
            consumoH_fecha.CustomFormat = "yyyy";


            month_reciboPDF.Format = DateTimePickerFormat.Custom;
            month_reciboPDF.CustomFormat = "MM";

            year_reciboPDF.Format = DateTimePickerFormat.Custom;
            year_reciboPDF.CustomFormat = "yyyy";

            recibo_mes.Format = DateTimePickerFormat.Custom;
            recibo_mes.CustomFormat = "MM";

            recibo_year.Format = DateTimePickerFormat.Custom;
            recibo_year.CustomFormat = "yyyy";

            updateDataGridConsumosSinFiltros();
            updateRecibos();
            this.CenterToScreen();
        }

        //Cuando carga la ventana.
        private void Client_Load(object sender, EventArgs e)
        {
            
            List<Clientes> clientesConsumoFiltros = new List<Clientes>();
            clientesConsumoFiltros = DatabaseManagement.getInstance().GetClients();
            foreach (var cliente in clientesConsumoFiltros) {
                if (cliente.user_id.ToString().Equals(currentUserClien)){
                    foreach (var medidor in cliente.measurers) {
                        num_medidorH.Items.Add(medidor.ToString());
                        medidores.Items.Add(medidor.ToString());
                        medidor_wn.Items.Add(medidor.ToString());
                        medidor_pdf.Items.Add(medidor.ToString());

                    }
                    foreach (var contrato in cliente.contracts) {
                        
                        no_servicioH.Items.Add(contrato.ToString());
                    }
                }
            
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Equals("Visa")) {
                tarjeta_numero.Visible = tarjeta_fecha.Visible = tarjeta_ccv.Visible = true;
                label14.Visible = label15.Visible = label16.Visible = true;
                label17.Visible = false;
            }

            if (comboBox3.Text.Equals("Mastercard")){
                tarjeta_numero.Visible = tarjeta_fecha.Visible = tarjeta_ccv.Visible = true;
                label14.Visible = label15.Visible = label16.Visible = true;
                label17.Visible = false;
            }

            if (comboBox3.Text.Equals("Paypal"))
            {
                tarjeta_numero.Visible = tarjeta_fecha.Visible = tarjeta_ccv.Visible = false;
                label14.Visible = label15.Visible = label16.Visible = false;
                label17.Visible = true;
            }

            if (comboBox3.Text.Equals("GPay"))
            {
                tarjeta_numero.Visible = tarjeta_fecha.Visible = tarjeta_ccv.Visible = false;
                label14.Visible = label15.Visible = label16.Visible = false;
                label17.Visible = true;
            }

            if(comboBox3.Text.Equals("Efectivo"))
            {
                tarjeta_numero.Visible = tarjeta_fecha.Visible = tarjeta_ccv.Visible = false;
                label14.Visible = label15.Visible = label16.Visible = false;
                label17.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Clientes> clienteBuscar = new List<Clientes>();
            clienteBuscar = DatabaseManagement.getInstance().getClientWithUserId(currentUserClien);
            foreach (var contratos in clienteBuscar) {
                foreach (var num in contratos.contracts) {
                    if (num.ToString().Equals(medidores.Text)) {
                        
                    }
                }
            }


            bool encontrado = false;
            List<Clientes> cliente = new List<Clientes>();
            cliente = DatabaseManagement.getInstance().getClientWithUserId(currentUserClien);
            foreach (var clienteActual in cliente) {
                List<Recibos> recibos = new List<Recibos>();
                recibos = DatabaseManagement.getInstance().getRecibos();
                foreach (var recibo in recibos)
                {
                    foreach (var medidor in clienteActual.measurers) {
                        if (medidor.ToString().Equals(recibo.num_medidor.ToString())) {
                            if (recibo.year.Equals(pagar_year.Text) && recibo.month.Equals(pagar_mes.Text))
                            {
                                if (recibo.pagado.Equals("PAGADO"))
                                {
                                    MessageBox.Show("Este recibo ya fue pagado");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            if (comboBox3.Text.Equals("")) {
                MessageBox.Show("Ingresa un metodo de pago");
                return;
            }

            MessageBox.Show("Procesando el pago...");
            DatabaseManagement.getInstance().pagarRecibo(medidores.Text, pagar_year.Text, pagar_mes.Text, comboBox3.Text);
            MessageBox.Show("Recibo pagado!");
            updateRecibos();
        }

        private void Consultar_consumo_Click(object sender, EventArgs e)
        {

        }

        //Cuando se cambie el a;o
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaCambiada = true;
            updateDataGridConsumos();
        }


        //Cargar sin filtros
        public void updateDataGridConsumosSinFiltros()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                List<Clientes> clientes = new List<Clientes>();
                clientes = DatabaseManagement.getInstance().GetClients();
                foreach (var cliente in clientes)
                {
                    if (cliente.user_id.ToString().Equals(currentUserClien))
                    {
                        foreach (var medidor in cliente.measurers)
                        {
                            if (medidor.ToString().Equals(consumo.num_medidor.ToString()))
                            {
                                Consumos consumoDTG = new Consumos();
                                consumoDTG.num_medidor = consumo.num_medidor;
                                consumoDTG.consumo = consumo.consumo;
                                consumoDTG.month = consumo.month;
                                consumoDTG.year = consumo.year;
                                csmDTG.Add(consumo);
                            }
                        }
                    }
                }
                

            }

            List<Recibos> recibosFiltro = new List<Recibos>();
            recibosFiltro = DatabaseManagement.getInstance().getRecibos();
            foreach (var recibo in recibosFiltro)
            {
                    foreach (var consumoExtra in csmDTG)
                    {
                        if (recibo.num_medidor == consumoExtra.num_medidor)
                        {
                            consumoExtra.kw_basico = recibo.kw_basico;
                            consumoExtra.kw_intermedio = recibo.kw_intermedio;
                            consumoExtra.kw_excedente = recibo.kw_excedente;
                            consumoExtra.pagar_total_iva = Math.Round(recibo.pagar_total_iva, 3);
                            if (recibo.pagado.Equals("PAGADO"))
                            {
                                consumoExtra.pendiente_pago = 0;
                            }
                            else
                            {
                                consumoExtra.pendiente_pago = Math.Round(recibo.pagar_total_iva, 3);
                            }
                            consumoExtra.importe = recibo.kw_basico * 0;
                        }
                    }
                
            }


            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratos();
            foreach (var contrato in contratos)
            {
                foreach (var consumo in csmDTG)
                {
                    if (consumo.num_medidor.ToString().Equals(contrato.num_medidor.ToString()))
                    {
                        consumo.num_servicio = contrato.num_servicio;
                    }
                }
            }

            ConsumoHistoriaDtg_WN.DataSource = csmDTG;
        }

        //Cuando se pone filtro del a;o
        public void updateDataGridConsumos()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                List<Clientes> clientes = new List<Clientes>();
                clientes = DatabaseManagement.getInstance().GetClients();
                foreach (var cliente in clientes)
                {
                    if (cliente.user_id.ToString().Equals(currentUserClien))
                    {
                        foreach (var medidor in cliente.measurers)
                        {
                            if (medidor.ToString().Equals(consumo.num_medidor.ToString()))
                            {
                                if (consumo.year.ToString().Equals(consumoH_fecha.Text))
                                {
                                    Consumos consumoDTG = new Consumos();
                                    consumoDTG.num_medidor = consumo.num_medidor;
                                    consumoDTG.consumo = consumo.consumo;
                                    consumoDTG.month = consumo.month;
                                    consumoDTG.year = consumo.year;
                                    csmDTG.Add(consumo);
                                }
                            }
                        }
                    }
                }
               

            }

            List<Recibos> recibosFiltro = new List<Recibos>();
            recibosFiltro = DatabaseManagement.getInstance().getRecibos();
            foreach(var recibo in recibosFiltro){
                if (recibo.year.Equals(consumoH_fecha.Text)) {
                    foreach (var consumoExtra in csmDTG) {
                        if (recibo.num_medidor == consumoExtra.num_medidor) {
                            consumoExtra.kw_basico = recibo.kw_basico;
                            consumoExtra.kw_intermedio = recibo.kw_intermedio;
                            consumoExtra.kw_excedente = recibo.kw_excedente;
                            consumoExtra.pagar_total_iva = Math.Round(recibo.pagar_total_iva,3);
                            if (recibo.pagado.Equals("PAGADO")){
                                consumoExtra.pendiente_pago = 0;
                            }
                            else {
                                consumoExtra.pendiente_pago = Math.Round(recibo.pagar_total_iva,3);
                            }
                            consumoExtra.importe = recibo.kw_basico * 0;
                        }
                    }
                }
            }

            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratos();
            foreach (var contrato in contratos)
            {
                foreach (var consumo in csmDTG)
                {
                    if (consumo.num_medidor.ToString().Equals(contrato.num_medidor.ToString()))
                    {
                        consumo.num_servicio = contrato.num_servicio;
                    }
                }
            }

            ConsumoHistoriaDtg_WN.DataSource = csmDTG;
        }


        //Filtro para el numero de medidor
        public void updateDataGridConsumosNumMedidores()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            foreach (var consumo in consumos)
            {
                List<Clientes> clientes = new List<Clientes>();
                clientes = DatabaseManagement.getInstance().GetClients();
                foreach (var cliente in clientes)
                {
                    if (cliente.user_id.ToString().Equals(currentUserClien))
                    {
                        foreach (var medidor in cliente.measurers)
                        {
                            if (medidor.ToString().Equals(consumo.num_medidor.ToString()))
                            {
                                if (consumo.num_medidor.ToString().Equals(num_medidorH.Text))
                                {
                                    Consumos consumoDTG = new Consumos();
                                    consumoDTG.num_medidor = consumo.num_medidor;
                                    consumoDTG.consumo = consumo.consumo;
                                    consumoDTG.month = consumo.month;
                                    consumoDTG.year = consumo.year;
                                    csmDTG.Add(consumo);
                                }
                            }
                        }
                    }
                }


            }

            List<Recibos> recibosFiltro = new List<Recibos>();
            recibosFiltro = DatabaseManagement.getInstance().getRecibos();
            foreach (var recibo in recibosFiltro)
            {
                if (recibo.year.Equals(consumoH_fecha.Text))
                {
                    foreach (var consumoExtra in csmDTG)
                    {
                        if (recibo.num_medidor == consumoExtra.num_medidor)
                        {
                            consumoExtra.kw_basico = recibo.kw_basico;
                            consumoExtra.kw_intermedio = recibo.kw_intermedio;
                            consumoExtra.kw_excedente = recibo.kw_excedente;
                            consumoExtra.pagar_total_iva = Math.Round(recibo.pagar_total_iva, 3);
                            if (recibo.pagado.Equals("PAGADO"))
                            {
                                consumoExtra.pendiente_pago = 0;
                            }
                            else
                            {
                                consumoExtra.pendiente_pago = Math.Round(recibo.pagar_total_iva, 3);
                            }
                            consumoExtra.importe = recibo.kw_basico * 0;
                        }
                    }
                }
            }

            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratos();
            foreach (var contrato in contratos)
            {
                foreach (var consumo in csmDTG)
                {
                    if (consumo.num_medidor.ToString().Equals(contrato.num_medidor.ToString()))
                    {
                        consumo.num_servicio = contrato.num_servicio;
                    }
                }
            }
            ConsumoHistoriaDtg_WN.DataSource = csmDTG;
        }


        //Enviar dependiendo del no. de servicio
        public void updateDataGridConsumosNumServicio()
        {

            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumos();

            List<Consumos> csmDTG = new List<Consumos>();
            bool encontrado = false;
            foreach (var consumo in consumos)
            {
                List<Clientes> clientes = new List<Clientes>();
                clientes = DatabaseManagement.getInstance().GetClients();
                foreach (var cliente in clientes)
                {
                    if (cliente.user_id.ToString().Equals(currentUserClien))
                    {
                        foreach (var contrato in cliente.contracts)
                        {
                            if (contrato.ToString().Equals(no_servicioH.Text))
                            {
                                Consumos consumoDTG = new Consumos();
                                consumoDTG.num_medidor = consumo.num_medidor;
                                consumo.num_servicio = contrato;
                                consumoDTG.num_servicio = consumo.num_servicio;
                                consumoDTG.consumo = consumo.consumo;
                                consumoDTG.month = consumo.month;
                                consumoDTG.year = consumo.year;
                                csmDTG.Add(consumo);
                                encontrado = true;
                            }
                        }

                        break;
                    }
                        
                }
                if (encontrado)
                    break;

            }

            List<Recibos> recibosFiltro = new List<Recibos>();
            recibosFiltro = DatabaseManagement.getInstance().getRecibos();
            foreach (var recibo in recibosFiltro)
            {
                if (recibo.year.Equals(consumoH_fecha.Text))
                {
                    foreach (var consumoExtra in csmDTG)
                    {
                        if (recibo.num_medidor == consumoExtra.num_medidor)
                        {
                            consumoExtra.kw_basico = recibo.kw_basico;
                            consumoExtra.kw_intermedio = recibo.kw_intermedio;
                            consumoExtra.kw_excedente = recibo.kw_excedente;
                            consumoExtra.pagar_total_iva = Math.Round(recibo.pagar_total_iva, 3);
                            if (recibo.pagado.Equals("PAGADO"))
                            {
                                consumoExtra.pendiente_pago = 0;
                            }
                            else
                            {
                                consumoExtra.pendiente_pago = Math.Round(recibo.pagar_total_iva, 3);
                            }
                            consumoExtra.importe = recibo.kw_basico * 0;
                        }
                    }
                }
            }

            //List<Contratos> contratos = new List<Contratos>();
            //contratos = DatabaseManagement.getInstance().GetContratos();
            //foreach (var contrato in contratos)
            //{
            //    foreach (var consumo in csmDTG)
            //    {
            //        if (consumo.num_medidor.ToString().Equals(contrato.num_medidor.ToString()))
            //        {
            //            consumo.num_servicio = contrato.num_servicio;
            //        }
            //    }
            //}
            ConsumoHistoriaDtg_WN.DataSource = csmDTG;
        }

        //Cambiar el numero de medidor
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridConsumosNumMedidores();
        }

        //Cambia el numero de servicio
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridConsumosNumServicio();
        }



        private void button7_Click(object sender, EventArgs e)
        {


        }


        public void agregarTexto(int x, int y, string texto, Aspose.Pdf.Page pagina)
        {
            TextFragment txtName = new TextFragment(texto);
            txtName.Position = new Position(x, y);
            txtName.TextState.FontSize = 12;
            txtName.TextState.Font = FontRepository.FindFont("Arial");
            txtName.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            TextBuilder txtBuild = new TextBuilder(pagina);
            txtBuild.AppendText(txtName);
        }

        //Para generar el recibo en pdf
        private void generar_recibo_Click(object sender, EventArgs e)
        {



            string id_usuario = "";
            List<Users> users = new List<Users>();
            users = DatabaseManagement.getInstance().getRemember(medidor_pdf.Text);
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
                if ((contrato.num_medidor.ToString()).Equals(medidor_pdf.Text))
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
            foreach (var consumo in consumoValidacion) {
                if (consumo.num_medidor.ToString().Equals(medidor_pdf.Text) && consumo.year.ToString().Equals(year_reciboPDF.Text) && consumo.month.ToString().Equals(month_reciboPDF.Text)) {
                    consumoExiste = true;
                }
            }

            if (!consumoExiste) {
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
                Aspose.Pdf.Page page1 = pdfDocument.Pages.Add();

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
                recibos = DatabaseManagement.getInstance().getReciboEspecifico(medidor_pdf.Text, year_reciboPDF.Text, month_reciboPDF.Text);
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

                String pdfName = folderPath + "\\Recibo.pdf";
                if (folderPath.Equals(""))
                {
                    return;
                }
                pdfDocument.Save(pdfName);
                MessageBox.Show("Recibo creado");
            }
        }

        //Recibo en pantalla
        private void button7_Click_1(object sender, EventArgs e)
        {
            string id_cliente = "";
            string tipo = "";
            string no_servicio = "";
            List<Contratos> contratos = new List<Contratos>();
            contratos = DatabaseManagement.getInstance().GetContratosMedidorTipo();
            foreach (var contrato in contratos)
            {
                if ((contrato.num_medidor.ToString()).Equals(medidor_wn.Text))
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
                if (consumo.num_medidor.ToString().Equals(medidor_wn.Text) && consumo.year.ToString().Equals(recibo_year.Text) && consumo.month.ToString().Equals(recibo_mes.Text))
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
            recibosActual = DatabaseManagement.getInstance().getReciboEspecifico(medidor_wn.Text, recibo_year.Text, recibo_mes.Text);
            foreach (var recibo2 in recibosAnteriores) {
                foreach (var reciboActual in recibosActual) {
                    if (recibo2.num_medidor.ToString().Equals(reciboActual.num_medidor.ToString())) {
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
            recibo = DatabaseManagement.getInstance().getReciboEspecifico(medidor_wn.Text, recibo_year.Text, recibo_mes.Text);
            foreach (var reciboNode in recibo)
            {
                recibo_kwBasicos.Text = reciboNode.kw_basico.ToString();
                recibo_kwIntermedios.Text = reciboNode.kw_intermedio.ToString();
                recibo_kwExcedentes.Text = reciboNode.kw_excedente.ToString();
                recibos_kwTotales.Text = (reciboNode.kw_basico + reciboNode.kw_intermedio + reciboNode.kw_excedente ).ToString();
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

        //Datagrid para recibos
        public void updateRecibos() {
            List<Recibos> recibos = new List<Recibos>();
            recibos = DatabaseManagement.getInstance().getRecibos();

            List<Recibos> rcbDTG = new List<Recibos>();
            foreach (var recibo in recibos)
            {
                List<Clientes> clientes = new List<Clientes>();
                clientes = DatabaseManagement.getInstance().getClientWithUserId(currentUserClien);
                foreach (var cliente in clientes)
                {
                    foreach (var medidor in cliente.measurers) {
                        if (medidor == recibo.num_medidor)
                        {
                            Recibos reciboDTG = new Recibos();
                            reciboDTG.kw_basico = recibo.kw_basico;
                            reciboDTG.kw_intermedio = recibo.kw_intermedio;
                            reciboDTG.kw_excedente = recibo.kw_excedente;
                            reciboDTG.kwTotal = Math.Round(recibo.kw_basico + recibo.kw_excedente + recibo.kw_intermedio, 4);
                            reciboDTG.year = recibo.year;
                            reciboDTG.month = recibo.month;
                            reciboDTG.num_medidor = recibo.num_medidor;
                            reciboDTG.pagar_total_iva = Math.Round(recibo.pagar_total_iva,3);
                            reciboDTG.pagado = recibo.pagado;
                            reciboDTG.tipo_de_pago = recibo.tipo_de_pago;
                            reciboDTG.pagar_excedente = Math.Round(recibo.pagar_excedente,4);
                            reciboDTG.pagar_intermedio = Math.Round(recibo.pagar_intermedio,4);
                            reciboDTG.pagar_basico = Math.Round(recibo.pagar_basico,4);
                            
                            reciboDTG.pagar_total =Math.Round(recibo.pagar_excedente + recibo.pagar_intermedio + recibo.pagar_basico,4);
                            rcbDTG.Add(reciboDTG);
                        }
                    }
                }

            }
            RecibosDTGWN.DataSource = rcbDTG;
        }

        private void Generar_pdf_consumo_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }

            String pdfName = folderPath + "\\ReporteConsumos.csv";
            if (folderPath.Equals(""))
            {
                return;
            }
            writeCSV(ConsumoHistoriaDtg_WN, pdfName);
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
