using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicAPP.Models
{
    public class PlayList
    {
        [Key]
        public int PlayListId { get; set; }
        [Index(IsUnique = true)]
        public String Nombre { get; set; }
    }
}
