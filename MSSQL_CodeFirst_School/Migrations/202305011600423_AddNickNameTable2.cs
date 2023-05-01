namespace MSSQL_CodeFirst_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNickNameTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NickNames", "NickNameID", "dbo.Pets");
            DropIndex("dbo.NickNames", new[] { "NickNameID" });
            DropTable("dbo.NickNames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NickNames",
                c => new
                    {
                        NickNameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NickNameID);
            
            CreateIndex("dbo.NickNames", "NickNameID");
            AddForeignKey("dbo.NickNames", "NickNameID", "dbo.Pets", "PetID");
        }
    }
}
