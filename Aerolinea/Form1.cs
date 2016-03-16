using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aVIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Avion frmAvion = new Frm_Avion();
            frmAvion.MdiParent = this;
            frmAvion.Show();
        }

        private void pILOTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Piloto frmPiloto = new Frm_Piloto();
            frmPiloto.MdiParent = this;
            frmPiloto.Show();
        }

        private void tRIPULANTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Tripulante frmTripulante = new Frm_Tripulante();
            frmTripulante.MdiParent = this;
            frmTripulante.Show();
        }

        private void vUELOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Vuelo frmVuelo = new Frm_Vuelo();
            frmVuelo.MdiParent = this;
            frmVuelo.Show();
        }
    }
}
