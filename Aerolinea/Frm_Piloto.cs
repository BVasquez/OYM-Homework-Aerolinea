using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Aerolinea
{
    public partial class Frm_Piloto : Form
    {

        string Conexion = "Data Source=MAINDELL;Initial Catalog=AEROLINEA;Integrated Security=True";
        string Accion;

        public int NuevoID()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("SELECT TOP 1 ID FROM PILOTOS ORDER BY ID_PILOTO DESC", cx);
            cx.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar()) + 1;
            cx.Close();
            return id;
        }


        public void Agregar_Piloto(int id, string id_piloto, string nombre, string hora)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("INSERT INTO PILOTOS(ID, ID_PILOTO, NOMBRE, HORA_VUELO) VALUES(@ID, @ID_PILOTO, @NOMBRE, @HORA_VUELO)", cx);
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@ID_PILOTO", id_piloto);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@HORA_VUELO", hora);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Editar_Piloto(string id_piloto, string nombre, string hora)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("UPDATE PILOTOS SET NOMBRE =@NOMBRE, HORA_VUELO=@HORA_VUELO WHERE ID_PILOTO = @ID_PILOTO", cx);
            comando.Parameters.AddWithValue("@ID_PILOTO", id_piloto);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@HORA_VUELO", hora);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Eliminar_Piloto(string id_piloto)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("DELETE PILOTOS WHERE ID_PILOTO = @ID_PILOTO", cx);
            comando.Parameters.AddWithValue("@ID_PILOTO", id_piloto);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public DataTable Listado_Piloto()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT ID_PILOTO AS 'ID', NOMBRE, HORA_VUELO AS 'HORA' FROM PILOTOS", cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }


        public Frm_Piloto()
        {
            InitializeComponent();
        }

        private void Frm_Piloto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listado_Piloto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accion = "AGREGAR";
            label2.Text = "PI-" + NuevoID().ToString();
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && maskedTextBox1.Text !="")
            {
                switch(Accion)
                {
                    case "AGREGAR":
                        Agregar_Piloto(NuevoID(), label2.Text, textBox1.Text, maskedTextBox1.Text);
                        break;

                    case "EDITAR":
                        Editar_Piloto(label2.Text, textBox1.Text, maskedTextBox1.Text);
                        break;
                }
                MessageBox.Show("Guardado");
                dataGridView1.DataSource = Listado_Piloto();
                label2.Text = "------";
                textBox1.Clear();
                maskedTextBox1.Clear();
                textBox1.Enabled = false;
                maskedTextBox1.Enabled = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Hay campos vacios, debes llenarlo");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "------";
            textBox1.Clear();
            maskedTextBox1.Clear();
            textBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accion = "EDITAR";
            label2.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            textBox1.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
            maskedTextBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de Eliminarlo?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Eliminar_Piloto(Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
                dataGridView1.DataSource = Listado_Piloto();
            }
        }
    }
}
