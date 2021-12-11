using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AppEscuela
{
    public class Datos
    {
        private static SqlConnection sqlconexion = new SqlConnection("Server = localhost\\SQLEXPRESS;Database = Escuela; Trusted_Connection = True;");
        public static int count = 0;

        public static void MostrarTabla(DataSet ds, string consulta, string nombreTabla, DataGridView dataGridView1)
        {
            SqlDataAdapter da = new SqlDataAdapter(consulta, sqlconexion);
            ds = new DataSet();
            da.Fill(ds, nombreTabla);
            dataGridView1.DataSource = ds.Tables[nombreTabla];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void InsertarRegistro(string consulta)
        {
            try
            {
                SqlCommand comando = new SqlCommand(consulta, sqlconexion);
                sqlconexion.Open();
                if (comando.ExecuteNonQuery() != 0)
                {
                    //MessageBox.Show("SE REGISTRO CORRECTAMENTE");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("HUBO UN ERROR, FAVOR DE CHECAR BIEN LOS DATOS\n" + ex.Message);
            }
            sqlconexion.Close();
        }

        public static int Eliminar(string consulta, string nombre, string id, ComboBox cbTablas)
        {
            int registrosAfectados = 0;
            try
            {
                SqlCommand comando = new SqlCommand(consulta, sqlconexion);
                sqlconexion.Open();
                if (comando.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("SE ELIMINO CORRECTAMENTE");
                    registrosAfectados = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("HUBO UN ERROR, FAVOR DE CHECAR BIEN LOS DATOS\n" + ex.Message);
            }
            sqlconexion.Close();
            return registrosAfectados;
        }

        public static void modificar(string consulta)
        {
            try
            {
                SqlCommand comando = new SqlCommand(consulta, sqlconexion);
                sqlconexion.Open();
                if (comando.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Se modifico correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("HUBO UN ERROR, FAVOR DE CHECAR BIEN LOS DATOS\n" + ex.Message);
            }
            sqlconexion.Close();
        }

        public static void contarid(string consulta)
        {
            sqlconexion.Open();
            SqlCommand cont = new SqlCommand(consulta, sqlconexion);
            count = (int)cont.ExecuteScalar();
            count++;
            sqlconexion.Close();
        }
    }
}