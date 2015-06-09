namespace SearchCastCrew.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRanges",
                c => new
                    {
                        AgeRangeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AgeRangeId);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AvailabilityId);
            
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        BodyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Ethnicities",
                c => new
                    {
                        EthnicityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EthnicityId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        Biography = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        IsUnion = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        HeightInInches = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        HairColorId = c.Int(),
                        EyeColorId = c.Int(),
                        AgeRangeId = c.Int(),
                        GenderId = c.Int(),
                        BodyTypeId = c.Int(),
                        EthnicityId = c.Int(),
                        AvailabilityId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeRanges", t => t.AgeRangeId)
                .ForeignKey("dbo.Availabilities", t => t.AvailabilityId)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId)
                .ForeignKey("dbo.Ethnicities", t => t.EthnicityId)
                .ForeignKey("dbo.EyeColors", t => t.EyeColorId)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.HairColors", t => t.HairColorId)
                .Index(t => t.HairColorId)
                .Index(t => t.EyeColorId)
                .Index(t => t.AgeRangeId)
                .Index(t => t.GenderId)
                .Index(t => t.BodyTypeId)
                .Index(t => t.EthnicityId)
                .Index(t => t.AvailabilityId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EyeColors",
                c => new
                    {
                        EyeColorId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.EyeColorId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.HairColors",
                c => new
                    {
                        HairColorId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.HairColorId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ImageDesc = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsProfile = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinkId = c.Int(nullable: false, identity: true),
                        LinkUrl = c.String(),
                        LinkType = c.String(),
                        LinkDesc = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LinkId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoId = c.Int(nullable: false, identity: true),
                        VideoUrl = c.String(),
                        VideoDesc = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VideoId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        UserCategoryId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCategories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Links", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Images", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "HairColorId", "dbo.HairColors");
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.AspNetUsers", "EyeColorId", "dbo.EyeColors");
            DropForeignKey("dbo.Experiences", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EthnicityId", "dbo.Ethnicities");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.AspNetUsers", "AvailabilityId", "dbo.Availabilities");
            DropForeignKey("dbo.AspNetUsers", "AgeRangeId", "dbo.AgeRanges");
            DropIndex("dbo.UserCategories", new[] { "CategoryId" });
            DropIndex("dbo.UserCategories", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Links", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AvailabilityId" });
            DropIndex("dbo.AspNetUsers", new[] { "EthnicityId" });
            DropIndex("dbo.AspNetUsers", new[] { "BodyTypeId" });
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropIndex("dbo.AspNetUsers", new[] { "AgeRangeId" });
            DropIndex("dbo.AspNetUsers", new[] { "EyeColorId" });
            DropIndex("dbo.AspNetUsers", new[] { "HairColorId" });
            DropIndex("dbo.Experiences", new[] { "UserId" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Videos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Links");
            DropTable("dbo.Images");
            DropTable("dbo.HairColors");
            DropTable("dbo.Genders");
            DropTable("dbo.EyeColors");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Experiences");
            DropTable("dbo.Ethnicities");
            DropTable("dbo.Categories");
            DropTable("dbo.BodyTypes");
            DropTable("dbo.Availabilities");
            DropTable("dbo.AgeRanges");
        }
    }
}
