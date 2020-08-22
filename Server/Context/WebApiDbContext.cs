using Microsoft.EntityFrameworkCore;
using SurcosBlazor.Shared.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SurcosBlazor.Server.Helpers;

namespace SurcosBlazor.Server.Context
{
    public class WebApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> optiones): base(optiones)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Vendedor>().HasQueryFilter(x => x.enabled == true);
            modelBuilder.Entity<Proveedor>().HasQueryFilter(x => x.enabled == true);

            modelBuilder.Entity<Producto>().HasQueryFilter(x => x.enabled == true);
            modelBuilder.Entity<TipoMovimientoCaja>().HasQueryFilter(x => x.enabled == true);

            modelBuilder.Entity<PresentacionProducto>().HasQueryFilter(x => x.enabled == true);

            modelBuilder.Entity<ProductoPresentacion>().HasQueryFilter(x => x.enabled == true);
            modelBuilder.Entity<Cliente>().HasQueryFilter(x => x.enabled == true);

            modelBuilder.Entity<CategoriaCliente>().HasMany(x => x.Cliente).WithOne(x =>x.Categoria).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<CategoriaCliente>().HasMany(x => x.TipoListaPrecioCategoriaClientes).WithOne(x => x.CategoriaCliente).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Provincia>().HasMany(x => x.TipoListaPrecioProvincia).WithOne(x => x.Provincia).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Provincia>().HasMany(x => x.departamentos).WithOne(x => x.Provincia).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Departamento>().HasMany(x => x.Domicilio).WithOne(x => x.Departamento).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Departamento>().HasMany(x => x.VendedorDepartamentos).WithOne(x => x.departamento).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoriaProducto>().HasMany(x => x.Productos).WithOne(x => x.CategoriaProducto).OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<ProductoPresentacion>().HasMany(x => x.DetallesFormula).WithOne(x => x.ProductoPresentacion).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<FormulaProducto>().Property(x => x.total).HasField("_total");
            modelBuilder.Entity<DetalleFormula>().HasOne(x => x.FormulaProducto).WithMany(x => x.DetallesFormula).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<CategoriaCliente>().HasData(new CategoriaCliente() { Id = 1, nombre = "Consumidor Final" });
            //modelBuilder.Entity<Cliente>().HasData(new Cliente() { Id = 1, razonSocial = "E-Commerce", CategoriaClienteId = 1 });
            //modelBuilder.Entity<Provincia>().HasData(new Provincia() { Id = 1, nombre = "Mendoza" });
            //modelBuilder.Entity<Provincia>().HasData(new Provincia() { Id = 2, nombre = "San Luis" });
            //modelBuilder.Entity<Provincia>().HasData(new Provincia() { Id = 3, nombre = "Buenos Aires" });
            //modelBuilder.Entity<Departamento>().HasData(new Departamento() { Id = 1, nombre = "Guaymallen" });
            //modelBuilder.Entity<Departamento>().HasData(new Departamento() { Id = 2, nombre = "Las Heras" });
            //modelBuilder.Entity<Departamento>().HasData(new Departamento() { Id = 3, nombre = "Godoy Cruz" });
            //modelBuilder.Entity<Departamento>().HasData(new Departamento() { Id = 4, nombre = "Lujan"});
            //modelBuilder.Entity<Departamento>().HasData(new Departamento() { Id = 5, nombre = "Lujan"});

            //modelBuilder.Entity<EstadoListaPrecios>().HasData(new EstadoListaPrecios() { Id = 1, nombre = "VIG" });
            //modelBuilder.Entity<EstadoListaPrecios>().HasData(new EstadoListaPrecios() { Id = 2, nombre = "CAD" });

            //modelBuilder.Entity<EstadoPedido>().HasData(new EstadoPedido() { Id = 1, nombre = "PEN" });
            //modelBuilder.Entity<EstadoPedido>().HasData(new EstadoPedido() { Id = 2, nombre = "TER" });
            //modelBuilder.Entity<EstadoPedido>().HasData(new EstadoPedido() { Id = 3, nombre = "ENT" });

            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 1, nombre = "Domingo" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 2, nombre = "Lunes" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 3, nombre = "Martes" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 4, nombre = "Miercoles" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 5, nombre = "Jueves" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 6, nombre = "Viernes" });
            //modelBuilder.Entity<DiasDeLaSemana>().HasData(new DiasDeLaSemana() { Id = 7, nombre = "Sábado" });

        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted && x.Metadata.GetProperties().Any(y => y.Name == "enabled")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["enabled"] = false;
            
            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        public DbSet<UserVendedor> userVendedor { get; set; }
        public DbSet<UserDeposito> userDeposito { get; set; }
        public DbSet<UserCaja> userCaja { get; set; }

        public DbSet<Provincia> provincias { get; set; }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<CategoriaCliente> categoriaCliente { get; set; }
        public DbSet<TipoListaPrecio> tipoListaPrecio { get; set; }
        public DbSet<TipoListaPrecioCategoriaCliente> TipoListaPrecioCategoriaCliente { get; set; }
        public DbSet<TipoListaPrecioProvincia> TipoListaPrecioProvincia { get; set; }
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<Domicilio> domicilio { get; set; }

        public DbSet<ListaPrecios> listaPrecios { get; set; }
        public DbSet<DetalleListaPrecios> detalleListaPrecios { get; set; }

        public DbSet<ProductoPresentacion> productoPresentaciones { get; set; }
        public DbSet<PresentacionProducto> presentacionProducto { get; set; }

        public DbSet<Unidad> unidad { get; set; }
        public DbSet<Vendedor> vendedor { get; set; }
        public DbSet<VendedorDepartamento> vendedorDepartamento { get; set; }

        public DbSet<Pedido> pedido { get; set; }

        public DbSet<DetallePedido> detallePedido { get; set; }
        public DbSet<EstadoPedido> estadoPedido { get; set; }

        public DbSet<Producto> producto { get; set; }

        public DbSet<CategoriaProducto> categoriaProducto { get; set; }

        public DbSet<ProductoPresentacion> productoPresentacion { get; set; }

        public DbSet<FormulaProducto> FormulaProducto { get; set; }
        public DbSet<DetalleFormula> detalleFormula { get; set; }
        public DbSet<MovimientoInventario> movimientoInventario { get; set; }
        public DbSet<Banner> banner { get; set; }

        public DbSet<Inventario> inventario { get; set; }
        public DbSet<Deposito> deposito { get; set; }
        public DbSet<Comprobante> comprobante { get; set; }
        public DbSet<ReciboCobranzas> reciboCobranzas { get; set; }
        public DbSet<OrdenPago> ordenPago { get; set; }

        public DbSet<EstadoRecibo> estadoRecibo { get; set; }

        public DbSet<ImputacionComprobantesVenta> imputacionComprobantesVenta { get; set; }
        public DbSet<ImputacionComprobantesCompra> imputacionComprobantesCompra { get; set; }

        public DbSet<TipoComprobante> tipoComprobante { get; set; }
        public DbSet<EstadoComprobante> EstadoComprobante { get; set; }
        public DbSet<EstadoFactura> estadoFactura { get; set; }
        public DbSet<Factura> factura { get; set; }
        public DbSet<FacturaCompras> facturaCompra { get; set; }
        public DbSet<DetalleFacturaCompras> detalleFacturaCompras { get; set; }

        public DbSet<DetalleFactura> detalleFactura { get; set; }
        public DbSet<DetallePago> detallePago { get; set; }
        public DbSet<Caja> caja { get; set; }
        public DbSet<MovimientoCaja> movimientoCaja { get; set; }

        public DbSet<TipoMovimientoCaja> tipoMovimientoCaja { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<OrdenProduccion> ordenProduccion { get; set; }
        public DbSet<DetalleOrdenProduccion> detallesOrdenProduccion { get; set; }
        public DbSet<EstadoOrdenProduccion> estadoOrdenProduccion { get; set; }
        public DbSet<UserTokenRecovery> userTokenRecovery { get; set; }





    }
}
