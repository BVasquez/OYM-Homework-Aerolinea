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
    public partial class Frm_Vuelo : Form
    {
        public Frm_Vuelo()
        {
            InitializeComponent();
        }

        string Conexion = "Data Source=MAINDELL;Initial Catalog=AEROLINEA;Integrated Security=True";
        string Accion;

        public int NuevoID()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("SELECT TOP 1 ID FROM VUELO ORDER BY ID_VUELO DESC", cx);
            cx.Open();
            int id = Convert.ToInt32(comando.ExecuteScalar()) + 1;
            cx.Close();
            return id;
        }


        public void Agregar_Vuelo(int id, string id_vuelo, string origen, string destino, string hora, string avion, string piloto)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("INSERT INTO VUELO(ID, ID_VUELO, ORIGEN, DESTINO, HORA_VUELO, PILOTO, AVION, FECHA) VALUES(@ID, @ID_VUELO, @ORIGEN, @DESTINO, @HORA_VUELO, @PILOTO, @AVION, @FECHA)", cx);
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@ID_VUELO", id_vuelo);
            comando.Parameters.AddWithValue("@ORIGEN", origen);
            comando.Parameters.AddWithValue("@DESTINO", destino);
            comando.Parameters.AddWithValue("@HORA_VUELO", hora);
            comando.Parameters.AddWithValue("@AVION", avion);
            comando.Parameters.AddWithValue("@PILOTO", piloto);
            comando.Parameters.AddWithValue("@FECHA", DateTime.Now);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Editar_Vuelo(string id_vuelo, string origen, string destino, string hora, string avion, string piloto)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("UPDATE VUELO SET ORIGEN =@ORIGEN, DESTINO=@DESTINO, HORA_VUELO=@HORA_VUELO, AVION=@AVION, PILOTO=@PILOTO WHERE ID_VUELO = @ID_VUELO", cx);
            comando.Parameters.AddWithValue("@ID_VUELO", id_vuelo);
            comando.Parameters.AddWithValue("@ORIGEN", origen);
            comando.Parameters.AddWithValue("@DESTINO", destino);
            comando.Parameters.AddWithValue("@HORA_VUELO", hora);
            comando.Parameters.AddWithValue("@AVION", avion);
            comando.Parameters.AddWithValue("@PILOTO", piloto);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }


        public void Eliminar_Vuelo(string id_vuelo)
        {
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand comando = new SqlCommand("DELETE VUELO WHERE ID_VUELO = @ID_VUELO", cx);
            comando.Parameters.AddWithValue("@ID_VUELO", id_vuelo);
            cx.Open();
            comando.ExecuteNonQuery();
            cx.Close();
        }



        public DataTable Listado_Vuelo()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT ID_VUELO AS 'ID', ORIGEN, DESTINO, HORA_VUELO AS 'HORA', PILOTO, AVION, FECHA FROM VUELO", cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }


        public DataTable Listado_Filtrado(string filtro)
        {
            string filt = "";
            switch (filtro)
            {
                case "":
                    filt = "SELECT ID_VUELO AS 'ID', ORIGEN, DESTINO, HORA_VUELO AS 'HORA', PILOTO, AVION, FECHA FROM VUELO";
                    break;
                case "REALIZADO":
                    filt = "SELECT ID_VUELO AS 'ID', ORIGEN, DESTINO, HORA_VUELO AS 'HORA', PILOTO, AVION, FECHA FROM VUELO WHERE FECHA BETWEEN '" + dateTimePicker1.Value.ToString("MM-dd-yyyy") + "' AND GETDATE()";
                    break;
                case "NO REALIZADO":
                    filt= "SELECT ID_VUELO AS 'ID', ORIGEN, DESTINO, HORA_VUELO AS 'HORA', PILOTO, AVION, FECHA FROM VUELO WHERE FECHA BETWEEN GETDATE() AND '" + dateTimePicker1.Value.ToString("MM-dd-yyyy") + "'";
                    break;
            }
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(filt, cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }



        public string[] Listado_Piloto()
        {
            List<string> listado = new List<string>();
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand commando = new SqlCommand("SELECT NOMBRE FROM PILOTOS", cx);
            cx.Open();
            SqlDataReader Reader = commando.ExecuteReader();
            while (Reader.Read())
            {
                listado.Add(Reader.GetString(0));
            }
            cx.Close();
            return listado.ToArray();
        }


        public string[] Listado_Avion()
        {
            List<string> listado = new List<string>();
            SqlConnection cx = new SqlConnection(Conexion);
            SqlCommand commando = new SqlCommand("SELECT NOMBRE FROM AVIONES", cx);
            cx.Open();
            SqlDataReader Reader = commando.ExecuteReader();
            while (Reader.Read())
            {
                listado.Add(Reader.GetString(0));
            }
            cx.Close();
            return listado.ToArray();
        }


        private void Frm_Vuelo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listado_Vuelo();
            comboBox1.Items.AddRange(Listado_Piloto());
            comboBox2.Items.AddRange(Listado_Avion());
            comboBox3.Items.AddRange(new string[] { "", "REALIZADO", "NO REALIZADO" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accion = "AGREGAR";
            label2.Text = "VU-" + NuevoID().ToString();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            maskedTextBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = false;
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "")
            {
                switch (Accion)
                {
                    case "AGREGAR":
                        Agregar_Vuelo(NuevoID(), label2.Text, textBox1.Text, textBox2.Text, maskedTextBox1.Text, comboBox2.Text, comboBox1.Text);
                        break;

                    case "EDITAR":
                        Editar_Vuelo(label2.Text, textBox1.Text, textBox2.Text, maskedTextBox1.Text, comboBox2.Text, comboBox1.Text);
                        break;
                }
                MessageBox.Show("Guardado");
                dataGridView1.DataSource = Listado_Vuelo();
                label2.Text = "-----";
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                maskedTextBox1.Clear();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                maskedTextBox1.Enabled = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = true;
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
            textBox2.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            maskedTextBox1.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value);
            comboBox1.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value);
            comboBox2.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value);
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            maskedTextBox1.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = false;
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "------";
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            comboBox1.Text="";
            comboBox2.Text="";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de Eliminarlo?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Eliminar_Vuelo(Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
                dataGridView1.DataSource = Listado_Vuelo();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Trip tripu = new Frm_Trip(Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
            tripu.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listado_Filtrado(comboBox3.Text);
        }
    }
}
