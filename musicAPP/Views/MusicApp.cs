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
        private void botonCanciones_Click(object sender, EventArgs e)
        {
            iniciarlizarPanelesCanciones();
        }

        private void iniciarlizarPanelesCanciones()
        {
            tituloSeccion.Controls.Clear();
            crearCuadroSeccionCanciones();
            seccion.Controls.Clear();
            foreach (var cancion in CancionController.GetList())
            {
                seccion.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion, true));
            }
        }

        private void MusicApp_Load(object sender, EventArgs e)
        {
            Logo.Image = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\logo.png");
            iniciarlizarPanelesPlaylist();
        }

        /* Agregar canciones a una Lista de reproduccion de Windows Media Player*/
        private void CrearLista(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("La Lista");
            WMPLib.IWMPMedia media;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Archivos de Audio|*.wav;*.mp3;*.alac;*.ALAC;*.WAV;*.AAC;*.MP3;"; // Valida tipo de archivo
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

        private FlowLayoutPanel crearCuadroCancion(string titulo, string artista, double duracion, string album, string ubicacion, Boolean botonesActivos)
        {
            FlowLayoutPanel p = new FlowLayoutPanel();
            p.BackColor = Color.DarkGray;
            p.Size = new Size(580, 80);
            p.BorderStyle = BorderStyle.Fixed3D;
            p.Controls.Add(crearCuadroInformacion(titulo, artista, duracion, album));
            if(botonesActivos)
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
            Button b = crearBotonReproducir(7, 105, 30);
            Button b2 = crearBotonEliminar(7, 105, 30);
            b2.Click += (object se, EventArgs ee) =>
            {
                eliminarCancion(ubicacion);
            };
            b.Click += (object se, EventArgs ee) =>
            {
                reproducirCancion(ubicacion);
            };
            p3.Size = new Size(130, 70);
            p3.Controls.Add(b);
            p3.Controls.Add(b2);
            return p3;
        }

        private void crearCuadroSeccionCanciones()
        {
            FlowLayoutPanel p4 = new FlowLayoutPanel();
            p4.Size = new Size(415, 42);
            Label l = new Label();
            int cantidadCanciones = CancionController.GetList().Count;
            l.Text = cantidadCanciones + " cancion(es) encontrada(s)";
            l.Padding = new Padding(10);
            l.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
            l.Size = new Size(300, 40);
            p4.Controls.Add(l);
            FlowLayoutPanel p5 = new FlowLayoutPanel();
            p5.Size = new Size(159, 42);
            Button b = new Button();
            ToolTip t = new ToolTip();
            b.Text = "+";
            b.BackColor = Color.Transparent;
            b.BackgroundImageLayout = ImageLayout.None;
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            b.Size = new Size(156, 39);
            b.FlatAppearance.BorderSize = 0;
            t.SetToolTip(b, "Agregar nueva canción");
            b.Click += (object se, EventArgs ee) =>
            {
                agregarCancion();
            };
            p5.Controls.Add(b);
            tituloSeccion.Controls.Add(p4);
            tituloSeccion.Controls.Add(p5);
        }

        public void agregarCancion()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Audio|*.wav;*.mp3;*.alac;*.ALAC;*.WAV;*.AAC;*.MP3;"; // Valida tipo de archivo
            ofd.ShowDialog();
            CancionController.SaveFile(ofd.FileName);
            iniciarlizarPanelesCanciones();
        }

        public void eliminarCancion(string ubicacion)
        {
            CancionController.removeFile(ubicacion);
            iniciarlizarPanelesCanciones();
            List<string> listasParaBorrar = new List<string>();
            foreach (var playlistName in PlayListController.getAllPlayList())
            {
                if (PlayListController.getPlayList(playlistName).Count < 1)
                    listasParaBorrar.Add(playlistName);
            }
            foreach (var listaName in listasParaBorrar)
            {
                PlayListController.removePlayList(listaName);
            }
            iniciarlizarPanelesPlaylist();
            eliminarCancionDeWindowsMediaPlayer(ubicacion);
        }

        public void reproducirCancion(string ubicacion)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("cancion");
            WMPLib.IWMPMedia media;
            media = axWindowsMediaPlayer1.newMedia(ubicacion);
            playlist.appendItem(media);
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void agregarPlaylist_Click(object sender, EventArgs e)
        {
            AgregarPlaylist f = new AgregarPlaylist();
            f.ShowDialog();
            iniciarlizarPanelesPlaylist();
        }

        private void iniciarlizarPanelesPlaylist()
        {
            seccionPlaylist.Controls.Clear();
            foreach (var playlist in PlayListController.getAllPlayList())
            {
                seccionPlaylist.Controls.Add(crearPanelPlaylist(playlist));
            }
        }

        private Button crearPanelPlaylist(string nombre)
        {
            Button playlist = new Button();
            playlist.Size = new Size(195, 40);
            playlist.Text = "Playlist: " + nombre;
            playlist.BackColor = Color.Black;
            playlist.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            playlist.ForeColor = Color.White;
            playlist.TextAlign = ContentAlignment.MiddleLeft;
            playlist.Click += (object se, EventArgs ee) =>
            {
                mostrarPlaylist(nombre);
            };
            return playlist;
        }

        private void mostrarPlaylist(string nombre)
        {
            tituloSeccion.Controls.Clear();
            crearCuadroSeccionPlaylist(nombre);
            seccion.Controls.Clear();
            foreach (var playlist in PlayListController.getPlayList(nombre))
            {
                foreach (var cancion in CancionController.GetList())
                {
                    if(cancion.Ubicacion.Equals(playlist))
                        seccion.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion, false));
                }
            }
        }

        private Button crearBotonReproducir(int tamanoLetra, int ancho, int alto)
        {
            Button reproducir = new Button();
            reproducir.Text = "Reproducir";
            reproducir.Font = new Font("Microsoft Sans Serif", tamanoLetra, FontStyle.Bold);
            reproducir.BackColor = Color.White;
            Image play = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\play.png");
            reproducir.Size = new Size(ancho, alto);
            reproducir.Image = (Image)(new Bitmap(play, new Size(20, 20)));
            reproducir.ImageAlign = ContentAlignment.MiddleRight;
            reproducir.TextAlign = ContentAlignment.MiddleLeft;
            return reproducir;
        }

        private Button crearBotonEliminar(int tamanoLetra, int ancho, int alto)
        {
            Button eliminar = new Button();
            eliminar.Text = "Eliminar";
            eliminar.Font = new Font("Microsoft Sans Serif", tamanoLetra, FontStyle.Bold);
            Image delete = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\delete.png");
            eliminar.Size = new Size(ancho, alto);
            eliminar.Image = (Image)(new Bitmap(delete, new Size(20, 20)));
            eliminar.ImageAlign = ContentAlignment.MiddleRight;
            eliminar.TextAlign = ContentAlignment.MiddleLeft;
            eliminar.BackColor = Color.White;
            return eliminar;
        }

        private void crearCuadroSeccionPlaylist(string nombre)
        {
            FlowLayoutPanel panelTitulos = new FlowLayoutPanel();
            FlowLayoutPanel panel1 = new FlowLayoutPanel();
            FlowLayoutPanel panel2 = new FlowLayoutPanel();
            FlowLayoutPanel panel3 = new FlowLayoutPanel();
            FlowLayoutPanel panel4 = new FlowLayoutPanel();
            panelTitulos.Size = new Size(320, 52);
            panel1.Size = new Size(300, 26);
            panel2.Size = new Size(300, 26);
            panel3.Size = new Size(125, 52);
            panel4.Size = new Size(125, 52);
            Label titulo1 = new Label();
            Label titulo2 = new Label();
            titulo1.Text = nombre;
            titulo1.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
            titulo1.Size = new Size(300, 26);
            int cantidadCanciones = PlayListController.getPlayList(nombre).Count;
            TimeSpan t = TimeSpan.FromSeconds(getTiempoTotalPlaylist(nombre));
            titulo2.Text = "Contiene " + cantidadCanciones + " cancion(es) y dura " + t.ToString(@"mm") + " min. " + t.ToString(@"ss") + " s.";
            titulo2.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            titulo2.Size = new Size(300, 26);
            panel1.Controls.Add(titulo1);
            panel2.Controls.Add(titulo2);
            panelTitulos.Controls.Add(panel1);
            panelTitulos.Controls.Add(panel2);
            Button botonReproducirPlaylist = crearBotonReproducir(9, 120, 40);
            Button botonEliminarPlaylist = crearBotonEliminar(9, 120, 40);
            botonReproducirPlaylist.Click += (object se, EventArgs ee) =>
            {
                reproducirPlaylist(nombre);
            };
            botonEliminarPlaylist.Click += (object se, EventArgs ee) =>
            {
                eliminarPlaylist(nombre);
            };
            panel3.Controls.Add(botonReproducirPlaylist);
            panel4.Controls.Add(botonEliminarPlaylist);
            tituloSeccion.Controls.Add(panelTitulos);
            tituloSeccion.Controls.Add(panel3);
            tituloSeccion.Controls.Add(panel4);
        }

        private void reproducirPlaylist(string nombre)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist(nombre);
            WMPLib.IWMPMedia media;
            foreach (var song in PlayListController.getPlayList(nombre))
            {
                media = axWindowsMediaPlayer1.newMedia(song);
                playlist.appendItem(media);
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void eliminarPlaylist(string nombre)
        {
            PlayListController.removePlayList(nombre);
            iniciarlizarPanelesPlaylist();
            tituloSeccion.Controls.Clear();
            seccion.Controls.Clear();
            eliminarPlaylistDeWindowsMediaPlayer(nombre);
        }

        private double getTiempoTotalPlaylist(string nombre)
        {
            double tiempoTotal = 0;
            foreach (var playlist in PlayListController.getPlayList(nombre))
            {
                foreach (var cancion in CancionController.GetList())
                {
                    if (cancion.Ubicacion.Equals(playlist))
                        tiempoTotal = tiempoTotal + cancion.Duracion;
                }
            }
            return tiempoTotal;
        }

        private void eliminarCancionDeWindowsMediaPlayer(string ubicacion)
        {
            WMPLib.IWMPPlaylist pl = axWindowsMediaPlayer1.currentPlaylist;
            for (int i = 0; i < pl.count; i++)
            {
                if (pl.get_Item(i).sourceURL.Equals(ubicacion))
                    pl.removeItem(pl.get_Item(i));
            }
        }

        private void eliminarPlaylistDeWindowsMediaPlayer(string nombre)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("cancion");
            WMPLib.IWMPMedia media;
            media = axWindowsMediaPlayer1.newMedia(null);
            playlist.appendItem(media);
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }   
}
