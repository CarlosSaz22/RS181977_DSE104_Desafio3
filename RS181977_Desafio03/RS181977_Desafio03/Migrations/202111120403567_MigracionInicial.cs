namespace RS181977_Desafio03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        primerApellido = c.String(nullable: false, maxLength: 100),
                        segundoApellido = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 8),
                        Dui = c.String(nullable: false, maxLength: 10),
                        email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Clientes_id = c.Int(nullable: false),
                        Productos_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clientes", t => t.Clientes_id, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.Productos_id, cascadeDelete: true)
                .Index(t => t.Clientes_id)
                .Index(t => t.Productos_id);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 100),
                        Descripción = c.String(nullable: false, maxLength: 100),
                        Stock = c.Int(nullable: false),
                        PrecioUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidos", "Productos_id", "dbo.Productos");
            DropForeignKey("dbo.Pedidos", "Clientes_id", "dbo.Clientes");
            DropIndex("dbo.Pedidos", new[] { "Productos_id" });
            DropIndex("dbo.Pedidos", new[] { "Clientes_id" });
            DropTable("dbo.Productos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Clientes");
        }
    }
}
