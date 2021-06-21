using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using musicAPP.Controllers;

namespace musicAPP
{
    public partial class AgregarPlaylist : Form
    {
        private bool SubirCancionesClickeado = false;
        public AgregarPlaylist()
        {
            InitializeComponent();
        }

        private void SubirCancionesPlaylist_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Archivos de Audio|*.wav;*.mp3;*.alac;*.ALAC;*.WAV;*.AAC;*.MP3;"; // Valida tipo de archivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cantidadArchivos.Text = openFileDialog1.FileNames.Length + " archivo(s)";
            }
            SubirCancionesClickeado = true;
        }

        private void CrearPlaylist_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputNombrePlaylist.Text) && SubirCancionesClickeado && openFileDialog1.FileNames.Length > 0 && !openFileDialog1.FileName.Equals("openFileDialog1"))
            {
                PlayListController.AddPlayList(inputNombrePlaylist.Text);
                PlayListController.AddSong(openFileDialog1, inputNombrePlaylist.Text);
                this.Close();
            }
        }
    }
}
