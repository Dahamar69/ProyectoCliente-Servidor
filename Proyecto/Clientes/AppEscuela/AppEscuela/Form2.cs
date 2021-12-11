using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscuela
{
    public partial class Form2 : Form
    {
        string consulta;
        DataSet ds = new DataSet();
        public Form2()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnKardex_Click(object sender, EventArgs e)
        {
            string nomb = Form1.usuario.ToLower();
            consulta = "select * from lista where nombre='"+nomb+"'";
            label1.Text = "Lista";
            label1.Visible = true;
            Datos.MostrarTabla(ds, consulta, "Escuela", dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalificaciones_Click(object sender, EventArgs e)
        {
            consulta = "select * from materia";
            label1.Text = "Materia";
            label1.Visible = true;
            Datos.MostrarTabla(ds, consulta, "Escuela", dataGridView1);
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Close();
        }
    }
}
