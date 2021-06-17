using System.Data.Entity;

namespace musicAPP.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=local") { }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<CancionPlaylist> CancionPlaylists { get; set; }
    }
}
