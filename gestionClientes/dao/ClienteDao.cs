using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace gestionClientes.dao
{
    class ClienteDao
    {
        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string baseDeDatos = "clientes";

            string cadenaConexion = "Database=" + baseDeDatos + "; Data Source=" + servidor
                + "; User Id=" + usuario + "; Password=" + password + "";
            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);
            conexionDb.Open();

            return conexionDb;
                       
        }

        public List<Cliente> ObtenerListadoDeCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM `clientes`";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();

            
            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString("Id");
                cliente.Nombre = lectura.GetString("Nombre");
                cliente.Apellido = lectura.GetString("Apellido");
                cliente.Telefono = lectura.GetString("Telefono");
                cliente.Email = lectura.GetString("Email");
                lista.Add(cliente);

                
            }

            comando.Connection.Close();

            return lista; 

        }

        public void Guardar(Cliente cliente)
        {
            if (cliente.Id == null)
            {
                insert(cliente);
            }
            else
            {
                update(cliente);
            }
        }

        private void insert(Cliente cliente)
        {
            string consulta = "INSERT INTO `clientes` (`id`, `Nombre`, `Apellido`, `Telefono`, `Email`) VALUES (NULL, '" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + cliente.Telefono + "', '" + cliente.Email + "');";
            ;
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }

        private void update(Cliente cliente)
        {
            string consulta = "UPDATE `clientes` SET `Nombre` = '" + cliente.Nombre + "', `Apellido` = '"+ cliente.Apellido + "', `Telefono` = '" + cliente.Telefono + "', `Email` = '"+ cliente.Email + "' WHERE `clientes`.`id` = " + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }





        internal void Eliminar(Cliente cliente)
        {
            string consulta = "DELETE FROM `clientes` WHERE `clientes`.`id` = " + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
    }
}
