namespace WebApiRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable_GameItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Int(nullable: false),
                        LocalizedName = c.String(maxLength: 300),
                        DotaBuffItemName = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameItems");
        }
    }
}
