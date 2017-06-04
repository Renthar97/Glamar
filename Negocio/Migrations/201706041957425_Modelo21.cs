namespace Negocio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo21 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ALOJAMIENTOes", newName: "Alojamiento");
            RenameTable(name: "dbo.HOTELs", newName: "Hotel");
            RenameTable(name: "dbo.CIUDADs", newName: "Ciudad");
            RenameTable(name: "dbo.RESERVAs", newName: "Reserva");
            RenameTable(name: "dbo.CLIENTEs", newName: "Cliente");
            RenameTable(name: "dbo.CORREOs", newName: "Correo");
            RenameTable(name: "dbo.TIPOCORREOs", newName: "Tipo_Correo");
            RenameTable(name: "dbo.DOCUMENTOes", newName: "Documento");
            RenameTable(name: "dbo.VENTAs", newName: "Venta");
            RenameTable(name: "dbo.EMPLEADOes", newName: "Empleado");
            RenameTable(name: "dbo.LOGINs", newName: "Login");
            RenameTable(name: "dbo.MONEDAs", newName: "Moneda");
            RenameTable(name: "dbo.TELEFONOes", newName: "Telefono");
            RenameTable(name: "dbo.TIPOTELEFONOes", newName: "Tipo_Telefono");
            RenameTable(name: "dbo.ITINERARIOs", newName: "Itinerario");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Itinerario", newName: "ITINERARIOs");
            RenameTable(name: "dbo.Tipo_Telefono", newName: "TIPOTELEFONOes");
            RenameTable(name: "dbo.Telefono", newName: "TELEFONOes");
            RenameTable(name: "dbo.Moneda", newName: "MONEDAs");
            RenameTable(name: "dbo.Login", newName: "LOGINs");
            RenameTable(name: "dbo.Empleado", newName: "EMPLEADOes");
            RenameTable(name: "dbo.Venta", newName: "VENTAs");
            RenameTable(name: "dbo.Documento", newName: "DOCUMENTOes");
            RenameTable(name: "dbo.Tipo_Correo", newName: "TIPOCORREOs");
            RenameTable(name: "dbo.Correo", newName: "CORREOs");
            RenameTable(name: "dbo.Cliente", newName: "CLIENTEs");
            RenameTable(name: "dbo.Reserva", newName: "RESERVAs");
            RenameTable(name: "dbo.Ciudad", newName: "CIUDADs");
            RenameTable(name: "dbo.Hotel", newName: "HOTELs");
            RenameTable(name: "dbo.Alojamiento", newName: "ALOJAMIENTOes");
        }
    }
}
