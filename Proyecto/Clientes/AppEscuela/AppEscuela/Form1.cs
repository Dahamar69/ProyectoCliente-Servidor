using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppEscuela
{
    public partial class Form1 : Form
    {
        public static string maestro;
        public static string usuario;
        public static string contraseñausuario;
        public static int id;
        public static int empleado;
        string contar = "SELECT COUNT(*) FROM Usuario";
        SqlConnection sqlconexion = new SqlConnection();
        bool contraseña = true;
        int count;
        string consulta = "";
        bool siesmaestro;
        public static bool loginCompañia = true;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Enabled = true;
            txtcontraseña.UseSystemPasswordChar = !contraseña;
            sqlconexion = new SqlConnection("Server = localhost\\SQLEXPRESS;Database = Escuela; Trusted_Connection = True;");
        }


        private void btniniciarsesion_Click(object sender, EventArgs e)
        {
            if (txtnombrecompañia.Text == "" || txtnombrecompañia.Text == "Usuario")
            {
                MessageBox.Show("Ingresa un usuario.");
                return;
            }


            count = 0;
            sqlconexion.Close();
            sqlconexion.Open();
            SqlCommand cont = new SqlCommand(contar, sqlconexion);
            count = (int)cont.ExecuteScalar();
            sqlconexion.Close();
            consulta = "SELECT id,usuario,CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('password',contraseña))Contraseña from Usuario";
            sqlconexion.Open();
            SqlCommand comando = new SqlCommand(consulta, sqlconexion);
            SqlDataReader dr = comando.ExecuteReader();
            dr.Read();

            for (int i = 0; i < count; i++)
            {
                usuario = (dr["usuario"] + "");
                
                if (usuario == txtnombrecompañia.Text)
                {

                    contraseñausuario = (dr["contraseña"] + "");
                    if (contraseñausuario == txtcontraseña.Text)
                    {
                        maestroo();
                        if (siesmaestro == true)
                        {
                            Form3 bd = new Form3();
                            bd.Text = usuario;
                            bd.Show();
                            this.Hide();
                            empleado = i + 1;
                            contraseñausuario = txtcontraseña.Text;
                            loginCompañia = false;
                            sqlconexion.Close();
                            return;
                        }
                        else
                        {
                            Form2 bd = new Form2();
                            bd.Text = usuario;
                            bd.Show();
                            this.Hide();
                            empleado = i + 1;
                            contraseñausuario = txtcontraseña.Text;
                            loginCompañia = false;
                            sqlconexion.Close();
                            return;
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                        sqlconexion.Close();
                        return;
                    }
                }

                if (i == count - 1)
                {
                    MessageBox.Show("Usuario incorrecto");
                    return;
                }
                dr.Read();
            }
            sqlconexion.Close();
        }

        private void maestroo()
        {
            count = 0;
            sqlconexion.Close();
            sqlconexion.Open();
            string contar = "SELECT COUNT(*) FROM Maestro";
            SqlCommand cont = new SqlCommand(contar, sqlconexion);
            count = (int)cont.ExecuteScalar();
            sqlconexion.Close();
            consulta = "SELECT * FROM Maestro";
            sqlconexion.Open();
            SqlCommand comando = new SqlCommand(consulta, sqlconexion);
            SqlDataReader dr = comando.ExecuteReader();
            dr.Read();

            for (int i = 0; i < count; i++)
            {

                maestro = (dr["nombre"]+"");
                if (usuario == maestro)
                {
                    siesmaestro = true;
                    return;
                }
                else
                {
                    siesmaestro = false;
                }
                dr.Read();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}