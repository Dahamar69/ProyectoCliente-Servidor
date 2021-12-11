using System;
using System.Data.SqlClient;

namespace escuelaConsola
{
    class Program
    {
        static string cadenaDeConexion = string.Empty;
        static SqlConnection conexion = null;
        static SqlCommand mySqlCommand = null;
        static SqlDataReader mySqlDataReader = null;
        static void Main(string[] args)
        {
            ConectarASQLServer();
            Mostrarlista();
            CerrarConexion();
        }

        private static void ConectarASQLServer()
        {
            try
            {
                cadenaDeConexion = "Server = localhost\\SQLEXPRESS;Database = Escuela; Trusted_Connection = True;";
                conexion = new SqlConnection(cadenaDeConexion);
                conexion.Open();
                Console.WriteLine("Conexion exitosa a SQL Server");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void Mostrarlista()
        {
            try
            {
                string sqlQuery = "SELECT * FROM lista";
                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("LISTA \n");
                Console.WriteLine("Id\t\t Nombre\t\t Apellido Paterno \t\t Apellido Materno \t\t Materia \t\t Credito \t\t Calificacion");
                Console.WriteLine("_________________________________________________________________________________________________________________________________________________________");
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine($"{mySqlDataReader["id"]}\t\t {mySqlDataReader["Nombre"]}\t\t {mySqlDataReader["apellidopaterno"]}\t\t {mySqlDataReader["apellidomaterno"]}\t\t {mySqlDataReader["materia"]}\t\t{mySqlDataReader["creditos"]}\t\t{mySqlDataReader["calificacion"]}");
                }
                mySqlDataReader.Close();



                sqlQuery = "SELECT * FROM Alumno";
                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("\n\n\n ALUMNOS \n");
                Console.WriteLine("Id\t\t Nombre\t\t Apellido Paterno \t\t Apellido Materno \t\t Direccion \t\t Telefono \t\t Matricula");
                Console.WriteLine("_________________________________________________________________________________________________________________________________________________________");
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine($"{mySqlDataReader["id"]}\t\t {mySqlDataReader["Nombre"]}\t\t {mySqlDataReader["apellidoPaterno"]}\t\t {mySqlDataReader["apellidoMaterno"]}\t\t {mySqlDataReader["direccion"]}\t\t{mySqlDataReader["telefono"]}\t\t{mySqlDataReader["matricula"]}");
                }
                mySqlDataReader.Close();



                sqlQuery = "SELECT * FROM materia";
                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("\n\n\n MATERIAS \n");
                Console.WriteLine("Nombre\t\t Credito");
                Console.WriteLine("_____________________________________________________________________________________________________________________");
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine($"{mySqlDataReader["nombre"]}\t\t {mySqlDataReader["credito"]}");
                }
                mySqlDataReader.Close();


                sqlQuery = "SELECT * FROM Maestro";
                mySqlCommand = new SqlCommand(sqlQuery, conexion);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                Console.WriteLine("\n\n\n MAESTROS \n");
                Console.WriteLine("Id\t\t Nombre\t\t Apellido Paterno \t\t Apellido Materno \t\t Telefono");
                Console.WriteLine("_________________________________________________________________________________________________________________________________________________________");
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine($"{mySqlDataReader["id"]}\t\t {mySqlDataReader["Nombre"]}\t\t {mySqlDataReader["apellidoPaterno"]}\t\t {mySqlDataReader["apellidoMaterno"]}\t\t{mySqlDataReader["telefono"]}");
                }
                mySqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problema al tratar de conectar a BD. Detalles:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
            
