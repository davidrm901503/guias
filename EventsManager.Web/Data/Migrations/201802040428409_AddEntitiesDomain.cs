namespace EventsManager.Web.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntitiesDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "EventCategoryNameIndex");
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Coordinate = c.String(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false),
                        DepatureTime = c.Time(nullable: false, precision: 7),
                        Description = c.String(nullable: false),
                        Conditions = c.String(nullable: false),
                        EventType = c.Byte(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TicketCapacity = c.Int(nullable: false),
                        EventStatus = c.Byte(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IsOrganizer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Text = c.String(nullable: false),
                        EventId = c.Int(nullable: false),
                        CommentDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.EventEventCategories",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        EventCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.EventCategory_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.EventCategories", t => t.EventCategory_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.EventCategory_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PhotoUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInformation", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "WebPage", c => c.String());
            AddColumn("dbo.AspNetUsers", "TwitterUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "FacebookUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "PinteresUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "InstagramUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "GooglePlusUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "YoutubeUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "FlickrUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "LinkedinUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventEventCategories", "EventCategory_Id", "dbo.EventCategories");
            DropForeignKey("dbo.EventEventCategories", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventEventCategories", new[] { "EventCategory_Id" });
            DropIndex("dbo.EventEventCategories", new[] { "Event_Id" });
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.EventCategories", "EventCategoryNameIndex");
            DropColumn("dbo.AspNetUsers", "LinkedinUrl");
            DropColumn("dbo.AspNetUsers", "FlickrUrl");
            DropColumn("dbo.AspNetUsers", "YoutubeUrl");
            DropColumn("dbo.AspNetUsers", "GooglePlusUrl");
            DropColumn("dbo.AspNetUsers", "InstagramUrl");
            DropColumn("dbo.AspNetUsers", "PinteresUrl");
            DropColumn("dbo.AspNetUsers", "FacebookUrl");
            DropColumn("dbo.AspNetUsers", "TwitterUrl");
            DropColumn("dbo.AspNetUsers", "WebPage");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "PersonalInformation");
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.AspNetUsers", "PhotoUrl");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.EventEventCategories");
            DropTable("dbo.Tickets");
            DropTable("dbo.Comments");
            DropTable("dbo.Events");
            DropTable("dbo.EventCategories");
        }
    }
}
