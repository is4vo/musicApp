using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicAPP.Models
{
    public class Cancion
    {
        [Key]
        public int CancionId { get; set; }
        public String Titulo { get; set; }
        public String Album { get; set; }
        public String Artistas { get; set; }
        public String Generos { get; set; }
        public String Compositores { get; set; }
        public Double Duracion { get; set; }
        [Index(IsUnique = true)]
        public String Ubicacion { get; set; }

    }
}
