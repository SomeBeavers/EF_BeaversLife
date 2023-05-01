namespace MSSQL_CodeFirst_School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPetsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PetID);
            
            CreateTable(
                "dbo.PersonPets",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Pet_PetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Pet_PetID })
                .ForeignKey("dbo.Person", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.Pet_PetID, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Pet_PetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonPets", "Pet_PetID", "dbo.Pets");
            DropForeignKey("dbo.PersonPets", "Person_PersonID", "dbo.Person");
            DropIndex("dbo.PersonPets", new[] { "Pet_PetID" });
            DropIndex("dbo.PersonPets", new[] { "Person_PersonID" });
            DropTable("dbo.PersonPets");
            DropTable("dbo.Pets");
        }
    }
}
