namespace Onibus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.viagems",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Veiculo = c.Int(nullable: false),
                        Motorista = c.Int(nullable: false),
                        Rota = c.Int(nullable: false),
                        HorarioViagem = c.Int(nullable: false),
                        Custo = c.Int(nullable: false),
                        PosicaoVeiculo = c.Int(nullable: false),
                        DataViagem = c.DateTime(nullable: false)
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.viagems");
        }
    }
}
