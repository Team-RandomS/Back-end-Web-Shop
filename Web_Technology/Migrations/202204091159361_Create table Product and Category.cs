namespace Web_Technology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatetableProductandCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Idgory = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Idgory);
            
            CreateTable(
                "dbo.CTHDs",
                c => new
                    {
                        Iddonhang = c.Int(nullable: false),
                        Idproduct = c.Int(nullable: false),
                        soluong = c.Int(nullable: false),
                        gia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Iddonhang, t.Idproduct })
                .ForeignKey("dbo.Donhangs", t => t.Iddonhang, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Idproduct, cascadeDelete: true)
                .Index(t => t.Iddonhang)
                .Index(t => t.Idproduct);
            
            CreateTable(
                "dbo.Donhangs",
                c => new
                    {
                        Iddonhang = c.Int(nullable: false, identity: true),
                        ngaydat = c.DateTime(nullable: false),
                        ngaygiao = c.DateTime(nullable: false),
                        Idkhach = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Iddonhang)
                .ForeignKey("dbo.Khachhangs", t => t.Idkhach, cascadeDelete: true)
                .Index(t => t.Idkhach);
            
            CreateTable(
                "dbo.Khachhangs",
                c => new
                    {
                        Idkhach = c.Int(nullable: false, identity: true),
                        hoten = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        matkhau = c.String(nullable: false, maxLength: 255),
                        diachi = c.String(maxLength: 255),
                        dienthoai = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Idkhach);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Idproduct = c.Int(nullable: false, identity: true),
                        Productname = c.String(nullable: false, maxLength: 255),
                        gia = c.Double(nullable: false),
                        Imagepicture = c.String(nullable: false, maxLength: 255),
                        Idgory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idproduct)
                .ForeignKey("dbo.Categories", t => t.Idgory, cascadeDelete: true)
                .Index(t => t.Idgory);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CTHDs", "Idproduct", "dbo.Products");
            DropForeignKey("dbo.Products", "Idgory", "dbo.Categories");
            DropForeignKey("dbo.CTHDs", "Iddonhang", "dbo.Donhangs");
            DropForeignKey("dbo.Donhangs", "Idkhach", "dbo.Khachhangs");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "Idgory" });
            DropIndex("dbo.Donhangs", new[] { "Idkhach" });
            DropIndex("dbo.CTHDs", new[] { "Idproduct" });
            DropIndex("dbo.CTHDs", new[] { "Iddonhang" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Khachhangs");
            DropTable("dbo.Donhangs");
            DropTable("dbo.CTHDs");
            DropTable("dbo.Categories");
        }
    }
}
