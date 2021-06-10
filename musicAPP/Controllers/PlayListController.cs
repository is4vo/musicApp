using musicAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicAPP.Controllers
{
    class PlayListController
    {

        public void AddPlayList(String name)
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
        
        public void AddSong(OpenFileDialog fileList, String name)
        {
            /* Obtiene PlayList */
            ModelContext db = new ModelContext();
            if (db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId) == null)
            {
                AddPlayList(name); // Crea la PlayList
            }
            int PlayListId = db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId).FirstOrDefault();

            /* Buscar si existe cancion en DB, sino agregar cancion a DB */
            foreach(String song in fileList.FileNames)
            {
                if (db.Canciones.Where(s => s.Ubicacion == song).Select(s => s.CancionId) == null)
                {
                    CancionController.SaveFile(song); // Crea la cancion
                }
                int CancionId = db.Canciones.Where(s => s.Ubicacion == song).Select(s => s.CancionId).FirstOrDefault();

                /* Agregando Canciones a PlayList */
                if (db.CancionPlaylists.Where(d => d.CancionId == CancionId).Where(d => d.PlayListId == PlayListId) == null)
                {
                    CancionPlaylist model = new CancionPlaylist();
                    model.CancionId = CancionId;
                    model.PlayListId = PlayListId;
                    db.CancionPlaylists.Add(model);
                    db.SaveChanges();
                }
            }
        }

        public List<String> getPlayList(String name)
        {
            ModelContext db = new ModelContext();
            List<String> PlayList = new List<string>();
            /* Se obtiene el valor de la PlayList */
            int PlayListId = db.PlayLists.Where(p => p.Nombre == name).Select(p => p.PlayListId).FirstOrDefault();
            foreach(int CancionId in db.CancionPlaylists.Where(p => p.PlayListId == PlayListId).Select(c => c.CancionId).ToList<int>())
            {
                /* Se agregan las canciones a la cola de canciones */
                PlayList.Add(db.Canciones.Where(c => c.CancionId == CancionId).Select(path => path.Ubicacion).FirstOrDefault());
            }

            return PlayList;
        }

        public List<String> getAllPlayList()
        {
            ModelContext db = new ModelContext();
            return db.PlayLists.Select(p => p.Nombre).ToList();
        }
    }
}
