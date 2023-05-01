namespace MSSQL_CodeFirst_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNickNameTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NickNames",
                c => new
                    {
                        NickNameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NickNameID)
                .ForeignKey("dbo.Pets", t => t.NickNameID)
                .Index(t => t.NickNameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NickNames", "NickNameID", "dbo.Pets");
            DropIndex("dbo.NickNames", new[] { "NickNameID" });
            DropTable("dbo.NickNames");
        }
    }
}
