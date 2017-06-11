namespace PaquetesTuristicos.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComprobantesPago",
                c => new
                    {
                        ComprobantePagoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.Int(nullable: false),
                        TipoComprobante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComprobantePagoId);
            
            CreateTable(
                "dbo.VentaPaquetes",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false, identity: true),
                        ComprobantePagoId = c.Int(nullable: false),
                        MediosPago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaPaqueteId)
                .ForeignKey("dbo.ComprobantesPago", t => t.ComprobantePagoId, cascadeDelete: true)
                .Index(t => t.ComprobantePagoId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Correo = c.String(),
                        Telefono = c.Int(nullable: false),
                        Dirección = c.String(),
                        NumeroDni = c.Int(nullable: false),
                        NumeroCuenta = c.Int(),
                        EmpleadoSueldo = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Paquetes",
                c => new
                    {
                        PaqueteId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PaqueteId);
            
            CreateTable(
                "dbo.ServicioTuristicos",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Hora = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        CategoriaAlimentacion = c.Int(),
                        Descripcion = c.String(),
                        TipoHospedaje = c.Int(),
                        CalificacionHospedaje = c.Int(),
                        CategoriaHospedaje = c.Int(),
                        ServicioHospedaje = c.Int(),
                        DescripcionTransporte = c.String(),
                        TipoTransporte = c.Int(),
                        CategoriaTransporte = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ServicioTuristicoId);
            
            CreateTable(
                "dbo.VentaPaquetesClientes",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaPaqueteId, t.ClienteId })
                .ForeignKey("dbo.VentaPaquetes", t => t.VentaPaqueteId, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.VentaPaqueteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.VentaPaquetesEmpleados",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaPaqueteId, t.EmpleadoId })
                .ForeignKey("dbo.VentaPaquetes", t => t.VentaPaqueteId, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.VentaPaqueteId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.PaquetesServiciosTuristicos",
                c => new
                    {
                        PaquetesId = c.Int(nullable: false),
                        ServicioTuristicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaquetesId, t.ServicioTuristicoId })
                .ForeignKey("dbo.Paquetes", t => t.PaquetesId, cascadeDelete: true)
                .ForeignKey("dbo.ServicioTuristicos", t => t.ServicioTuristicoId, cascadeDelete: true)
                .Index(t => t.PaquetesId)
                .Index(t => t.ServicioTuristicoId);
            
            CreateTable(
                "dbo.VentaPaquetesPaquetes",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false),
                        PaqueteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaPaqueteId, t.PaqueteId })
                .ForeignKey("dbo.VentaPaquetes", t => t.VentaPaqueteId, cascadeDelete: true)
                .ForeignKey("dbo.Paquetes", t => t.PaqueteId, cascadeDelete: true)
                .Index(t => t.VentaPaqueteId)
                .Index(t => t.PaqueteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VentaPaquetesPaquetes", "PaqueteId", "dbo.Paquetes");
            DropForeignKey("dbo.VentaPaquetesPaquetes", "VentaPaqueteId", "dbo.VentaPaquetes");
            DropForeignKey("dbo.PaquetesServiciosTuristicos", "ServicioTuristicoId", "dbo.ServicioTuristicos");
            DropForeignKey("dbo.PaquetesServiciosTuristicos", "PaquetesId", "dbo.Paquetes");
            DropForeignKey("dbo.VentaPaquetesEmpleados", "EmpleadoId", "dbo.Persona");
            DropForeignKey("dbo.VentaPaquetesEmpleados", "VentaPaqueteId", "dbo.VentaPaquetes");
            DropForeignKey("dbo.VentaPaquetes", "ComprobantePagoId", "dbo.ComprobantesPago");
            DropForeignKey("dbo.VentaPaquetesClientes", "ClienteId", "dbo.Persona");
            DropForeignKey("dbo.VentaPaquetesClientes", "VentaPaqueteId", "dbo.VentaPaquetes");
            DropIndex("dbo.VentaPaquetesPaquetes", new[] { "PaqueteId" });
            DropIndex("dbo.VentaPaquetesPaquetes", new[] { "VentaPaqueteId" });
            DropIndex("dbo.PaquetesServiciosTuristicos", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.PaquetesServiciosTuristicos", new[] { "PaquetesId" });
            DropIndex("dbo.VentaPaquetesEmpleados", new[] { "EmpleadoId" });
            DropIndex("dbo.VentaPaquetesEmpleados", new[] { "VentaPaqueteId" });
            DropIndex("dbo.VentaPaquetesClientes", new[] { "ClienteId" });
            DropIndex("dbo.VentaPaquetesClientes", new[] { "VentaPaqueteId" });
            DropIndex("dbo.VentaPaquetes", new[] { "ComprobantePagoId" });
            DropTable("dbo.VentaPaquetesPaquetes");
            DropTable("dbo.PaquetesServiciosTuristicos");
            DropTable("dbo.VentaPaquetesEmpleados");
            DropTable("dbo.VentaPaquetesClientes");
            DropTable("dbo.ServicioTuristicos");
            DropTable("dbo.Paquetes");
            DropTable("dbo.Persona");
            DropTable("dbo.VentaPaquetes");
            DropTable("dbo.ComprobantesPago");
        }
    }
}
