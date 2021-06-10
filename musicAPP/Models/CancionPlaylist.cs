using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
