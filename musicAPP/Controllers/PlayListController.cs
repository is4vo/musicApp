using musicAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace musicAPP.Controllers
{
    /// <summary>
    /// Permite conectar la vista con el modelo de PlayList
    /// </summary>
    class PlayListController
    {

        /// <summary>
        /// Permite agregar una nueva PlayList a la BD
        /// </summary>
        /// <param name="name"> Nombre UNICO de la PLayList </param>
        public static void AddPlayList(String name)
        {
            PlayList model = new PlayList();
            try
            {
                model.Nombre = name;
                using (ModelContext db = new ModelContext())
                {
                    db.PlayLists.Add(model);
                    db.SaveChanges();
                }
            }
            catch (Exception) { }

        }

        /// <summary>
        /// Permite agregar canciones existentes a una PlayList existente y crea las entidades no existentes en la BD
        /// </summary>
        /// <param name="fileList"> Componente que contiene lista de path de archivos seleccionados </param>
        /// <param name="name"> Nombre de la PlayList </param>
        public static void AddSong(OpenFileDialog fileList, String name)
        {
            /* Obtiene PlayList */
            ModelContext db = new ModelContext();
            if (db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId).FirstOrDefault() == 0)
            {
                AddPlayList(name); // Crea la PlayList
            }
            int PlayListId = db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId).FirstOrDefault();

            /* Buscar si existe cancion en DB, sino agregar cancion a DB */
            foreach (String song in fileList.FileNames)
            {
                if (db.Canciones.Where(s => s.Ubicacion == song).Select(s => s.CancionId).FirstOrDefault() == 0)
                {
                    CancionController.SaveFile(song); // Crea la cancion
                }
                int CancionId = db.Canciones.Where(s => s.Ubicacion == song).Select(s => s.CancionId).FirstOrDefault();

                /* Agregando Canciones a PlayList */
                if (db.CancionPlaylists.Where(d => d.CancionId == CancionId).Where(d => d.PlayListId == PlayListId).FirstOrDefault() == null)
                {
                    CancionPlaylist model = new CancionPlaylist();
                    model.CancionId = CancionId;
                    model.PlayListId = PlayListId;
                    db.CancionPlaylists.Add(model);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Permite obtener el listado de canciones asociado a una PlayList
        /// </summary>
        /// <param name="name"> Nombre de la PlayList existente </param>
        /// <returns>Lista de Canciones</returns>
        public static List<String> getPlayList(String name)
        {
            ModelContext db = new ModelContext();
            List<String> PlayList = new List<string>();
            /* Se obtiene el valor de la PlayList */
            int PlayListId = db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId).FirstOrDefault();
            foreach (int CancionId in db.CancionPlaylists.Where(p => p.PlayListId == PlayListId).Select(c => c.CancionId).ToList<int>())
            {
                /* Se agregan las canciones a la cola de canciones */
                string ubicacion = db.Canciones.Where(c => c.CancionId == CancionId).Select(path => path.Ubicacion).FirstOrDefault();
                if(!string.IsNullOrEmpty(ubicacion))
                    PlayList.Add(ubicacion);
            }
            return PlayList;
        }

        /// <summary>
        /// Permite obtener el listado de PlayList existentes.
        /// </summary>
        /// <returns>Lista de PlayLists</returns>
        public static List<String> getAllPlayList()
        {
            ModelContext db = new ModelContext();
            try
            {
                return db.PlayLists.Select(p => p.Nombre).ToList();
            } catch (Exception)
            {
                return new List<string>();
            }
            
        }

        /// <summary>
        /// Permite eliminar una PlayList desde la base de datos
        /// </summary>
        /// <param name="name"> Nombre de la PlayList que será eliminada </param>
        /// <returns>true: se eliminó; false: error</returns>
        public static bool removePlayList(string name)
        {
            using (ModelContext db = new ModelContext())
            {
                var itemRemoved = db.PlayLists.SingleOrDefault(p => p.Nombre == name);

                if (itemRemoved != null)
                {
                    db.PlayLists.Remove(itemRemoved);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
