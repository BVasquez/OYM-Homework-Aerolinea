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
    public partial class Frm_Trip : Form
    {
        string _id;
        string Conexion = "Data Source=MAINDELL;Initial Catalog=AEROLINEA;Integrated Security=True";

        public Frm_Trip()
        {
            InitializeComponent();
        }

        public Frm_Trip(string id)
        {
            InitializeComponent();
            _id = id;
        }

        public DataTable Listado_Vuelo()
        {
            SqlConnection cx = new SqlConnection(Conexion);
            DataTable tb = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT ID_PERSONA AS 'ID', NOMBRE FROM TRIPULACION WHERE VUELO = '"+_id+"'", cx);
            cx.Open();
            adpt.Fill(tb);
            cx.Close();
            return tb;
        }

        private void Frm_Trip_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Listado_Vuelo();
        }






    }
}
