namespace FashionIA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourates", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.Favourates", new[] { "Article_ArticleId" });
            DropPrimaryKey("dbo.Favourates");
            AddColumn("dbo.Favourates", "ArticleId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Favourates", "ArticleId");
            DropColumn("dbo.Favourates", "Article_ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favourates", "Article_ArticleId", c => c.Int());
            DropPrimaryKey("dbo.Favourates");
            DropColumn("dbo.Favourates", "ArticleId");
            AddPrimaryKey("dbo.Favourates", "Date");
            CreateIndex("dbo.Favourates", "Article_ArticleId");
            AddForeignKey("dbo.Favourates", "Article_ArticleId", "dbo.Articles", "ArticleId");
        }
    }
}
