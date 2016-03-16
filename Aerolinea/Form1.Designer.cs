namespace Aerolinea
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aVIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pILOTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRIPULANTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vUELOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aVIONToolStripMenuItem,
            this.pILOTOToolStripMenuItem,
            this.tRIPULANTEToolStripMenuItem,
            this.vUELOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1141, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aVIONToolStripMenuItem
            // 
            this.aVIONToolStripMenuItem.Name = "aVIONToolStripMenuItem";
            this.aVIONToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.aVIONToolStripMenuItem.Text = "AVION";
            this.aVIONToolStripMenuItem.Click += new System.EventHandler(this.aVIONToolStripMenuItem_Click);
            // 
            // pILOTOToolStripMenuItem
            // 
            this.pILOTOToolStripMenuItem.Name = "pILOTOToolStripMenuItem";
            this.pILOTOToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.pILOTOToolStripMenuItem.Text = "PILOTO";
            this.pILOTOToolStripMenuItem.Click += new System.EventHandler(this.pILOTOToolStripMenuItem_Click);
            // 
            // tRIPULANTEToolStripMenuItem
            // 
            this.tRIPULANTEToolStripMenuItem.Name = "tRIPULANTEToolStripMenuItem";
            this.tRIPULANTEToolStripMenuItem.Size = new System.Drawing.Size(124, 28);
            this.tRIPULANTEToolStripMenuItem.Text = "TRIPULANTE";
            this.tRIPULANTEToolStripMenuItem.Click += new System.EventHandler(this.tRIPULANTEToolStripMenuItem_Click);
            // 
            // vUELOToolStripMenuItem
            // 
            this.vUELOToolStripMenuItem.Name = "vUELOToolStripMenuItem";
            this.vUELOToolStripMenuItem.Size = new System.Drawing.Size(77, 28);
            this.vUELOToolStripMenuItem.Text = "VUELO";
            this.vUELOToolStripMenuItem.Click += new System.EventHandler(this.vUELOToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 509);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aereolinea";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aVIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pILOTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tRIPULANTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vUELOToolStripMenuItem;
    }
}

