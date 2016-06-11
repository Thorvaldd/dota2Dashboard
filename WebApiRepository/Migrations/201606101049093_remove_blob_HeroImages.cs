namespace WebApiRepository.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class remove_blob_HeroImages : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HeroesImages", new[] { "HeroId" });
            RenameColumn(table: "dbo.HeroesImages", name: "SmaillImageCloudinaryUrl", newName: "cloudinmaryUrl");
            CreateIndex("dbo.HeroesImages", "heroid");
            DropColumn("dbo.HeroesImages", "Blob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HeroesImages", "Blob", c => c.Binary());
            DropIndex("dbo.HeroesImages", new[] { "heroid" });
            RenameColumn(table: "dbo.HeroesImages", name: "cloudinmaryUrl", newName: "SmaillImageCloudinaryUrl");
            CreateIndex("dbo.HeroesImages", "HeroId");
        }
    }
}
