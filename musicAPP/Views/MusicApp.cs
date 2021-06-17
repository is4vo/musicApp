using musicAPP.Controllers;
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

namespace musicAPP
{
    public partial class MusicApp : Form
    {
        public MusicApp()
        {
            InitializeComponent();
        }

        /* Abrir buscador de archivos */
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            crearCuadroSecciónCanciones();
            flowLayoutPanel1.Controls.Clear();
            foreach (var cancion in CancionController.GetList())
            {
                flowLayoutPanel1.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion));
            }
        }

        private void MusicApp_Load(object sender, EventArgs e)
        {
                        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_albunes_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_add_pls_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* Agregar canciones a una Lista de reproduccion de Windows Media Player*/
        private void button5_Click(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("La Lista");
            WMPLib.IWMPMedia media;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    media = axWindowsMediaPlayer1.newMedia(file);
                    playlist.appendItem(media);
                }
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private FlowLayoutPanel crearCuadroCancion(string titulo, string artista, double duracion, string album, string ubicacion)
        {
            FlowLayoutPanel p = new FlowLayoutPanel();
            p.BackColor = Color.DarkGray;
            p.Size = new Size(580, 80);
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Controls.Add(crearCuadroInformacion(titulo,artista,duracion, album));
            p.Controls.Add(crearCuadroBotones(ubicacion));
            return p;
        }

        private FlowLayoutPanel crearCuadroInformacion(string titulo, string artista, double duracion, string album)
        {
            FlowLayoutPanel p2 = new FlowLayoutPanel();
            Label l = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();
            if (titulo == null || titulo.Equals(""))
            {
                l.Text = "Título: Sin título";
            }
            else
            {
                l.Text = "Título: " + titulo;
            }
            l.Size = new Size(350, 18);
            l.Font = new Font(l.Font, FontStyle.Bold);
            l2.Text = "Artista: " + artista;
            l2.Size = new Size(350, 18);
            TimeSpan t = TimeSpan.FromSeconds(duracion);
            l3.Text = "Duración: " + t.ToString(@"mm") + " min. " + t.ToString(@"ss") + " s.";
            l3.Size = new Size(350, 18);
            l4.Text = "Album: " + album;
            l4.Size = new Size(350, 18);
            p2.Size = new Size(420, 70);
            p2.Controls.Add(l);
            p2.Controls.Add(l2);
            p2.Controls.Add(l3);
            p2.Controls.Add(l4);
            return p2;
        }

        private FlowLayoutPanel crearCuadroBotones(string ubicacion)
        {
            FlowLayoutPanel p3 = new FlowLayoutPanel();
            Button b = new Button();
            Button b2 = new Button();
            b.Text = "Reproducir";
            b.Font = new Font(b.Font, FontStyle.Bold);
            b.BackColor = Color.White;
            Image play = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\play.png");
            b.Size = new Size(105, 30);
            b.Image = (Image)(new Bitmap(play, new Size(20, 20)));
            b.ImageAlign = ContentAlignment.MiddleRight;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b2.Text = "Eliminar";
            b2.Font = new Font(b2.Font, FontStyle.Bold);
            Image delete = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\delete.png");
            b2.Size = new Size(105, 30);
            b2.Image = (Image)(new Bitmap(delete, new Size(20, 20)));
            b2.ImageAlign = ContentAlignment.MiddleRight;
            b2.TextAlign = ContentAlignment.MiddleLeft;
            b2.BackColor = Color.White;
            b.Click += (object se, EventArgs ee) =>
            {
                WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("La Lista");
                WMPLib.IWMPMedia media;
                media = axWindowsMediaPlayer1.newMedia(ubicacion);
                playlist.appendItem(media);
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                axWindowsMediaPlayer1.Ctlcontrols.play();

            };
            p3.Size = new Size(130, 70);
            p3.Controls.Add(b);
            p3.Controls.Add(b2);
            return p3;
        }

        private void crearCuadroSecciónCanciones()
        {
            FlowLayoutPanel p4 = new FlowLayoutPanel();
            p4.Size = new Size(415, 42);
            Label l = new Label();
            l.Text = "Canciones";
            l.Padding = new Padding(5);
            l.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            l.Size = new Size(200, 40);
            p4.Controls.Add(l);
            FlowLayoutPanel p5 = new FlowLayoutPanel();
            p5.Size = new Size(159, 42);
            Button b = new Button();
            b.Text = "+";
            b.BackColor = Color.Transparent;
            b.BackgroundImageLayout = ImageLayout.None;
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            b.Size = new Size(156, 39);
            b.FlatAppearance.BorderSize = 0;
            b.Click += (object se, EventArgs ee) =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos de Audio|*.wav;*.mp3;*.alac;*.ALAC;*.WAV;*.AAC;*.MP3;"; // Valida tipo de archivo
                ofd.ShowDialog();
                CancionController.SaveFile(ofd.FileName);
                flowLayoutPanel1.Controls.Clear();
                foreach (var cancion in CancionController.GetList())
                {
                    flowLayoutPanel1.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion));
                }

            };
            p5.Controls.Add(b);
            flowLayoutPanel2.Controls.Add(p4);
            flowLayoutPanel2.Controls.Add(p5);
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }
    }
}
