using AAVD.Entidades;
using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAVD.Base_de_datos
{
    class DatabaseManagement
    {
        static public string cassandraHome { get; set; }
        static public string keyspace { get; set; }
        static private Cluster cluster;
        static private ISession session;
        static private DatabaseManagement _instance;

        private DatabaseManagement()
        {
            Connect();
            session = cluster.Connect(keyspace);
        }

        static public DatabaseManagement getInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseManagement();
            }
            return _instance;
        }

        static private void Connect()
        {
            cassandraHome = ConfigurationManager.AppSettings["cassandra_home"].ToString();
            keyspace = ConfigurationManager.AppSettings["keyspace"].ToString();
            cluster = Cluster.Builder().AddContactPoint(cassandraHome).Build();
        }

        //Regresa en una lista a el usuario resultante de la query. 
        //Se tiene que utilizar el USER_NAME y PASSWORD, son una compund key en cql. Para una busqueda rapida
        //AUn no descubro como regresar el usuario solo, sin una lista. Pero esto jala.
        public List<Users> getLogin(string user_name, string password)
        {
            string query = String.Format("SELECT * FROM USERS_LOGIN WHERE USER_NAME='{0}' AND PASSWORD='{1}';", user_name, password);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Users> users = mapper.Fetch<Users>(query);
            return users.ToList();

        }

        //Conseguir la pregunta para recordar
        public List<Users> getRemember(string user_name)
        {
            string query = String.Format("SELECT * FROM USERS_REMEMBER WHERE USER_NAME='{0}';", user_name);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Users> users = mapper.Fetch<Users>(query);
            return users.ToList();

        }

        //Conseguir todos los usuarios
        public List<Users> getUsers() {
            string query = "SELECT * FROM USERS_LOGIN;";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Users> users = mapper.Fetch<Users>(query);
            return users.ToList();
        }

        //Desactivar un usuario
        public void userBan(string user_name)
        {
            string query = String.Format("UPDATE USERS_REMEMBER SET ACTIVE = false WHERE USER_NAME = '{0}' IF EXISTS;", user_name);
            session.Execute(query);

            query = String.Format("SELECT * FROM USERS_REMEMBER WHERE USER_NAME='{0}';", user_name);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Users> users = mapper.Fetch<Users>(query);
            string password = "";
            foreach (var usuario in users)
            {
                password = usuario.password;
            }

            query = String.Format("UPDATE USERS_LOGIN SET ACTIVE = false WHERE USER_NAME = '{0}' AND PASSWORD = '{1}' IF EXISTS;", user_name, password);
            session.Execute(query);
        }

        //Volver a activar un usuario
        public void userUnban(string user_name)
        {
            string query = String.Format("UPDATE USERS_REMEMBER SET ACTIVE = true WHERE USER_NAME = '{0}' IF EXISTS;", user_name);
            session.Execute(query);

            query = String.Format("SELECT * FROM USERS_REMEMBER WHERE USER_NAME='{0}';", user_name);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Users> users = mapper.Fetch<Users>(query);
            string password = "";
            foreach (var usuario in users)
            {
                password = usuario.password;
            }

            query = String.Format("UPDATE USERS_LOGIN SET ACTIVE = true WHERE USER_NAME = '{0}' AND PASSWORD = '{1}' IF EXISTS;", user_name, password);
            session.Execute(query);
        }

        //Registra el usuario.
        //Hace falta registrarlo en la tabla general de USERS.
        public bool registerUser(string username, string password, int type, string pregunta, string respuesta)
        {
            string queryValidar = "SELECT COUNT(*) FROM USERS_REMEMBER WHERE USER_NAME ='" + username + "';";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Existentes> existe = mapper.Fetch<Existentes>(queryValidar);
            foreach (var count in existe)
            {
                if (count.count == 1)
                {

                    return false;
                }
            }

            string query = String.Format("INSERT INTO USERS_LOGIN(USER_NAME, PASSWORD, USER_TYPE, ACTIVE, USER_ID, QUESTION, ANSWER)" +
                            " VALUES('{0}','{1}', {2}, true, uuid(),'" + pregunta + "','" + respuesta + "')", username, password, type);
            session.Execute(query);
            query = String.Format("INSERT INTO USERS_REMEMBER(USER_NAME, PASSWORD, USER_TYPE, ACTIVE, USER_ID, QUESTION, ANSWER)" +
                            " VALUES('{0}','{1}', {2}, true, uuid(), '" + pregunta + "','" + respuesta + "')", username, password, type);
            session.Execute(query);
            return true;
        }

        //Registra a los empleados
        public void registerEmployee(string username, string password, string nombre, string apellidoPaterno, string apellidoMaterno, string CURP, string RFC, string nacimiento, Guid user_id, string pregunta, string respuesta)
        {

            string query2 = "INSERT INTO EMPLOYEES (USER_ID,USER, PASSWORD, NAME, LAST_NAME, MOTHER_LAST_NAME, CLAVES_UNICAS, CREATION_DATE, DATE_OF_BIRTH, MODIFICATION_DATE, EMPLOYEE_ID, QUESTION, ANSWER)"
                                        + " VALUES(" + user_id + ",'" + username + "', '" + password + "', '" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', {'CURP' : '" + CURP + "', 'RFC' : '" + RFC + "' }, now(), '" + nacimiento + "', [toDate(now())], uuid(), '" + pregunta + "', '" + respuesta + "');";
            session.Execute(query2);


        }

        //Recordar empleados

        //Enviar lista con todos los empleados
        public List<Employees> GetEmployees()
        {
            string query = "SELECT * FROM EMPLOYEES";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Employees> employees = mapper.Fetch<Employees>(query);
            return employees.ToList();
        }

        //Actualizar un empleado
        public void updateEmployee(string username, string password, string nombre, string apellidoPaterno, string apellidoMaterno, string CURP, string RFC, string nacimiento, string employee_id, string pregunta, string respuesta)
        {
            string query2 = "UPDATE EMPLOYEES SET USER = '" + username + "', PASSWORD = '" + password + "', NAME = '" + nombre + "', LAST_NAME = '" + apellidoPaterno + "', MOTHER_LAST_NAME = '" + apellidoMaterno + "', CLAVES_UNICAS = {'CURP' : '" + CURP + "', 'RFC' : '" + RFC + "'},  DATE_OF_BIRTH = '" + nacimiento + "', QUESTION = '" + pregunta + "', ANSWER = '" + respuesta + "' ,MODIFICATION_DATE = MODIFICATION_DATE + [todate(now())] WHERE EMPLOYEE_ID= " + employee_id + " "
                            + " IF EXISTS;";
            session.Execute(query2);
        }

        //Borrar un empleado
        public void eraseEmployee(string employee_id, string user, string password)
        {
            string query = "DELETE FROM EMPLOYEES WHERE EMPLOYEE_ID = " + employee_id + ";";
            session.Execute(query);

            query = "DELETE FROM USERS_LOGIN WHERE USER_NAME = '" + user + "' AND PASSWORD = '" + password + "';";
            session.Execute(query);

            query = "DELETE FROM USERS_REMEMBER WHERE USER_NAME = '" + user + "';";
            session.Execute(query);
        }

        //Registrar un cliente
        public void registerClient(string nombre, string apellidoP, string apellidoM, string email, string CURP, string genero, string nacimiento, string ciudad, string calle, string colonia, string estado, string tipoContrato, string usuario, string password, Guid user_id, string no_medidor, string no_servicio, string no_cliente)
        {
            Guid client_id_guid = Guid.NewGuid();
            string client_id = client_id_guid.ToString();
            string today = DateTime.Today.ToString();
            string query2 = "INSERT INTO CLIENTS (CLIENT_ID, USER_ID, CONTRACT_TYPE, CREATION_DATE, MODIFICATION_TIMES, MONTHLY_PAYMENTS, EMAIL, GENDER, MEASURERS, CONTRACTS,CURP, USER, PASSWORD, NAME, LAST_NAME, MOTHER_LAST_NAME, AUTHOR, STREET, COLONY, CITY, STATE, DATE_OF_BIRTH, NUM_CLIENTE)"
                             + " VALUES("+ client_id + " ," + user_id + ", '" + tipoContrato + "', now(), { toDate(now()) }, {'" + today + "' : 13.0 } , '" + email + "', '" + genero + "', ["+no_medidor+"], ["+no_servicio+"], '" + CURP + "', '" + usuario + "', '" + password + "', '" + nombre + "', '" + apellidoP + "', '" + apellidoM + "', " + Form1.currentUserId + ", '" + calle + "', '" + colonia + "', '" + ciudad + "', '" + estado + "', '" + nacimiento + "', "+no_cliente+");";
            session.Execute(query2);
            
            //Lo ponemos en los demas datos
            query2 = "INSERT INTO CLIENTS_BUSCAR (CLIENT_ID, USER_ID, CONTRACT_TYPE, CREATION_DATE, MODIFICATION_TIMES, MONTHLY_PAYMENTS, EMAIL, GENDER, MEASURERS, CONTRACTS,CURP, USER, PASSWORD, NAME, LAST_NAME, MOTHER_LAST_NAME, AUTHOR, STREET, COLONY, CITY, STATE, DATE_OF_BIRTH, NUM_CLIENTE)"
                             + " VALUES("+ client_id + " ," + user_id + ", '" + tipoContrato + "', now(), { toDate(now()) }, {'" + today + "' : 13.0 } , '" + email + "', '" + genero + "', [" + no_medidor + "],[" + no_servicio + "], '" + CURP + "', '" + usuario + "', '" + password + "', '" + nombre + "', '" + apellidoP + "', '" + apellidoM + "', " + Form1.currentUserId + ", '" + calle + "', '" + colonia + "', '" + ciudad + "', '" + estado + "', '" + nacimiento + "', " + no_cliente + ");";
            session.Execute(query2);
            query2 = "INSERT INTO CLIENTS_BUSCAR_CURP (CLIENT_ID, USER_ID, CONTRACT_TYPE, CREATION_DATE, MODIFICATION_TIMES, MONTHLY_PAYMENTS, EMAIL, GENDER, MEASURERS, CONTRACTS,CURP, USER, PASSWORD, NAME, LAST_NAME, MOTHER_LAST_NAME, AUTHOR, STREET, COLONY, CITY, STATE, DATE_OF_BIRTH, NUM_CLIENTE)"
                            + " VALUES("+ client_id + " ," + user_id + ", '" + tipoContrato + "', now(), { toDate(now()) }, {'" + today + "' : 13.0 } , '" + email + "', '" + genero + "', [" + no_medidor + "],[" + no_servicio + "], '" + CURP + "', '" + usuario + "', '" + password + "', '" + nombre + "', '" + apellidoP + "', '" + apellidoM + "', " + Form1.currentUserId + ", '" + calle + "', '" + colonia + "', '" + ciudad + "', '" + estado + "', '" + nacimiento + "', " + no_cliente + ");";
            session.Execute(query2);

            //Se le asigna su primer contrato
            DateTime today2 = DateTime.Today;
            string year = today2.Year.ToString();
            string month = today2.Month.ToString();
            string day = today2.Day.ToString();
            string queryIC = "INSERT INTO CONTRACTS(NUM_SERVICIO, ID_CLIENTE, TIPO, NUM_MEDIDOR, CALLE, COLONIA, CIUDAD, ESTADO, NUM_CLIENTE, CREATION_YEAR, CREATION_MONTH, CREATION_DAY)"
                            + "VALUES(" + no_servicio + ", " + client_id + ", '" + tipoContrato + "', " + no_medidor + ", '" + calle + "', '" + colonia + "', '" + ciudad + "', '" + estado + "', " + no_cliente + ", '" + year + "', '" + month + "', '" + day + "');";
            session.Execute(queryIC);
        }

        //Obtener todos los contratos
        public List<Contratos> GetContratos()
        {
            string query = "SELECT * FROM CONTRACTS";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Contratos> contratos = mapper.Fetch<Contratos>(query);
            return contratos.ToList();
        }

        //Obtengo el medidor y el tipo de los contratos
        public List<Contratos> GetContratosMedidorTipo()
        {
            string query = "SELECT NUM_MEDIDOR, TIPO, ID_CLIENTE, NUM_SERVICIO, CREATION_YEAR, CREATION_MONTH, CREATION_DAY FROM CONTRACTS";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Contratos> contratos = mapper.Fetch<Contratos>(query);
            return contratos.ToList();
        }

        //Agregar un contrato a el cliente
        public void updateContratos(string numCLiente, string tipo, string numMedidor, string numServicio) {
            string query = "UPDATE CLIENTS_BUSCAR_CURP SET CONTRACTS = CONTRACTS + ["+numServicio+"], MEASURERS = MEASURERS + ["+numMedidor+"] WHERE NUM_CLIENTE = "+numCLiente+";";
            session.Execute(query);
            string client_id = "";
            string calle, colonia, estado, ciudad;
            calle = colonia = estado = ciudad = "";
            string queryDatos = "SELECT * FROM CLIENTS_BUSCAR_CURP WHERE NUM_CLIENTE = " + numCLiente + ";";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> clientes = mapper.Fetch<Clientes>(queryDatos);
            foreach (var cliente in clientes)
            {
                client_id = cliente.client_id.ToString();
                calle = cliente.street.ToString();
                colonia = cliente.colony.ToString();
                estado = cliente.state.ToString();
                ciudad = cliente.city.ToString();
                string query2 = "UPDATE CLIENTS_BUSCAR SET CONTRACTS = CONTRACTS + [" + numServicio + "], MEASURERS = MEASURERS + [" + numMedidor + "] WHERE USER_ID = " + cliente.user_id + ";";
                session.Execute(query2);
                string query3 = "UPDATE CLIENTS SET CONTRACTS = CONTRACTS + ["+numServicio+"], MEASURERS = MEASURERS + ["+numMedidor+"] WHERE CLIENT_ID = "+cliente.client_id+"; ";
                session.Execute(query3);
            }
            DateTime today = DateTime.Today;
            string year = today.Year.ToString();
            string month = today.Month.ToString();
            string day = today.Day.ToString();
            string queryIC = "INSERT INTO CONTRACTS(NUM_SERVICIO, ID_CLIENTE, TIPO, NUM_MEDIDOR, CALLE, COLONIA, CIUDAD, ESTADO, NUM_CLIENTE, CREATION_YEAR, CREATION_MONTH, CREATION_DAY)"
                            + "VALUES(" + numServicio + ", " + client_id + ", '" + tipo + "', " + numMedidor + ", '" + calle + "', '" + colonia + "', '" + ciudad + "', '" + estado + "', "+numCLiente+", '"+year+"', '"+month+"', '"+day+"');";
            session.Execute(queryIC);
        }

        //Obtener todos los clientes
        public List<Clientes> GetClients()
        {
            string query = "SELECT * FROM CLIENTS";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> clientes = mapper.Fetch<Clientes>(query);
            return clientes.ToList();
        }

        //Actualizar un cliente
        public void updateClient(string nombre, string apellidoP, string apellidoM, string email, string CURP, string genero, string nacimiento, string ciudad, string calle, string colonia, string estado, string tipoContrato, string usuario, string password, string id_cliente, string num_cliente)
        {

            string query2 = "UPDATE CLIENTS SET USER = '" + usuario + "', PASSWORD = '" + password + "', NAME= '" + nombre + "' ,LAST_NAME = '" + apellidoP + "', MOTHER_LAST_NAME= '" + apellidoM + "', EMAIL = '" + email + "', CURP = '" + CURP + "', GENDER = '" + genero + "', DATE_OF_BIRTH = '" + nacimiento + "', CITY= '" + ciudad + "', STREET = '" + calle + "', COLONY ='" + colonia + "', STATE= '" + estado + "', CONTRACT_TYPE= '" + tipoContrato + "' WHERE CLIENT_ID= " + id_cliente + " "
                            + " IF EXISTS;";
            session.Execute(query2);
            //Obtener el id de cliente
            string query = "SELECT * FROM CLIENTS WHERE CLIENT_ID = " + id_cliente + "";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> clientes = mapper.Fetch<Clientes>(query);
            foreach (var cliente in clientes)
            {
                query2 = "UPDATE CLIENTS_BUSCAR SET USER = '" + usuario + "', PASSWORD = '" + password + "', NAME= '" + nombre + "' ,LAST_NAME = '" + apellidoP + "', MOTHER_LAST_NAME= '" + apellidoM + "', EMAIL = '" + email + "', CURP = '" + CURP + "', GENDER = '" + genero + "', DATE_OF_BIRTH = '" + nacimiento + "', CITY= '" + ciudad + "', STREET = '" + calle + "', COLONY ='" + colonia + "', STATE= '" + estado + "', CONTRACT_TYPE= '" + tipoContrato + "' WHERE USER_ID = " + cliente.user_id + " "
                            + " IF EXISTS;";
                session.Execute(query2);
                string query3 = "UPDATE CLIENTS_BUSCAR_CURP SET USER = '" + usuario + "', PASSWORD = '" + password + "', NAME= '" + nombre + "' ,LAST_NAME = '" + apellidoP + "', MOTHER_LAST_NAME= '" + apellidoM + "', EMAIL = '" + email + "', CURP = '" + CURP + "', GENDER = '" + genero + "', DATE_OF_BIRTH = '" + nacimiento + "', CITY= '" + ciudad + "', STREET = '" + calle + "', COLONY ='" + colonia + "', STATE= '" + estado + "', CONTRACT_TYPE= '" + tipoContrato + "' WHERE NUM_CLIENTE = " + cliente.num_cliente + " "
                            + " IF EXISTS;";
                session.Execute(query3);
            }
            
            
        }

        //Funcion para borrar un cliente
        public void eraseClient(string client_id, string user, string password)
        {

            string query = "SELECT * FROM CLIENTS WHERE CLIENT_ID = " + client_id + "";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> clientes = mapper.Fetch<Clientes>(query);
            foreach (var cliente in clientes)
            {
                query = "DELETE FROM CLIENTS_BUSCAR WHERE USER_ID = " + cliente.user_id + ";";
                session.Execute(query);
                query = "DELETE FROM CLIENTS_BUSCAR_CURP WHERE NUM_CLIENTE = " + cliente.num_cliente + ";";
                session.Execute(query);
            }
            query = "DELETE FROM CLIENTS WHERE CLIENT_ID = " + client_id + ";";
            session.Execute(query);

            query = "DELETE FROM USERS_LOGIN WHERE USER_NAME = '" + user + "' AND PASSWORD = '" + password + "';";
            session.Execute(query);

            
        }


        //Definir las tarifas:
        public void crearTarifa(string tipo, string basica, string intermedia, string excedente)
        {

            string query2 = "INSERT INTO TARIFAS(TIPO, BASICO, INTERMEDIO, EXCEDENTE)" + " VALUES('" + tipo + "', " + basica + ", " + intermedia + ", " + excedente + ")";
            session.Execute(query2);
            DateTime today = DateTime.Today;
            string year = today.Year.ToString();
            string month = today.Month.ToString();
            query2 = "INSERT INTO TARIFAS_LOG(TIPO, BASICO, INTERMEDIO, EXCEDENTE, ID_TARIFA, YEAR, MONTH)" + " VALUES('" + tipo + "', " + basica + ", " + intermedia + ", " + excedente + ", uuid(), '" + year + "', '" + month + "')";
            session.Execute(query2);


        }

        //Obetener tarifas
        public List<Tarifas> GetTarifas()
        {
            string query = "SELECT * FROM TARIFAS";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Tarifas> tarifas = mapper.Fetch<Tarifas>(query);
            return tarifas.ToList();
        }

        //Obetener al cliente con el user_id
        public List<Clientes> getClientWithUserId(string user_id)
        {
            string query = String.Format("SELECT * FROM CLIENTS_BUSCAR WHERE USER_ID={0} ;", user_id);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> cliente = mapper.Fetch<Clientes>(query);
            return cliente.ToList();

        }


        //Subir un consumo 
        public void insertConsumo(string medidor, string consumo, string year, string month)
        {
            string query2 = "INSERT INTO CONSUMOS (NUM_MEDIDOR, YEAR, MONTH, CONSUMO)"
                                        + " VALUES(" + medidor + ", '" + year + "', '" + month + "', " + consumo + ");";
            session.Execute(query2);
            //Se traen las tarifas
            List<Tarifas> tarifas = new List<Tarifas>();
            tarifas = DatabaseManagement.getInstance().GetTarifas();
            double iBasica, iIntermedia, iExcedente;
            double dBasica, dIntermedia, dExcedente;
            iBasica = iIntermedia = iExcedente = 0;
            dBasica = dIntermedia = dExcedente = 0;
            foreach (var tarifa in tarifas) {
                if (tarifa.tipo == "Industrial")
                {
                    iBasica = tarifa.basico;
                    iIntermedia = tarifa.intermedio;
                    iExcedente = tarifa.excedente;
                }

                if (tarifa.tipo == "Domestico") {
                    dBasica = tarifa.basico;
                    dIntermedia = tarifa.intermedio;
                    dExcedente = tarifa.excedente;
                }
            
            }

            //Generamos un recibo 
            double iTotalBasica, iTotalIntermedia, iTotalExcedente;
            double dTotalBasica, dTotalIntermedia, dTotalExcedente;
            double kwBasico, kwIntermedio, kwExcedente;
            iTotalBasica = iTotalIntermedia = iTotalExcedente = 0;
            dTotalBasica = dTotalIntermedia = dTotalExcedente = 0;
            kwBasico = kwIntermedio = kwExcedente = 0;
            //Se trae los consumos
            List<Consumos> consumos = new List<Consumos>();
            consumos = DatabaseManagement.getInstance().getConsumoEspecifico(medidor, year, month);
            foreach (var row in consumos) {
                double consumoTotal = row.consumo;

                if (consumoTotal > 100 ) {
                    double consumoIntermedio, consumoExcedente;
                    if (consumoTotal > 150)
                    {
                        consumoExcedente = consumoTotal - 150;
                        kwExcedente = consumoExcedente;
                        iTotalExcedente = consumoExcedente * iExcedente;
                        dTotalExcedente = consumoExcedente * dExcedente;
                        consumoIntermedio = 50;
                        kwIntermedio = consumoIntermedio;
                        iTotalIntermedia = consumoIntermedio * iIntermedia;
                        dTotalIntermedia = consumoIntermedio * dIntermedia;
                    }
                    else {
                        consumoIntermedio = consumoTotal - 100;
                        kwIntermedio = consumoIntermedio;   
                        iTotalIntermedia = consumoIntermedio * iIntermedia;
                        dTotalIntermedia = consumoIntermedio * dIntermedia;
                    }
                    kwBasico = 100;
                    iTotalBasica = iBasica * 100;
                    dTotalBasica = dBasica * 100;
                }

                if (consumoTotal <= 100) {
                    kwBasico = consumoTotal;
                    iTotalBasica = consumoTotal * iBasica;
                    dTotalBasica = consumoTotal * dBasica;
                }

                double medidorRow = row.num_medidor;
                List<Contratos> contratos = new List<Contratos>();
                contratos = DatabaseManagement.getInstance().GetContratosMedidorTipo();
                foreach (var contrato in contratos) {
                    if (contrato.num_medidor == row.num_medidor) {
                        if ((contrato.tipo.ToString()).Equals("Industrial")){
                            double sinIVA = iTotalBasica + iTotalIntermedia + iTotalExcedente;
                            double conIVA = sinIVA * 1.16;
                            DatabaseManagement.getInstance().insertRecibo(medidor.ToString(), year.ToString(), month.ToString(), iTotalBasica, iTotalIntermedia, iTotalExcedente, sinIVA, conIVA, kwBasico.ToString(), kwIntermedio.ToString(), kwExcedente.ToString(),"SIN PAGAR", "PENDIENTE");
                        }
                        if ((contrato.tipo.ToString()).Equals("Domestico")){
                            double sinIVA = dTotalBasica + dTotalIntermedia + dTotalExcedente;
                            double conIVA = sinIVA * 1.16;
                            DatabaseManagement.getInstance().insertRecibo(medidor.ToString(), year.ToString(), month.ToString(), dTotalBasica, dTotalIntermedia, dTotalExcedente, sinIVA, conIVA, kwBasico.ToString(), kwIntermedio.ToString(), kwExcedente.ToString(), "SIN PAGAR", "PENDIENTE");
                        }
                    }
                }  
            }
        }

        //conseguir los consumos
        public List<Consumos> getConsumos()
        {
            string query = "SELECT * FROM CONSUMOS;";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Consumos> consumos = mapper.Fetch<Consumos>(query);
            return consumos.ToList();
        }

        //Solo el numero de los medidores
        public List<Contratos> numerosMedidores() {
            string query = "SELECT NUM_MEDIDOR FROM CONTRACTS;";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Contratos> consumos = mapper.Fetch<Contratos>(query);
            return consumos.ToList();

        }


        //Se regresa el consumo buscado
        //Poner validacion si no existe
        public List<Consumos> getConsumoEspecifico(string numero_medidor, string year, string month)
        {
            string query = "SELECT * FROM CONSUMOS WHERE NUM_MEDIDOR = "+numero_medidor+" AND YEAR = '"+year+"' AND MONTH = '"+month+"';";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Consumos> consumos = mapper.Fetch<Consumos>(query);
            return consumos.ToList();
        }

        public List<Consumos> getConsumoMeses(string numero_medidor)
        {
            string query = "SELECT MONTH FROM CONSUMOS WHERE NUM_MEDIDOR = " + numero_medidor + ";";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Consumos> consumos = mapper.Fetch<Consumos>(query);
            return consumos.ToList();
        }

        //Crear un recibo
        public void insertRecibo(string num_medidor, string year, string month, double basico, double intermedio, double excedente, double total, double totalIVA, string kw_basico, string kw_intermedio, string kw_excedente, string pagado, string tipoDePago) {
            string query = "INSERT INTO RECIBOS(NUM_MEDIDOR, YEAR, MONTH, PAGAR_BASICO, PAGAR_INTERMEDIO, PAGAR_EXCEDENTE, PAGAR_TOTAL, PAGAR_TOTAL_IVA, KW_BASICO, KW_INTERMEDIO, KW_EXCEDENTE, PAGADO, TIPO_DE_PAGO)"
                            + "VALUES("+num_medidor+",'"+year+"', '"+month+"', "+basico+", "+intermedio+", "+excedente+","+total+","+totalIVA+", "+kw_basico+", "+kw_intermedio+", "+kw_excedente+", '"+pagado+"', '"+tipoDePago+"');";
            session.Execute(query);
        }

        //Obtener un recibo
        public List<Recibos> getReciboEspecifico(string numero_medidor, string year, string month)
        {
            string query = "SELECT * FROM RECIBOS WHERE NUM_MEDIDOR = " + numero_medidor + " AND YEAR = '" + year + "' AND MONTH = '" + month + "';";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Recibos> recibo = mapper.Fetch<Recibos>(query);
            return recibo.ToList();
        }

        //Obtiene los recibos
        public List<Recibos> getRecibos()
        {
            string query = "SELECT NUM_MEDIDOR, YEAR, MONTH, PAGAR_TOTAL_IVA, PAGADO, KW_BASICO, KW_INTERMEDIO, KW_EXCEDENTE, PAGAR_BASICO, PAGAR_INTERMEDIO, PAGAR_EXCEDENTE, TIPO_DE_PAGO FROM RECIBOS;";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Recibos> recibo = mapper.Fetch<Recibos>(query);
            return recibo.ToList();
        }

        //Obtener tabla de contratos con columnas necesarias
        public List<Contratos> getContratosServicioMedidor()
        {
            string query = "SELECT NUM_SERVICIO, NUM_MEDIDOR, ID_CLIENTE FROM CONTRACTS;";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Contratos> contratos = mapper.Fetch<Contratos>(query);
            return contratos.ToList();
        }

        //Obtener el cliente en especifico 
        public List<Clientes> getContratoConClientID(string id_client) {
            string query = "SELECT * FROM CLIENTS WHERE CLIENT_ID = "+id_client+ ";";
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Clientes> cliente = mapper.Fetch<Clientes>(query);
            return cliente.ToList();

        }

        public void pagarRecibo(string num_medidor, string year, string mes, string tipoPago) { 
            string query = "UPDATE RECIBOS SET PAGADO = 'PAGADO', TIPO_DE_PAGO = '"+tipoPago+"' WHERE NUM_MEDIDOR = "+ num_medidor+" AND YEAR = '"+year+"' AND MONTH = '"+mes+"';";
            session.Execute(query);
        }

    }
}
