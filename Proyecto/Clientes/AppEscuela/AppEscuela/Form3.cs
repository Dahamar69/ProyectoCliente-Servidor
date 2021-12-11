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
    public partial class Form3 : Form
    {
        TextBox[] textBoxArray = new TextBox[15];
        Label[] label = new Label[15];
        string consulta;
        public static string idcliente;
        DataSet ds = new DataSet();

        public Form3()
        {
            InitializeComponent();
            consulta = "select * from lista";
            label1.Text = "Lis";
            label1.Visible = true;
            Datos.MostrarTabla(ds, consulta, "Escuela", dataGridView1);



            textBoxArray[6] = txtcalificacion;

            label[6] = lblcalificacion;


            button1.Visible = false;
            lblcalificacion.Visible = false;
            txtcalificacion.Visible = false;
          
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dataGridView1.CurrentRow;

            for (int i = 2; i <= dataGridView1.ColumnCount - 1; i++)
            {
                if (i == 0)
                {
                    textBoxArray[i].Visible = true;
                    label[i].Visible = true;
                    label[i].Text = dataGridView1.Columns[i].HeaderText.ToString();
                    textBoxArray[i].Text = row.Cells[i].Value.ToString();
                    textBoxArray[i].Enabled = false;
                    i++;
                }
                if (i == 1)
                {
                    textBoxArray[i].Visible = true;
                    label[i].Visible = true;
                    label[i].Text = dataGridView1.Columns[i].HeaderText.ToString();
                    textBoxArray[i].Text = row.Cells[i].Value.ToString();
                    textBoxArray[i].Enabled = false;
                    i++;
                }
                txtcalificacion.Visible = true;
                lblcalificacion.Visible = true;
                

                lblcalificacion.Visible = true;
                txtcalificacion.Visible = true;
            }
            textBoxArray[6].Text = row.Cells[6].Value.ToString();
            button1.Visible = true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            Form1 a = new Form1();
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcalificacion.Text == "")
            {
                MessageBox.Show("Llenar el campos");
                return;
            }
            DataGridViewRow row = dataGridView1.CurrentRow;
            string[] row1 = new string[9];
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
            {
                row1[i] = row.Cells[i].Value.ToString();
            }

            consulta = "UPDATE lista SET calificacion = "+textBoxArray[6].Text+ " WHERE id = "+row1[0];
            Datos.modificar(consulta);


            consulta = "SELECT * FROM lista"; ;
            Datos.MostrarTabla(ds, consulta, "Cliente", dataGridView1);
            button1.Visible = false;
            lblcalificacion.Visible = false;
            txtcalificacion.Visible = false;
        }
    }
}

