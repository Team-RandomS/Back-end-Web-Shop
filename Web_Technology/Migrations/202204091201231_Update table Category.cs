namespace Web_Technology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatetableCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Laptop')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Màn hình')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Bàn phím')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Tai nghe')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Chuột')");
            Sql("INSERT INTO CATEGORIES(NAME) VALUES (N'Linh kiện')");
        }
        
        public override void Down()
        {
        }
    }
}
