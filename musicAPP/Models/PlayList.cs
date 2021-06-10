using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
