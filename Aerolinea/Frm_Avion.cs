using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class Frm_Avion : Form
    {
        public Frm_Avion()
        {
            InitializeComponent();
        }


        string Conexion = "Data Source=MAINDELL;Initial Catalog=AEROLINEA;Integrated Security=True";
        string Accion;


        public int NuevoID()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("SELECT TOP 1 ID FROM AVIONES ORDER BY ID_AVION DESC", cx);
            cx.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar()) + 1;
            cx.Close();
            return id;
        }


        public void Agregar_Avion(int id, string id_avion, string nombre, string tipo, DateTime mantenimiento)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("INSERT INTO AVIONES(ID, ID_AVION, NOMBRE, TIPO, MANTENIMIENTO) VALUES(@ID, @ID_AVION, @NOMBRE, @TIPO, @MANTENIMIENTO)", cx);
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@ID_AVION", id_avion);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@TIPO", tipo);
            comando.Parameters.AddWithValue("@MANTENIMIENTO", mantenimiento);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Editar_Avion(string id_avion, string nombre, string tipo, DateTime mantenimiento)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("UPDATE AVIONES SET NOMBRE =@NOMBRE, TIPO=@TIPO, MANTENIMIENTO=@MANTENIMIENTO WHERE ID_AVION = @ID_AVION", cx);
            comando.Parameters.AddWithValue("@ID_AVION", id_avion);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@TIPO", tipo);
            comando.Parameters.AddWithValue("@MANTENIMIENTO", mantenimiento);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Eliminar_Avion(string id_avion)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("DELETE AVIONES WHERE ID_AVION = @ID_AVION", cx);
            comando.Parameters.AddWithValue("@ID_AVION", id_avion);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public DataTable Listado_Vuelo()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT ID_AVION AS 'ID', NOMBRE, TIPO, MANTENIMIENTO FROM AVIONES", cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }


        private void Frm_Avion_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "PUBLICA", "PRIVADA", "ESPECIAL" });
            dataGridView1.DataSource = Listado_Vuelo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accion = "AGREGAR";
            label2.Text = "AV-" + NuevoID().ToString();
            comboBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" )
            {
                switch (Accion)
                {
                    case "AGREGAR":
                        Agregar_Avion(NuevoID(), label2.Text, textBox2.Text, comboBox1.Text, dateTimePicker1.Value);
                        break;

                    case "EDITAR":
                        Editar_Avion(label2.Text, textBox2.Text, comboBox1.Text, dateTimePicker1.Value);
                        break;
                }
                MessageBox.Show("Guardado");
                dataGridView1.DataSource = Listado_Vuelo();
                label2.Text = "";
                comboBox1.SelectedIndex = 0;
                textBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.Enabled = false;
                textBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Hay campos vacios, debes llenarlo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Accion = "EDITAR";
            label2.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            comboBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            textBox2.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            comboBox1.Enabled = true;
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "------";
            comboBox1.SelectedIndex = 0;
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Enabled = false;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            textBox2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de Eliminarlo?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Eliminar_Avion(Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
                dataGridView1.DataSource = Listado_Vuelo();
            }
        }
    }
}
