namespace WebApiRepository.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class rename_column_HeroesImages_CloudinaryUrl : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HeroesImages", name: "cloudinmaryUrl", newName: "cloudinaryUrl");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.HeroesImages", name: "cloudinaryUrl", newName: "cloudinmaryUrl");
        }
    }
}
