namespace WebApiRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ValveHeroName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HeroesImages",
                c => new
                    {
                        HeroId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Blob = c.Binary(),
                        SmaillImageCloudinaryUrl = c.String(),
                    })
                .PrimaryKey(t => t.HeroId)
                .ForeignKey("dbo.Heroes", t => t.HeroId)
                .Index(t => t.HeroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeroesImages", "HeroId", "dbo.Heroes");
            DropIndex("dbo.HeroesImages", new[] { "HeroId" });
            DropTable("dbo.HeroesImages");
            DropTable("dbo.Heroes");
        }
    }
}
