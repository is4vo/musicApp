using System.ComponentModel.DataAnnotations;

namespace musicAPP.Models
{
    public class CancionPlaylist
    {
        [Key]
        public int Id { get; set; }
        public int CancionId { get; set; }
        public int PlayListId { get; set; }
    }
}
