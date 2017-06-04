namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GLAMAR : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ALOJAMIENTOes",
                c => new
                    {
                        AlojamientoId = c.Int(nullable: false, identity: true),
                        ReservaId = c.Int(),
                        HotelId = c.Int(),
                        nro_Hab = c.Int(),
                    })
                .PrimaryKey(t => t.AlojamientoId)
                .ForeignKey("dbo.HOTELs", t => t.HotelId)
                .ForeignKey("dbo.RESERVAs", t => t.ReservaId)
                .Index(t => t.ReservaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.HOTELs",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        CiudadId = c.Int(),
                        NomHotel = c.String(),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.CIUDADs", t => t.CiudadId)
                .Index(t => t.CiudadId);
            
            CreateTable(
                "dbo.CIUDADs",
                c => new
                    {
                        CiudadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CiudadId);
            
            CreateTable(
                "dbo.RESERVAs",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.VENTAs", t => t.VentaId)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.CLIENTEs",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        nom_Cliente = c.String(),
                        ape_Cliente = c.String(),
                        pts_Acum = c.Int(),
                        pts_Usados = c.Int(),
                        pts_Disp = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.CORREOs",
                c => new
                    {
                        CorreoId = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(),
                        Correo1 = c.String(),
                        CLIENTE_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.CorreoId)
                .ForeignKey("dbo.CLIENTEs", t => t.CLIENTE_ClienteId)
                .Index(t => t.CLIENTE_ClienteId);
            
            CreateTable(
                "dbo.TIPOCORREOs",
                c => new
                    {
                        TipoCorreoId = c.Int(nullable: false, identity: true),
                        CorreoId = c.Int(),
                        TipoCorreo1 = c.String(),
                    })
                .PrimaryKey(t => t.TipoCorreoId)
                .ForeignKey("dbo.CORREOs", t => t.CorreoId)
                .Index(t => t.CorreoId);
            
            CreateTable(
                "dbo.DOCUMENTOes",
                c => new
                    {
                        DocumentoId = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(),
                        ClienteId = c.Int(),
                        tipo = c.String(),
                    })
                .PrimaryKey(t => t.DocumentoId)
                .ForeignKey("dbo.CLIENTEs", t => t.ClienteId)
                .ForeignKey("dbo.VENTAs", t => t.VentaId)
                .Index(t => t.VentaId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.VENTAs",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(),
                        MonedaId = c.Int(),
                        Monto = c.Int(),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.EMPLEADOes", t => t.EmpleadoId)
                .ForeignKey("dbo.MONEDAs", t => t.MonedaId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.MonedaId);
            
            CreateTable(
                "dbo.EMPLEADOes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(),
                        Apellidos = c.String(),
                        Nombres = c.String(),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.LOGINs", t => t.LoginId)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.LOGINs",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        contraseña = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.MONEDAs",
                c => new
                    {
                        MonedaId = c.Int(nullable: false, identity: true),
                        descp = c.String(),
                    })
                .PrimaryKey(t => t.MonedaId);
            
            CreateTable(
                "dbo.TELEFONOes",
                c => new
                    {
                        TelefonoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(),
                        numero = c.String(),
                    })
                .PrimaryKey(t => t.TelefonoId)
                .ForeignKey("dbo.CLIENTEs", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.TIPOTELEFONOes",
                c => new
                    {
                        TipoTelefonoId = c.Int(nullable: false, identity: true),
                        TelefonoId = c.Int(),
                        tipoTelefono1 = c.String(),
                    })
                .PrimaryKey(t => t.TipoTelefonoId)
                .ForeignKey("dbo.TELEFONOes", t => t.TelefonoId)
                .Index(t => t.TelefonoId);
            
            CreateTable(
                "dbo.ITINERARIOs",
                c => new
                    {
                        ITINERARIOId = c.Int(nullable: false, identity: true),
                        ReservaId = c.Int(),
                        origen = c.String(),
                        destino = c.String(),
                        fec_Salida = c.DateTime(),
                        fec_Retorno = c.DateTime(),
                        distancia = c.Int(),
                    })
                .PrimaryKey(t => t.ITINERARIOId)
                .ForeignKey("dbo.RESERVAs", t => t.ReservaId)
                .Index(t => t.ReservaId);
            
            CreateTable(
                "dbo.CLIENTERESERVAs",
                c => new
                    {
                        CLIENTE_ClienteId = c.Int(nullable: false),
                        RESERVA_ReservaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CLIENTE_ClienteId, t.RESERVA_ReservaId })
                .ForeignKey("dbo.CLIENTEs", t => t.CLIENTE_ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.RESERVAs", t => t.RESERVA_ReservaId, cascadeDelete: true)
                .Index(t => t.CLIENTE_ClienteId)
                .Index(t => t.RESERVA_ReservaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ITINERARIOs", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.TIPOTELEFONOes", "TelefonoId", "dbo.TELEFONOes");
            DropForeignKey("dbo.TELEFONOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.CLIENTERESERVAs", "RESERVA_ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.CLIENTERESERVAs", "CLIENTE_ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.RESERVAs", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.VENTAs", "MonedaId", "dbo.MONEDAs");
            DropForeignKey("dbo.VENTAs", "EmpleadoId", "dbo.EMPLEADOes");
            DropForeignKey("dbo.EMPLEADOes", "LoginId", "dbo.LOGINs");
            DropForeignKey("dbo.DOCUMENTOes", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.DOCUMENTOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.TIPOCORREOs", "CorreoId", "dbo.CORREOs");
            DropForeignKey("dbo.CORREOs", "CLIENTE_ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.ALOJAMIENTOes", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.HOTELs", "CiudadId", "dbo.CIUDADs");
            DropForeignKey("dbo.ALOJAMIENTOes", "HotelId", "dbo.HOTELs");
            DropIndex("dbo.CLIENTERESERVAs", new[] { "RESERVA_ReservaId" });
            DropIndex("dbo.CLIENTERESERVAs", new[] { "CLIENTE_ClienteId" });
            DropIndex("dbo.ITINERARIOs", new[] { "ReservaId" });
            DropIndex("dbo.TIPOTELEFONOes", new[] { "TelefonoId" });
            DropIndex("dbo.TELEFONOes", new[] { "ClienteId" });
            DropIndex("dbo.EMPLEADOes", new[] { "LoginId" });
            DropIndex("dbo.VENTAs", new[] { "MonedaId" });
            DropIndex("dbo.VENTAs", new[] { "EmpleadoId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "ClienteId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "VentaId" });
            DropIndex("dbo.TIPOCORREOs", new[] { "CorreoId" });
            DropIndex("dbo.CORREOs", new[] { "CLIENTE_ClienteId" });
            DropIndex("dbo.RESERVAs", new[] { "VentaId" });
            DropIndex("dbo.HOTELs", new[] { "CiudadId" });
            DropIndex("dbo.ALOJAMIENTOes", new[] { "HotelId" });
            DropIndex("dbo.ALOJAMIENTOes", new[] { "ReservaId" });
            DropTable("dbo.CLIENTERESERVAs");
            DropTable("dbo.ITINERARIOs");
            DropTable("dbo.TIPOTELEFONOes");
            DropTable("dbo.TELEFONOes");
            DropTable("dbo.MONEDAs");
            DropTable("dbo.LOGINs");
            DropTable("dbo.EMPLEADOes");
            DropTable("dbo.VENTAs");
            DropTable("dbo.DOCUMENTOes");
            DropTable("dbo.TIPOCORREOs");
            DropTable("dbo.CORREOs");
            DropTable("dbo.CLIENTEs");
            DropTable("dbo.RESERVAs");
            DropTable("dbo.CIUDADs");
            DropTable("dbo.HOTELs");
            DropTable("dbo.ALOJAMIENTOes");
        }
    }
}
