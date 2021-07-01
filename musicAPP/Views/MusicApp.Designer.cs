
namespace musicAPP
{
    partial class MusicApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicApp));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sideBar = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.seccionPlaylist = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.agregarPlaylist = new System.Windows.Forms.Button();
            this.label_playlist = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.filtro = new System.Windows.Forms.CheckBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.botonCanciones = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.seccion = new System.Windows.Forms.FlowLayoutPanel();
            this.tituloSeccion = new System.Windows.Forms.FlowLayoutPanel();
            this.reproducerContainer = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.npgsqlCommand1 = new Npgsql.NpgsqlCommand();
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.mensajeAgregarPlaylist = new System.Windows.Forms.ToolTip(this.components);
            this.sideBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.reproducerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sideBar
            // 
            this.sideBar.Controls.Add(this.panel4);
            this.sideBar.Controls.Add(this.panel3);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 0);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(237, 461);
            this.sideBar.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.seccionPlaylist);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 232);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 229);
            this.panel4.TabIndex = 1;
            // 
            // seccionPlaylist
            // 
            this.seccionPlaylist.AutoScroll = true;
            this.seccionPlaylist.Dock = System.Windows.Forms.DockStyle.Left;
            this.seccionPlaylist.Location = new System.Drawing.Point(0, 61);
            this.seccionPlaylist.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.seccionPlaylist.Name = "seccionPlaylist";
            this.seccionPlaylist.Padding = new System.Windows.Forms.Padding(15);
            this.seccionPlaylist.Size = new System.Drawing.Size(219, 168);
            this.seccionPlaylist.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.agregarPlaylist);
            this.panel5.Controls.Add(this.label_playlist);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(237, 61);
            this.panel5.TabIndex = 2;
            // 
            // agregarPlaylist
            // 
            this.agregarPlaylist.BackColor = System.Drawing.SystemColors.Control;
            this.agregarPlaylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.agregarPlaylist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agregarPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agregarPlaylist.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.agregarPlaylist.FlatAppearance.BorderSize = 0;
            this.agregarPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregarPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold);
            this.agregarPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(231)))));
            this.agregarPlaylist.Location = new System.Drawing.Point(167, 0);
            this.agregarPlaylist.Name = "agregarPlaylist";
            this.agregarPlaylist.Size = new System.Drawing.Size(70, 61);
            this.agregarPlaylist.TabIndex = 3;
            this.agregarPlaylist.Text = "+";
            this.mensajeAgregarPlaylist.SetToolTip(this.agregarPlaylist, "Agregar nueva playlist");
            this.agregarPlaylist.UseVisualStyleBackColor = false;
            this.agregarPlaylist.Click += new System.EventHandler(this.agregarPlaylist_Click);
            // 
            // label_playlist
            // 
            this.label_playlist.BackColor = System.Drawing.SystemColors.Control;
            this.label_playlist.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_playlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_playlist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(231)))));
            this.label_playlist.Location = new System.Drawing.Point(0, 0);
            this.label_playlist.Name = "label_playlist";
            this.label_playlist.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_playlist.Size = new System.Drawing.Size(167, 61);
            this.label_playlist.TabIndex = 1;
            this.label_playlist.Text = "Playlists";
            this.label_playlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.filtro);
            this.panel3.Controls.Add(this.searchBox);
            this.panel3.Controls.Add(this.typeBox);
            this.panel3.Controls.Add(this.Logo);
            this.panel3.Controls.Add(this.botonCanciones);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 232);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtrar";
            // 
            // filtro
            // 
            this.filtro.AutoSize = true;
            this.filtro.Location = new System.Drawing.Point(204, 175);
            this.filtro.Name = "filtro";
            this.filtro.Size = new System.Drawing.Size(15, 14);
            this.filtro.TabIndex = 9;
            this.filtro.UseVisualStyleBackColor = true;
            this.filtro.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(102, 172);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(91, 20);
            this.searchBox.TabIndex = 8;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(3, 172);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(92, 21);
            this.typeBox.TabIndex = 7;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // Logo
            // 
            this.Logo.Location = new System.Drawing.Point(43, 30);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(171, 136);
            this.Logo.TabIndex = 6;
            this.Logo.TabStop = false;
            // 
            // botonCanciones
            // 
            this.botonCanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(231)))));
            this.botonCanciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonCanciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.botonCanciones.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.botonCanciones.FlatAppearance.BorderSize = 0;
            this.botonCanciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(177)))), ((int)(((byte)(245)))));
            this.botonCanciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCanciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCanciones.ForeColor = System.Drawing.Color.White;
            this.botonCanciones.Location = new System.Drawing.Point(0, 194);
            this.botonCanciones.Name = "botonCanciones";
            this.botonCanciones.Size = new System.Drawing.Size(237, 38);
            this.botonCanciones.TabIndex = 5;
            this.botonCanciones.Text = " Canciones";
            this.botonCanciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonCanciones.UseVisualStyleBackColor = false;
            this.botonCanciones.Click += new System.EventHandler(this.botonCanciones_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.reproducerContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(237, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 461);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.seccion);
            this.panel2.Controls.Add(this.tituloSeccion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 334);
            this.panel2.TabIndex = 1;
            // 
            // seccion
            // 
            this.seccion.AutoScroll = true;
            this.seccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seccion.Location = new System.Drawing.Point(0, 66);
            this.seccion.Name = "seccion";
            this.seccion.Padding = new System.Windows.Forms.Padding(15);
            this.seccion.Size = new System.Drawing.Size(647, 268);
            this.seccion.TabIndex = 4;
            // 
            // tituloSeccion
            // 
            this.tituloSeccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(108)))), ((int)(((byte)(231)))));
            this.tituloSeccion.Location = new System.Drawing.Point(0, 0);
            this.tituloSeccion.Name = "tituloSeccion";
            this.tituloSeccion.Padding = new System.Windows.Forms.Padding(15, 15, 15, 25);
            this.tituloSeccion.Size = new System.Drawing.Size(647, 66);
            this.tituloSeccion.TabIndex = 3;
            // 
            // reproducerContainer
            // 
            this.reproducerContainer.Controls.Add(this.axWindowsMediaPlayer1);
            this.reproducerContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.reproducerContainer.Location = new System.Drawing.Point(0, 0);
            this.reproducerContainer.Name = "reproducerContainer";
            this.reproducerContainer.Size = new System.Drawing.Size(647, 127);
            this.reproducerContainer.TabIndex = 0;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(647, 127);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // npgsqlCommand1
            // 
            this.npgsqlCommand1.AllResultTypesAreUnknown = false;
            this.npgsqlCommand1.Transaction = null;
            this.npgsqlCommand1.UnknownResultTypeList = null;
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // MusicApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sideBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MusicApp";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicApp";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.MusicApp_Load);
            this.sideBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.reproducerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel sideBar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_playlist;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button agregarPlaylist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel reproducerContainer;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button botonCanciones;
        private System.Windows.Forms.FlowLayoutPanel tituloSeccion;
        private Npgsql.NpgsqlCommand npgsqlCommand1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.FlowLayoutPanel seccionPlaylist;
        private System.Windows.Forms.ToolTip mensajeAgregarPlaylist;
        private System.Windows.Forms.FlowLayoutPanel seccion;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.CheckBox filtro;
        private System.Windows.Forms.Label label1;
    }
}

