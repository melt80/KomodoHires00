namespace KomodoHires.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamsandContracts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        ContractID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        DeveloperID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ContractID)
                .ForeignKey("dbo.Developer", t => t.DeveloperID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.DeveloperID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contract", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Contract", "DeveloperID", "dbo.Developer");
            DropIndex("dbo.Contract", new[] { "TeamID" });
            DropIndex("dbo.Contract", new[] { "DeveloperID" });
            DropTable("dbo.Team");
            DropTable("dbo.Contract");
        }
    }
}
