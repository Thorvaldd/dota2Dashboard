namespace WebApiRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewField_IsRecipe_In_GameItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameItems", "IsRecipe", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameItems", "IsRecipe");
        }
    }
}
