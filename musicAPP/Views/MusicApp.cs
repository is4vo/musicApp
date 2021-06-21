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

        
        /// <summary>
        /// Evento que se activa cuando el boton "canciones" es clickeado.
        /// Se encarga de llenar con información de las canciones los paneles "tituloSeccion" y "seccion" de la interfaz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCanciones_Click(object sender, EventArgs e)
        {
            iniciarlizarPanelesCanciones();
        }

        /// <summary>
        /// Limpia los paneles iniciales de la interfaz y los completa con la información a mostrar de todas las canciones guardadas.
        /// </summary>
        private void iniciarlizarPanelesCanciones()
        {
            tituloSeccion.Controls.Clear();
            crearCuadroSeccionCanciones();
            seccion.Controls.Clear();
            /* En el panel "seccion" se crea un panel con información por cada canción*/
            foreach (var cancion in CancionController.GetList())
            {
                seccion.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion, true));
            }
        }

        /// <summary>
        /// Evento que se realiza al iniciar la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicApp_Load(object sender, EventArgs e)
        {
            /* Se pone la imagen del logo en el espacio asignado. */
            Logo.Image = Image.FromFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\musicApp\\Images\\logo.png");
            iniciarlizarPanelesPlaylist();
        }

        /// <summary>
        /// Se genera el panel que contiene la información de la cancion como tambien botones para eliminar y reproducir.
        /// Este panel se divide en dos sub paneles, uno que contiene la información y otro que contiene los botones.
        /// </summary>
        /// <param name="titulo"> El titulo de la canción </param>
        /// <param name="artista"> El artista que compone la canción </param>
        /// <param name="duracion"> La duración en segundos de la canción </param>
        /// <param name="album"> El album al cual pertenece la canción </param>
        /// <param name="ubicacion"> La path en la cual se encuentra la canción dentro del computador </param>
        /// <param name="botonesActivos"> Indicador de si los botonos deben aparecer o no (en caso de listar canciones de playlista se esconden) </param>
        /// <returns> El panel con todos los componentes e información necesaria </returns>
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

        /// <summary>
        /// Crear un sub panel que se agrega dentro del panel general que es creado por cada canción.
        /// Este panel solo contiene la información de la canción.
        /// </summary>
        /// <param name="titulo"> El titulo de la canción </param>
        /// <param name="artista"> El artista que compone la canción </param>
        /// <param name="duracion"> La duración en segundos de la canción </param>
        /// <param name="album"> El album al cual pertenece la canción </param>
        /// <returns> El panel con todos los componentes e información necesaria </returns>
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

        /// <summary>
        /// Crear un sub panel que se agrega dentro del panel general que es creado por cada canción.
        /// Este panel solo contiene los botones eliminar y reproducir que van dentro del panel de cada canción.
        /// </summary>
        /// <param name="ubicacion"> La path en la cual se encuentra la canción dentro del computador </param>
        /// <returns> El panel con todos los componentes e información necesaria </returns>
        private FlowLayoutPanel crearCuadroBotones(string ubicacion)
        {
            FlowLayoutPanel p3 = new FlowLayoutPanel();
            Button b = crearBotonReproducir(7, 105, 30);
            Button b2 = crearBotonEliminar(7, 105, 30);
            /*Al clickear este boton se procede a eliminar la canción.*/
            b2.Click += (object se, EventArgs ee) =>
            {
                eliminarCancion(ubicacion);
            };
            /*Al clickear este boton se procede a reproducir la canción.*/
            b.Click += (object se, EventArgs ee) =>
            {
                reproducirCancion(ubicacion);
            };
            p3.Size = new Size(130, 70);
            p3.Controls.Add(b);
            p3.Controls.Add(b2);
            return p3;
        }

        /// <summary>
        /// Crea un panel que contiene un texto y un boton, 
        /// el texto indica cuantas canciones guardadas hay en total y 
        /// el boton se utiliza para añadir mas canciones.
        /// Este panel se agrega dentro del panel "sección" de la interfaz.
        /// </summary>
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
            /*Al clickear este boton se procede a añadir una nueva canción.*/
            b.Click += (object se, EventArgs ee) =>
            {
                agregarCancion();
            };
            p5.Controls.Add(b);
            tituloSeccion.Controls.Add(p4);
            tituloSeccion.Controls.Add(p5);
        }

        /// <summary>
        /// Se utiliza para guardar una nueva canción.
        /// Abre el seleccionador de archivos y permite elegir un archivo,
        /// luego el archivo se guarda y se actualizan los paneles de la interfaz 
        /// que muestran info de las canciones.
        /// </summary>
        public void agregarCancion()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Audio|*.wav;*.mp3;*.alac;*.ALAC;*.WAV;*.AAC;*.MP3;"; // Valida tipo de archivo
            ofd.ShowDialog();
            CancionController.SaveFile(ofd.FileName);
            iniciarlizarPanelesCanciones();
        }

        /// <summary>
        /// Se utiliza para borrar una canción.
        /// Borra la canción mediante su identificador (path) 
        /// y actualiza lo necesario para refrescar el cambio en la interfaz.
        /// </summary>
        /// <param name="ubicacion"> La path en la cual se encuentra la canción dentro del computador </param>
        public void eliminarCancion(string ubicacion)
        {
            CancionController.removeFile(ubicacion);
            iniciarlizarPanelesCanciones();

            /* Se revisa si alguna playlist quedo vacia luego de borrar dicha canción*/
            List<string> listasParaBorrar = new List<string>();
            foreach (var playlistName in PlayListController.getAllPlayList())
            {
                if (PlayListController.getPlayList(playlistName).Count < 1)
                    listasParaBorrar.Add(playlistName);
            }

            /* Si alguna playlist quedo vacia se borra */
            foreach (var listaName in listasParaBorrar)
            {
                PlayListController.removePlayList(listaName);
            }
            iniciarlizarPanelesPlaylist();
            eliminarCancionDeWindowsMediaPlayer(ubicacion);
        }

        /// <summary>
        /// Manda a reproducir una canción al windows media player.
        /// La reproduce creando una lista con un archivo media y
        /// mandando a reproducir dicha lista, el archivo se crea 
        /// mediante la path de la canción.
        /// </summary>
        /// <param name="ubicacion"> La path en la cual se encuentra la canción dentro del computador </param>
        public void reproducirCancion(string ubicacion)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("cancion");
            WMPLib.IWMPMedia media;
            media = axWindowsMediaPlayer1.newMedia(ubicacion);
            playlist.appendItem(media);
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        /// <summary>
        /// Evento que se activa cuando se presiona el boton "+" que se encuentra al lado de playlist.
        /// Se utiliza para añadir una nueva playlist y se actualiza lo necesario para que el cambio
        /// se refleje en la interfaz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarPlaylist_Click(object sender, EventArgs e)
        {
            /* Se abre el form "AgregarPlaylist" que funciona como modal para que el usuario complete los datos de la playlist a agregar */
            AgregarPlaylist f = new AgregarPlaylist();
            f.ShowDialog();
            iniciarlizarPanelesPlaylist();
        }

        /// <summary>
        /// Limpia el panel "seccionPlaylist" y lo completa con información de las playlist guardadas.
        /// </summary>
        private void iniciarlizarPanelesPlaylist()
        {
            seccionPlaylist.Controls.Clear();
            /* Por cada playlist se genera un boton con su nombre */
            foreach (var playlist in PlayListController.getAllPlayList())
            {
                seccionPlaylist.Controls.Add(crearPanelPlaylist(playlist));
            }
        }

        /// <summary>
        /// Se crear un boton que lleva el nombre de una playlist.
        /// Se utiliza para ser agregado dentro del panel "seccionPlaylist" de la interfaz.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
        /// <returns> Un boton con el nombre de la playlist </returns>
        private Button crearPanelPlaylist(string nombre)
        {
            Button playlist = new Button();
            playlist.Size = new Size(195, 40);
            playlist.Text = "Playlist: " + nombre;
            playlist.BackColor = Color.Black;
            playlist.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            playlist.ForeColor = Color.White;
            playlist.TextAlign = ContentAlignment.MiddleLeft;
            /* Al clickear este boton se muestra toda la información de la playlist en los paneles "tituloSeccion" y "seccion" de la interfaz */
            playlist.Click += (object se, EventArgs ee) =>
            {
                mostrarPlaylist(nombre);
            };
            return playlist;
        }

        /// <summary>
        /// Se encarga de llenar con información de una playlist los paneles "tituloSeccion" y "seccion" de la interfaz.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
        private void mostrarPlaylist(string nombre)
        {
            tituloSeccion.Controls.Clear();
            crearCuadroSeccionPlaylist(nombre);
            seccion.Controls.Clear();
            /* Lista las canciones de la playlist */
            foreach (var playlist in PlayListController.getPlayList(nombre))
            {
                foreach (var cancion in CancionController.GetList())
                {
                    if(cancion.Ubicacion.Equals(playlist))
                        seccion.Controls.Add(crearCuadroCancion(cancion.Titulo, cancion.Artistas, cancion.Duracion, cancion.Album, cancion.Ubicacion, false));
                }
            }
        }

        /// <summary>
        /// Crea un boton que dice reproducir y tiene un icono acorde a la descripción.
        /// </summary>
        /// <param name="tamanoLetra"> El tamaño de letra que tendra el boton </param>
        /// <param name="ancho"> El ancho del boton </param>
        /// <param name="alto"> El alto del boton </param>
        /// <returns> El boton con creado con las medidas solicitadas </returns>
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

        /// <summary>
        /// Crea un boton que dice eliminar y tiene un icono acorde a la descripción.
        /// </summary>
        /// <param name="tamanoLetra"> El tamaño de letra que tendra el boton </param>
        /// <param name="ancho"> El ancho del boton </param>
        /// <param name="alto"> El alto del boton </param>
        /// <returns> El boton con creado con las medidas solicitadas </returns>
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

        /// <summary>
        /// Crea un boton que dice agregar.
        /// </summary>
        /// <param name="tamanoLetra"> El tamaño de letra que tendra el boton </param>
        /// <param name="ancho"> El ancho del boton </param>
        /// <param name="alto"> El alto del boton </param>
        /// <returns> El boton con creado con las medidas solicitadas </returns>
        private Button crearBotonAgregar(int tamanoLetra, int ancho, int alto)
        {
            Button agregar = new Button();
            agregar.Text = "Agregar";
            agregar.Font = new Font("Microsoft Sans Serif", tamanoLetra, FontStyle.Bold);
            agregar.Size = new Size(ancho, alto);
            agregar.ImageAlign = ContentAlignment.MiddleRight;
            agregar.TextAlign = ContentAlignment.MiddleLeft;
            agregar.BackColor = Color.White;
            return agregar;
        }

        /// <summary>
        /// Crea un panel que se compone por información de la playlist mas botonos para eliminar o reproducir dicha playlist.
        /// La información a mostrar de la playlist es el nombre, numero de canciones y tiempo de duración total.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
        private void crearCuadroSeccionPlaylist(string nombre)
        {
            FlowLayoutPanel panelTitulos = new FlowLayoutPanel();
            FlowLayoutPanel panel1 = new FlowLayoutPanel();
            FlowLayoutPanel panel2 = new FlowLayoutPanel();
            FlowLayoutPanel panel3 = new FlowLayoutPanel();
            FlowLayoutPanel panel4 = new FlowLayoutPanel();
            FlowLayoutPanel panel5 = new FlowLayoutPanel();
            panelTitulos.Size = new Size(290, 52);
            panel1.Size = new Size(290, 26);
            panel2.Size = new Size(290, 26);
            panel3.Size = new Size(110, 52);
            panel4.Size = new Size(100, 52);
            panel5.Size = new Size(75, 52);
            Label titulo1 = new Label();
            Label titulo2 = new Label();
            titulo1.Text = nombre;
            titulo1.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Bold);
            titulo1.Size = new Size(290, 26);
            int cantidadCanciones = PlayListController.getPlayList(nombre).Count;
            TimeSpan t = TimeSpan.FromSeconds(getTiempoTotalPlaylist(nombre));
            titulo2.Text = "Contiene " + cantidadCanciones + " cancion(es) y dura " + t.ToString(@"mm") + " min. " + t.ToString(@"ss") + " s.";
            titulo2.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            titulo2.Size = new Size(290, 26);
            panel1.Controls.Add(titulo1);
            panel2.Controls.Add(titulo2);
            panelTitulos.Controls.Add(panel1);
            panelTitulos.Controls.Add(panel2);
            Button botonReproducirPlaylist = crearBotonReproducir(9, 105, 40);
            Button botonEliminarPlaylist = crearBotonEliminar(9, 95, 40);
            Button botonAgregarPlayList = crearBotonAgregar(9, 70, 40);
            /* Al clickear este boton se reproduce la playlist */
            botonReproducirPlaylist.Click += (object se, EventArgs ee) =>
            {
                reproducirPlaylist(nombre);
            };
            /* Al clickear este boton se elimina la playlist */
            botonEliminarPlaylist.Click += (object se, EventArgs ee) =>
            {
                eliminarPlaylist(nombre);
            };
            botonAgregarPlayList.Click += (object se, EventArgs ee) =>
            {
                AgregarPlaylist f = new AgregarPlaylist(nombre);
                f.ShowDialog();
                iniciarlizarPanelesPlaylist();
                mostrarPlaylist(nombre);
            };
            panel3.Controls.Add(botonReproducirPlaylist);
            panel4.Controls.Add(botonEliminarPlaylist);
            panel5.Controls.Add(botonAgregarPlayList);
            tituloSeccion.Controls.Add(panelTitulos);
            tituloSeccion.Controls.Add(panel3);
            tituloSeccion.Controls.Add(panel4);
            tituloSeccion.Controls.Add(panel5);
        }

        /// <summary>
        /// Se encarga de reproducir una playlist, para ello
        /// se recorre la lista de canciones y se genera una 
        /// lista de media para mandar a reproducir dentro del window media player.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
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

        /// <summary>
        /// Se encarga de eliminar una playlist, se
        /// elimina la playlist mediante su identificador (nombre) y 
        /// se actualiza la interfaz para ver el cambio.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
        private void eliminarPlaylist(string nombre)
        {
            PlayListController.removePlayList(nombre);
            iniciarlizarPanelesPlaylist();
            tituloSeccion.Controls.Clear();
            seccion.Controls.Clear();
            eliminarPlaylistDeWindowsMediaPlayer(nombre);
        }

        /// <summary>
        /// Se encarga de obtener el tiempo total que tardara una 
        /// playlist en reproducirse en base a la suma de los tiempos
        /// de las canciones que contiene.
        /// </summary>
        /// <param name="nombre"> El nombre de la playlist </param>
        /// <returns> Un double que indica el tiempo total en segundos </returns>
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

        /// <summary>
        /// Se utiliza para detener la cancion sonando en el windows media player si es que esta canción fue eliminada.
        /// Se toma la playlist que esta sonando actualmente y se elimina el media/archivo de la playlist si este 
        /// coincide con la canción eliminada (se compara con la path).
        /// </summary>
        /// <param name="ubicacion"> La path en la cual se encuentra la canción dentro del computador </param>
        private void eliminarCancionDeWindowsMediaPlayer(string ubicacion)
        {
            WMPLib.IWMPPlaylist pl = axWindowsMediaPlayer1.currentPlaylist;
            for (int i = 0; i < pl.count; i++)
            {
                if (pl.get_Item(i).sourceURL.Equals(ubicacion))
                    pl.removeItem(pl.get_Item(i));
            }
        }

        /// <summary>
        /// Se utiliza para detener la playlist sonando en el windows media player si que esta playlist fue eliminada.
        /// Se toma la playlist que esta sonando actualmente y se compara con el nombre de la playlist eliminada, si 
        /// coindice entonces se cambia la playlist por otra vacia para detener la reproducción.
        /// </summary>
        private void eliminarPlaylistDeWindowsMediaPlayer(string nombre)
        {
            if (axWindowsMediaPlayer1.currentPlaylist.name.Equals(nombre)){
                WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("cancion");
                WMPLib.IWMPMedia media;
                media = axWindowsMediaPlayer1.newMedia(null);
                playlist.appendItem(media);
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }   
}
