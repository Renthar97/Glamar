namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ALOJAMIENTOes", "HotelId", "dbo.HOTELs");
            DropForeignKey("dbo.ALOJAMIENTOes", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.HOTELs", "CiudadId", "dbo.CIUDADs");
            DropForeignKey("dbo.ITINERARIOs", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.RESERVAs", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.DOCUMENTOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.TELEFONOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.TIPOCORREOs", "CorreoId", "dbo.CORREOs");
            DropForeignKey("dbo.DOCUMENTOes", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.VENTAs", "EmpleadoId", "dbo.EMPLEADOes");
            DropForeignKey("dbo.VENTAs", "MonedaId", "dbo.MONEDAs");
            DropForeignKey("dbo.EMPLEADOes", "LoginId", "dbo.LOGINs");
            DropForeignKey("dbo.TIPOTELEFONOes", "TelefonoId", "dbo.TELEFONOes");
            DropIndex("dbo.ALOJAMIENTOes", new[] { "ReservaId" });
            DropIndex("dbo.ALOJAMIENTOes", new[] { "HotelId" });
            DropIndex("dbo.HOTELs", new[] { "CiudadId" });
            DropIndex("dbo.RESERVAs", new[] { "VentaId" });
            DropIndex("dbo.TIPOCORREOs", new[] { "CorreoId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "VentaId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "ClienteId" });
            DropIndex("dbo.VENTAs", new[] { "EmpleadoId" });
            DropIndex("dbo.VENTAs", new[] { "MonedaId" });
            DropIndex("dbo.EMPLEADOes", new[] { "LoginId" });
            DropIndex("dbo.TELEFONOes", new[] { "ClienteId" });
            DropIndex("dbo.TIPOTELEFONOes", new[] { "TelefonoId" });
            DropIndex("dbo.ITINERARIOs", new[] { "ReservaId" });
            AlterColumn("dbo.ALOJAMIENTOes", "ReservaId", c => c.Int(nullable: false));
            AlterColumn("dbo.ALOJAMIENTOes", "HotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.ALOJAMIENTOes", "nro_Hab", c => c.Int(nullable: false));
            AlterColumn("dbo.HOTELs", "CiudadId", c => c.Int(nullable: false));
            AlterColumn("dbo.RESERVAs", "VentaId", c => c.Int(nullable: false));
            AlterColumn("dbo.CLIENTEs", "pts_Acum", c => c.Int(nullable: false));
            AlterColumn("dbo.CLIENTEs", "pts_Usados", c => c.Int(nullable: false));
            AlterColumn("dbo.CLIENTEs", "pts_Disp", c => c.Int(nullable: false));
            AlterColumn("dbo.CORREOs", "IdCliente", c => c.Int(nullable: false));
            AlterColumn("dbo.TIPOCORREOs", "CorreoId", c => c.Int(nullable: false));
            AlterColumn("dbo.DOCUMENTOes", "VentaId", c => c.Int(nullable: false));
            AlterColumn("dbo.DOCUMENTOes", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.VENTAs", "EmpleadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.VENTAs", "MonedaId", c => c.Int(nullable: false));
            AlterColumn("dbo.VENTAs", "Monto", c => c.Int(nullable: false));
            AlterColumn("dbo.EMPLEADOes", "LoginId", c => c.Int(nullable: false));
            AlterColumn("dbo.TELEFONOes", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.TIPOTELEFONOes", "TelefonoId", c => c.Int(nullable: false));
            AlterColumn("dbo.ITINERARIOs", "ReservaId", c => c.Int(nullable: false));
            AlterColumn("dbo.ITINERARIOs", "fec_Salida", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ITINERARIOs", "fec_Retorno", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ITINERARIOs", "distancia", c => c.Int(nullable: false));
            CreateIndex("dbo.ALOJAMIENTOes", "ReservaId");
            CreateIndex("dbo.ALOJAMIENTOes", "HotelId");
            CreateIndex("dbo.HOTELs", "CiudadId");
            CreateIndex("dbo.RESERVAs", "VentaId");
            CreateIndex("dbo.TIPOCORREOs", "CorreoId");
            CreateIndex("dbo.DOCUMENTOes", "VentaId");
            CreateIndex("dbo.DOCUMENTOes", "ClienteId");
            CreateIndex("dbo.VENTAs", "EmpleadoId");
            CreateIndex("dbo.VENTAs", "MonedaId");
            CreateIndex("dbo.EMPLEADOes", "LoginId");
            CreateIndex("dbo.TELEFONOes", "ClienteId");
            CreateIndex("dbo.TIPOTELEFONOes", "TelefonoId");
            CreateIndex("dbo.ITINERARIOs", "ReservaId");
            AddForeignKey("dbo.ALOJAMIENTOes", "HotelId", "dbo.HOTELs", "HotelId", cascadeDelete: true);
            AddForeignKey("dbo.ALOJAMIENTOes", "ReservaId", "dbo.RESERVAs", "ReservaId", cascadeDelete: true);
            AddForeignKey("dbo.HOTELs", "CiudadId", "dbo.CIUDADs", "CiudadId", cascadeDelete: true);
            AddForeignKey("dbo.ITINERARIOs", "ReservaId", "dbo.RESERVAs", "ReservaId", cascadeDelete: true);
            AddForeignKey("dbo.RESERVAs", "VentaId", "dbo.VENTAs", "VentaId", cascadeDelete: true);
            AddForeignKey("dbo.DOCUMENTOes", "ClienteId", "dbo.CLIENTEs", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.TELEFONOes", "ClienteId", "dbo.CLIENTEs", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.TIPOCORREOs", "CorreoId", "dbo.CORREOs", "CorreoId", cascadeDelete: true);
            AddForeignKey("dbo.DOCUMENTOes", "VentaId", "dbo.VENTAs", "VentaId", cascadeDelete: true);
            AddForeignKey("dbo.VENTAs", "EmpleadoId", "dbo.EMPLEADOes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.VENTAs", "MonedaId", "dbo.MONEDAs", "MonedaId", cascadeDelete: true);
            AddForeignKey("dbo.EMPLEADOes", "LoginId", "dbo.LOGINs", "LoginId", cascadeDelete: true);
            AddForeignKey("dbo.TIPOTELEFONOes", "TelefonoId", "dbo.TELEFONOes", "TelefonoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TIPOTELEFONOes", "TelefonoId", "dbo.TELEFONOes");
            DropForeignKey("dbo.EMPLEADOes", "LoginId", "dbo.LOGINs");
            DropForeignKey("dbo.VENTAs", "MonedaId", "dbo.MONEDAs");
            DropForeignKey("dbo.VENTAs", "EmpleadoId", "dbo.EMPLEADOes");
            DropForeignKey("dbo.DOCUMENTOes", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.TIPOCORREOs", "CorreoId", "dbo.CORREOs");
            DropForeignKey("dbo.TELEFONOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.DOCUMENTOes", "ClienteId", "dbo.CLIENTEs");
            DropForeignKey("dbo.RESERVAs", "VentaId", "dbo.VENTAs");
            DropForeignKey("dbo.ITINERARIOs", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.HOTELs", "CiudadId", "dbo.CIUDADs");
            DropForeignKey("dbo.ALOJAMIENTOes", "ReservaId", "dbo.RESERVAs");
            DropForeignKey("dbo.ALOJAMIENTOes", "HotelId", "dbo.HOTELs");
            DropIndex("dbo.ITINERARIOs", new[] { "ReservaId" });
            DropIndex("dbo.TIPOTELEFONOes", new[] { "TelefonoId" });
            DropIndex("dbo.TELEFONOes", new[] { "ClienteId" });
            DropIndex("dbo.EMPLEADOes", new[] { "LoginId" });
            DropIndex("dbo.VENTAs", new[] { "MonedaId" });
            DropIndex("dbo.VENTAs", new[] { "EmpleadoId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "ClienteId" });
            DropIndex("dbo.DOCUMENTOes", new[] { "VentaId" });
            DropIndex("dbo.TIPOCORREOs", new[] { "CorreoId" });
            DropIndex("dbo.RESERVAs", new[] { "VentaId" });
            DropIndex("dbo.HOTELs", new[] { "CiudadId" });
            DropIndex("dbo.ALOJAMIENTOes", new[] { "HotelId" });
            DropIndex("dbo.ALOJAMIENTOes", new[] { "ReservaId" });
            AlterColumn("dbo.ITINERARIOs", "distancia", c => c.Int());
            AlterColumn("dbo.ITINERARIOs", "fec_Retorno", c => c.DateTime());
            AlterColumn("dbo.ITINERARIOs", "fec_Salida", c => c.DateTime());
            AlterColumn("dbo.ITINERARIOs", "ReservaId", c => c.Int());
            AlterColumn("dbo.TIPOTELEFONOes", "TelefonoId", c => c.Int());
            AlterColumn("dbo.TELEFONOes", "ClienteId", c => c.Int());
            AlterColumn("dbo.EMPLEADOes", "LoginId", c => c.Int());
            AlterColumn("dbo.VENTAs", "Monto", c => c.Int());
            AlterColumn("dbo.VENTAs", "MonedaId", c => c.Int());
            AlterColumn("dbo.VENTAs", "EmpleadoId", c => c.Int());
            AlterColumn("dbo.DOCUMENTOes", "ClienteId", c => c.Int());
            AlterColumn("dbo.DOCUMENTOes", "VentaId", c => c.Int());
            AlterColumn("dbo.TIPOCORREOs", "CorreoId", c => c.Int());
            AlterColumn("dbo.CORREOs", "IdCliente", c => c.Int());
            AlterColumn("dbo.CLIENTEs", "pts_Disp", c => c.Int());
            AlterColumn("dbo.CLIENTEs", "pts_Usados", c => c.Int());
            AlterColumn("dbo.CLIENTEs", "pts_Acum", c => c.Int());
            AlterColumn("dbo.RESERVAs", "VentaId", c => c.Int());
            AlterColumn("dbo.HOTELs", "CiudadId", c => c.Int());
            AlterColumn("dbo.ALOJAMIENTOes", "nro_Hab", c => c.Int());
            AlterColumn("dbo.ALOJAMIENTOes", "HotelId", c => c.Int());
            AlterColumn("dbo.ALOJAMIENTOes", "ReservaId", c => c.Int());
            CreateIndex("dbo.ITINERARIOs", "ReservaId");
            CreateIndex("dbo.TIPOTELEFONOes", "TelefonoId");
            CreateIndex("dbo.TELEFONOes", "ClienteId");
            CreateIndex("dbo.EMPLEADOes", "LoginId");
            CreateIndex("dbo.VENTAs", "MonedaId");
            CreateIndex("dbo.VENTAs", "EmpleadoId");
            CreateIndex("dbo.DOCUMENTOes", "ClienteId");
            CreateIndex("dbo.DOCUMENTOes", "VentaId");
            CreateIndex("dbo.TIPOCORREOs", "CorreoId");
            CreateIndex("dbo.RESERVAs", "VentaId");
            CreateIndex("dbo.HOTELs", "CiudadId");
            CreateIndex("dbo.ALOJAMIENTOes", "HotelId");
            CreateIndex("dbo.ALOJAMIENTOes", "ReservaId");
            AddForeignKey("dbo.TIPOTELEFONOes", "TelefonoId", "dbo.TELEFONOes", "TelefonoId");
            AddForeignKey("dbo.EMPLEADOes", "LoginId", "dbo.LOGINs", "LoginId");
            AddForeignKey("dbo.VENTAs", "MonedaId", "dbo.MONEDAs", "MonedaId");
            AddForeignKey("dbo.VENTAs", "EmpleadoId", "dbo.EMPLEADOes", "EmpleadoId");
            AddForeignKey("dbo.DOCUMENTOes", "VentaId", "dbo.VENTAs", "VentaId");
            AddForeignKey("dbo.TIPOCORREOs", "CorreoId", "dbo.CORREOs", "CorreoId");
            AddForeignKey("dbo.TELEFONOes", "ClienteId", "dbo.CLIENTEs", "ClienteId");
            AddForeignKey("dbo.DOCUMENTOes", "ClienteId", "dbo.CLIENTEs", "ClienteId");
            AddForeignKey("dbo.RESERVAs", "VentaId", "dbo.VENTAs", "VentaId");
            AddForeignKey("dbo.ITINERARIOs", "ReservaId", "dbo.RESERVAs", "ReservaId");
            AddForeignKey("dbo.HOTELs", "CiudadId", "dbo.CIUDADs", "CiudadId");
            AddForeignKey("dbo.ALOJAMIENTOes", "ReservaId", "dbo.RESERVAs", "ReservaId");
            AddForeignKey("dbo.ALOJAMIENTOes", "HotelId", "dbo.HOTELs", "HotelId");
        }
    }
}