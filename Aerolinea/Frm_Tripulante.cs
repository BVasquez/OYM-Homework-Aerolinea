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
    public partial class Frm_Tripulante : Form
    {
        public Frm_Tripulante()
        {
            InitializeComponent();
        }

        string Conexion = "Data Source=MAINDELL;Initial Catalog=AEROLINEA;Integrated Security=True";
        string Accion;

        public int NuevoID()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("SELECT TOP 1 ID FROM TRIPULACION ORDER BY ID_PERSONA DESC", cx);
            cx.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar()) + 1;
            cx.Close();
            return id;
        }


        public void Agregar_Tripulante(int id, string id_persona, string nombre, string vuelo)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("INSERT INTO TRIPULACION(ID, ID_PERSONA, NOMBRE, VUELO) VALUES(@ID, @ID_PERSONA, @NOMBRE, @VUELO)", cx);
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@ID_PERSONA", id_persona);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@VUELO", vuelo);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Editar_Tripulante(string id_persona, string nombre, string vuelo)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("UPDATE TRIPULACION SET NOMBRE =@NOMBRE, VUELO=@VUELO WHERE ID_PERSONA = @ID_PERSONA", cx);
            comando.Parameters.AddWithValue("@ID_PERSONA", id_persona);
            comando.Parameters.AddWithValue("@NOMBRE", nombre);
            comando.Parameters.AddWithValue("@VUELO", vuelo);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Eliminar_Tripulante(string id_persona)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("DELETE TRIPULACION WHERE ID_PERSONA = @ID_PERSONA", cx);
            comando.Parameters.AddWithValue("@ID_PERSONA", id_persona);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public DataTable Listado_Tripulante()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT ID_PERSONA AS 'ID', NOMBRE, VUELO FROM TRIPULACION", cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }


        public string[] Listado_Vuelo()
        {
            List<string> listado = new List<string>();
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand commando = new SqlCommand("SELECT ID_VUELO FROM VUELO", cx);
            cx.Open();
            SqlDataReader Reader = commando.ExecuteReader();
            while(Reader.Read())
            {
                listado.Add(Reader.GetString(0));
            }
            cx.Close();
            return listado.ToArray();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Tripulante_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Listado_Vuelo());
            dataGridView1.DataSource = Listado_Tripulante();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accion = "AGREGAR";
            label2.Text = "TRI-" + NuevoID().ToString();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                switch (Accion)
                {
                    case "AGREGAR":
                        Agregar_Tripulante(NuevoID(), label2.Text, textBox1.Text, comboBox1.Text);
                        break;

                    case "EDITAR":
                        Editar_Tripulante(label2.Text, textBox1.Text, comboBox1.Text);
                        break;
                }
                MessageBox.Show("Guardado");
                dataGridView1.DataSource = Listado_Tripulante();
                label2.Text = "------";
                textBox1.Clear();
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Accion = "EDITAR";
            label2.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
            textBox1.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);          
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "------";
            textBox1.Clear();
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            textBox1.Focus();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de Eliminarlo?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Eliminar_Tripulante(Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
                dataGridView1.DataSource = Listado_Tripulante();
            }
        }






    }
}
