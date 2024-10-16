using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aplicativo.Models;

public partial class MedellinSalvajeContext : DbContext
{
    public MedellinSalvajeContext()
    {
    }

    public MedellinSalvajeContext(DbContextOptions<MedellinSalvajeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abono> Abonos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleHabitacione> DetalleHabitaciones { get; set; }

    public virtual DbSet<DetallePaquete> DetallePaquetes { get; set; }

    public virtual DbSet<DetalleServicio> DetalleServicios { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<HabitacionesInmueble> HabitacionesInmuebles { get; set; }

    public virtual DbSet<Inmueble> Inmuebles { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<PaquetesHabitacione> PaquetesHabitaciones { get; set; }

    public virtual DbSet<PaquetesHospedaje> PaquetesHospedajes { get; set; }

    public virtual DbSet<PaquetesServicio> PaquetesServicios { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermiso> RolesPermisos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoHabitacione> TipoHabitaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KJVOQU5\\SQLEXPRESS;Initial Catalog=Medellin_Salvaje;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abono>(entity =>
        {
            entity.HasKey(e => e.IdAbono).HasName("PK__Abonos__A4693DA77C5E6D5B");

            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaAbono)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IVA");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.Abonos)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Abonos_Reservas");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Documento).HasName("PK__Clientes__AF73706C3F77FD69");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Clientes__531402F34F16A5F1").IsUnique();

            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__IdRol__59063A47");
        });

        modelBuilder.Entity<DetalleHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdDetalleHabitacion).HasName("PK__DetalleH__15D58EF9E1BA9F84");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.DetalleHabitaciones)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleHa__IdHab__123EB7A3");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetalleHabitaciones)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleHa__IdRes__114A936A");
        });

        modelBuilder.Entity<DetallePaquete>(entity =>
        {
            entity.HasKey(e => e.IdDetallePaquete).HasName("PK__DetalleP__4DD779D7122D1DCF");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.DetallePaquetes)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePa__IdPaq__0D7A0286");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetallePaquetes)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePa__IdRes__0C85DE4D");
        });

        modelBuilder.Entity<DetalleServicio>(entity =>
        {
            entity.HasKey(e => e.IdDetalleServicio).HasName("PK__DetalleS__0BFF94E6E8742EDC");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleSe__IdRes__07C12930");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleSe__IdSer__08B54D69");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Nit).HasName("PK__Empresa__C7DEC3C320A9FE4A");

            entity.ToTable("Empresa");

            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RepresentanteLegal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF901651B0E16");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdInm__6383C8BA");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitaciones)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdTip__628FA481");
        });

        modelBuilder.Entity<HabitacionesInmueble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Habitaci__3214EC07EEDC4DEB");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.HabitacionesInmuebles)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdHab__6B24EA82");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.HabitacionesInmuebles)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdInm__6C190EBB");
        });

        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.HasKey(e => e.IdInmueble).HasName("PK__Inmueble__6B8E7D3E141FC003");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoInmueble)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__MetodoPa__6F49A9BE1B8AC27F");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaquetesHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdPaqueteHabitacion).HasName("PK__Paquetes__C0EF4AF02ABB7131");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.PaquetesHabitaciones)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__PaquetesH__IdHab__6FE99F9F");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.PaquetesHabitaciones)
                .HasForeignKey(d => d.IdPaquete)
                .HasConstraintName("FK__PaquetesH__IdPaq__6EF57B66");
        });

        modelBuilder.Entity<PaquetesHospedaje>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__Paquetes__DE278F8BAD43E956");

            entity.ToTable("PaquetesHospedaje");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioTotal).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PaquetesServicio>(entity =>
        {
            entity.HasKey(e => e.IdPaqueteServicio).HasName("PK__Paquetes__DE5C2BC2328AF9CA");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.PaquetesServicios)
                .HasForeignKey(d => d.IdPaquete)
                .HasConstraintName("FK__PaquetesS__IdPaq__72C60C4A");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.PaquetesServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__PaquetesS__IdSer__73BA3083");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC855AA74BC");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__0E49C69D1CB3CBA3");

            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DocumentoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IVA");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DocumentoClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DocumentoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Docume__7D439ABD");

            entity.HasOne(d => d.DocumentoUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DocumentoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Docume__7E37BEF6");

            entity.HasOne(d => d.IdAbonoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdAbono)
                .HasConstraintName("FK_Reservas_Abonos");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__IdMeto__00200768");

            entity.HasOne(d => d.NitNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Nit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__NIT__7F2BE32F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584CBF0740E5");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolesPermiso>(entity =>
        {
            entity.HasKey(e => e.IdRolPermiso).HasName("PK__RolesPer__0CC73B1B31B6316A");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.RolesPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .HasConstraintName("FK__RolesPerm__IdPer__4F7CD00D");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolesPermisos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolesPerm__IdRol__4E88ABD4");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A2CFEE109A");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TipoHabitacione>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__AB75E87C6582DF2F");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Documento).HasName("PK__Usuarios__AF73706C7C201B69");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F380F58612").IsUnique();

            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdRol__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
