using Microsoft.EntityFrameworkCore;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Context
{
    public class PointOfSaleContext:DbContext
    {
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<OrderItemModel> OrderItemModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<InventoryModel> InventoryModels { get; set; }
        public DbSet<WarehouseModel> WarehouseModels { get; set; }
        public DbSet<LocationModel> LocationModels { get; set; }
        public DbSet<CountryModel> CountryModels { get; set; }

        public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options) : base(options) { }  
        protected override void OnModelCreating (ModelBuilder modelBuilderParameter)
        {
            modelBuilderParameter.Entity<CustomerModel> (customerModelParameter =>
            {
                customerModelParameter.ToTable("Customers");
                customerModelParameter.HasKey(x => x.CustomerId);

                customerModelParameter.Property(x => x.Name).IsRequired().HasMaxLength(30);
                customerModelParameter.Property(x => x.Address).HasMaxLength(250);
                customerModelParameter.Property(x => x.Website).HasMaxLength(100);
            });
            modelBuilderParameter.Entity<OrderModel>(orderModelParameter =>
            {
                orderModelParameter.ToTable("Orders");
                orderModelParameter.HasKey(x => x.OrderId);

                orderModelParameter.HasOne(x => x.CustomerModels).WithMany(x => x.OrderModels).HasForeignKey(x => x.CustomerId);
                orderModelParameter.HasOne(x => x.EmployeeModels).WithMany(x => x.OrderModels).HasForeignKey(x => x.SalesManId);
                orderModelParameter.Property (x => x.Status).IsRequired().HasMaxLength(50);
                orderModelParameter.Property (x => x.OrderDate);
            }); 
            modelBuilderParameter.Entity<EmployeeModel>(orderModelParameter =>
            {
                orderModelParameter.ToTable("Employees");
                orderModelParameter.HasKey(x => x.EmployeeId);

                orderModelParameter.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
                orderModelParameter.Property(x => x.LastName).IsRequired().HasMaxLength(50);
                orderModelParameter.Property(x => x.Email).HasMaxLength(50);
                orderModelParameter.Property(x => x.Phone).HasMaxLength(50);
                orderModelParameter.Property(x => x.HireDate);
                orderModelParameter.Property(x => x.ManagerId).IsRequired();
                orderModelParameter.Property (x => x.JobTitle).HasMaxLength(50);
            });   
            modelBuilderParameter.Entity<OrderItemModel>(orderItemModelParameter =>
            {
                orderItemModelParameter.ToTable("OrderItems");
                orderItemModelParameter.HasKey(x => x.ItemId);

                orderItemModelParameter.HasOne(x => x.OrderModels).WithMany(x => x.OrderItemModels).HasForeignKey(x => x.OrderId);
                orderItemModelParameter.HasOne(x => x.ProductModels).WithMany(x => x.OrderItemModels).HasForeignKey(x => x.ProductId);
                orderItemModelParameter.Property(x => x.Quantity).IsRequired();
                orderItemModelParameter.Property(x => x.UnitPrice).IsRequired();
          
            });
            modelBuilderParameter.Entity<ProductModel>(productModelParameter =>
            {
                productModelParameter.ToTable("Products");
                productModelParameter.HasKey(x => x.ProductId);

                productModelParameter.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
                productModelParameter.Property(x => x.Description).HasMaxLength(250);
                productModelParameter.Property(x => x.StandardCost).IsRequired();
                productModelParameter.Property(x => x.ListPrice).IsRequired();
          
            });     
            modelBuilderParameter.Entity<InventoryModel>(inventoryModelParameter =>
            {
                inventoryModelParameter.ToTable("Inventories");
                inventoryModelParameter.HasKey(x => x.ProductId);

                inventoryModelParameter.HasOne(x => x.ProductModels).WithMany(x => x.InventoryModels).HasForeignKey(x => x.ProductId);
                inventoryModelParameter.HasOne(x => x.WarehouseModels).WithMany(x => x.InventoryModels).HasForeignKey(x => x.WarehouseId);

                inventoryModelParameter.Property(x => x.Quantity).IsRequired();
          
            }); 
            modelBuilderParameter.Entity<WarehouseModel>(warehouseModelParameter =>
            {
                warehouseModelParameter.ToTable("Warehouses");
                warehouseModelParameter.HasKey(x => x.WarehouseId);

                warehouseModelParameter.Property(x => x.WarehouseName).HasMaxLength(50);

                warehouseModelParameter.HasOne(x => x.LocationModels).WithMany(x => x.WarehouseModels).HasForeignKey(x => x.LocationId);
            });   
            modelBuilderParameter.Entity<LocationModel>(locationModelParameter =>
            {
                locationModelParameter.ToTable("Locations");
                locationModelParameter.HasKey(x => x.LocationId);

                locationModelParameter.Property(x => x.Address).HasMaxLength(100);
                locationModelParameter.Property(x => x.PostalCode);
                locationModelParameter.Property(x => x.City).HasMaxLength(100);
                locationModelParameter.Property(x => x.State).HasMaxLength(100);

                locationModelParameter.HasOne(x => x.CountryModels).WithMany(x => x.LocationModels).HasForeignKey(x => x.CountryId);

            });   
            modelBuilderParameter.Entity<CountryModel>(countryModelParameter =>
            {
                countryModelParameter.ToTable("Countries");
                countryModelParameter.HasKey(x => x.CountryId);

                countryModelParameter.Property(x => x.CountryName).HasMaxLength(50);
               });
        }
}}
