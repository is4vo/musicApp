namespace musicAPP.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ModificaModeloCancion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cancions",
                c => new
                {
                    CancionId = c.Int(nullable: false, identity: true),
                    Titulo = c.String(),
                    Album = c.String(),
                    Artistas = c.String(),
                    Generos = c.String(),
                    Compositores = c.String(),
                    Duracion = c.Double(nullable: false),
                    Ubicacion = c.String(),
                })
                .PrimaryKey(t => t.CancionId);

            CreateTable(
                "dbo.CancionPlaylists",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CancionId = c.Int(nullable: false),
                    PlayListId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PlayLists",
                c => new
                {
                    PlayListId = c.Int(nullable: false, identity: true),
                    Nombre = c.String(),
                })
                .PrimaryKey(t => t.PlayListId);

        }

        public override void Down()
        {
            DropTable("dbo.PlayLists");
            DropTable("dbo.CancionPlaylists");
            DropTable("dbo.Cancions");
        }
    }
}
