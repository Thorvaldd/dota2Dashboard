namespace WebApiRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HeroesImages", new[] { "heroid" });
            CreateIndex("dbo.HeroesImages", "HeroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HeroesImages", new[] { "HeroId" });
            CreateIndex("dbo.HeroesImages", "heroid");
        }
    }
}
