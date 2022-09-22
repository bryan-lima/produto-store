namespace ProdutoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialProdutoStore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategoriaProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true, name: "IX_CategoriaProduto_Nome_Unique");
            
            CreateTable(
                "dbo.tblProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        Perecivel = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategoriaProduto", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduto", "CategoriaID", "dbo.tblCategoriaProduto");
            DropIndex("dbo.tblProduto", new[] { "CategoriaID" });
            DropIndex("dbo.tblCategoriaProduto", "IX_CategoriaProduto_Nome_Unique");
            DropTable("dbo.tblProduto");
            DropTable("dbo.tblCategoriaProduto");
        }
    }
}
