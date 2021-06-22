using musicAPP.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace musicAPP
{
    /// <summary>
    /// Formulario que funciona como modal para que el usuario complete los datos necesario 
    /// para agregar una nueva playlist, los cuales son: nombre y archivos de canciones.
    /// </summary>
    public partial class AgregarPlaylist : Form
    {
        private bool SubirCancionesClickeado = false;
        private String name;
        public AgregarPlaylist()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se activa cuando se clickea el boton "subir canciones" de la interfaz.
        /// Abre un seleccionador de archivos y permite seleccionar uno o mas archivos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento que se activa cuando se clickea el boton "aceptar" de la interfaz.
        /// Procede a añadir la nueva playlist, con el nombre asignado en el input y 
        /// los archivos seleccionados en el openFileDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrearPlaylist_Click(object sender, EventArgs e)
        {
            /* Antes de añadir la playlist se verifica que el nombre no venga vacio o lleno de espacios y que al menos se haya seleccionado un archivo */
            if (!string.IsNullOrWhiteSpace(inputNombrePlaylist.Text) && SubirCancionesClickeado && openFileDialog1.FileNames.Length > 0 && !openFileDialog1.FileName.Equals("openFileDialog1"))
            {
                PlayListController.AddPlayList(inputNombrePlaylist.Text);
                PlayListController.AddSong(openFileDialog1, inputNombrePlaylist.Text);
                this.Close();
            }
        }

        private void AgregarPlaylist_Load(object sender, EventArgs e)
        {
            
            Image delete = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\addSong.png");
            SubirCancionesPlaylist.Image = (Image)(new Bitmap(delete, new Size(25, 25)));
            SubirCancionesPlaylist.ImageAlign = ContentAlignment.MiddleRight;
            SubirCancionesPlaylist.TextAlign = ContentAlignment.MiddleLeft;
        }
    }
}
