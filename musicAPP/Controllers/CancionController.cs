﻿using musicAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicAPP.Controllers
{
    public class CancionController
    {

        public static void SaveFile(string path)
        {
            Cancion model = new Cancion();

            try
            {
                TagLib.File tlf = TagLib.File.Create(path);
                model.Titulo = tlf.Tag.Title;
                model.Album = tlf.Tag.Album;
                model.Artistas = String.Join(", ",tlf.Tag.Performers);
                model.Generos = String.Join(", ",tlf.Tag.Genres);
                model.Compositores = String.Join(", ",tlf.Tag.Composers);
                model.Duracion = tlf.Properties.Duration.TotalSeconds;
                model.Ubicacion = path;
                using(ModelContext db = new ModelContext())
                {
                    db.Canciones.Add(model);
                    db.SaveChanges();
                }
            } catch (FileNotFoundException) { }
        }

        public static List<Cancion> GetList()
        {
            ModelContext db = new ModelContext();
            return db.Canciones.ToList();
        }
    }
}
