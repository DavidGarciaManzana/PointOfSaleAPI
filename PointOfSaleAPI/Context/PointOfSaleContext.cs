using Microsoft.EntityFrameworkCore;
using PointOfSaleAPI.Models;

namespace PointOfSaleAPI.Context
{
    public class PointOfSaleContext:DbContext
    {
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }

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
                orderModelParameter.Property (x => x.SalesManId).IsRequired();
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
        }
}}
