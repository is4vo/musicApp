
namespace musicAPP
{
    partial class AgregarPlaylist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string name = "")
        {
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.botonCanciones = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.inputNombrePlaylist = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.SubirCancionesPlaylist = new System.Windows.Forms.Button();
            this.cantidadArchivos = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.CrearPlaylist = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.botonCanciones);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(281, 300);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // botonCanciones
            // 
            this.botonCanciones.BackColor = System.Drawing.Color.Black;
            this.botonCanciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonCanciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.botonCanciones.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonCanciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.botonCanciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCanciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCanciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.botonCanciones.Location = new System.Drawing.Point(3, 3);
            this.botonCanciones.Name = "botonCanciones";
            this.botonCanciones.Size = new System.Drawing.Size(300, 38);
            this.botonCanciones.TabIndex = 6;
            this.botonCanciones.Text = "Agrear nueva playlist";
            this.botonCanciones.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.inputNombrePlaylist);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 47);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(278, 56);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(86, 53);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputNombrePlaylist
            // 
            if (name.Equals(""))
            {
                this.inputNombrePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.inputNombrePlaylist.Location = new System.Drawing.Point(95, 15);
                this.inputNombrePlaylist.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
                this.inputNombrePlaylist.Name = "inputNombrePlaylist";
                this.inputNombrePlaylist.Size = new System.Drawing.Size(174, 26);
                this.inputNombrePlaylist.TabIndex = 1;
            }
            else
            {
                this.inputNombrePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.inputNombrePlaylist.Location = new System.Drawing.Point(95, 15);
                this.inputNombrePlaylist.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
                this.inputNombrePlaylist.Name = "inputNombrePlaylist";
                this.inputNombrePlaylist.Size = new System.Drawing.Size(174, 26);
                this.inputNombrePlaylist.TabIndex = 1;
                this.inputNombrePlaylist.Text = name;
                this.inputNombrePlaylist.Enabled = false;
            }
            
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel5.Controls.Add(this.cantidadArchivos);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 109);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(278, 56);
            this.flowLayoutPanel5.TabIndex = 8;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.SubirCancionesPlaylist);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(142, 53);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // SubirCancionesPlaylist
            // 
            this.SubirCancionesPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubirCancionesPlaylist.Location = new System.Drawing.Point(3, 3);
            this.SubirCancionesPlaylist.Name = "SubirCancionesPlaylist";
            this.SubirCancionesPlaylist.Size = new System.Drawing.Size(139, 50);
            this.SubirCancionesPlaylist.TabIndex = 0;
            this.SubirCancionesPlaylist.Text = "Subir canciones";
            this.SubirCancionesPlaylist.UseVisualStyleBackColor = true;
            this.SubirCancionesPlaylist.Click += new System.EventHandler(this.SubirCancionesPlaylist_Click);
            // 
            // cantidadArchivos
            // 
            this.cantidadArchivos.AutoSize = true;
            this.cantidadArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadArchivos.Location = new System.Drawing.Point(168, 20);
            this.cantidadArchivos.Margin = new System.Windows.Forms.Padding(20, 20, 3, 0);
            this.cantidadArchivos.Name = "cantidadArchivos";
            this.cantidadArchivos.Size = new System.Drawing.Size(90, 20);
            this.cantidadArchivos.TabIndex = 1;
            this.cantidadArchivos.Text = "0 archivo(s)";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.CrearPlaylist);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 171);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(278, 145);
            this.flowLayoutPanel7.TabIndex = 9;
            // 
            // CrearPlaylist
            // 
            this.CrearPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearPlaylist.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CrearPlaylist.Location = new System.Drawing.Point(3, 50);
            this.CrearPlaylist.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.CrearPlaylist.Name = "CrearPlaylist";
            this.CrearPlaylist.Size = new System.Drawing.Size(275, 33);
            this.CrearPlaylist.TabIndex = 0;
            this.CrearPlaylist.Text = "Aceptar";
            this.CrearPlaylist.UseVisualStyleBackColor = true;
            this.CrearPlaylist.Click += new System.EventHandler(this.CrearPlaylist_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AgregarPlaylist
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.flowLayoutPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarPlaylist";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar playlist";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button botonCanciones;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputNombrePlaylist;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button SubirCancionesPlaylist;
        private System.Windows.Forms.Label cantidadArchivos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Button CrearPlaylist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}