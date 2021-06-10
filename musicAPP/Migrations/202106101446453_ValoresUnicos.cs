namespace musicAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValoresUnicos : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cancions", "Ubicacion", unique: true);
            CreateIndex("dbo.PlayLists", "Nombre", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PlayLists", new[] { "Nombre" });
            DropIndex("dbo.Cancions", new[] { "Ubicacion" });
        }
    }
}
