using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreConsoleApp
{
    public class StoreContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=BikeStores;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(builder =>
            {
                builder.ToTable("Brands", "production");
                builder.Property(b => b.BrandId).HasColumnName("brand_id");
                builder.Property(b => b.BrandName).HasColumnName("brand_name");                
            });
            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Categories", "production");
                builder.Property(c => c.CategoryId).HasColumnName("category_id");
                builder.Property(c => c.CategoryName).HasColumnName("category_name");
            });
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("products", "production");
                builder.Property(c => c.ProductId).HasColumnName("product_id");
                builder.Property(c => c.ProductName).HasColumnName("product_name");
                builder.Property(c => c.BrandId).HasColumnName("brand_id");
                builder.Property(c => c.CategoryId).HasColumnName("category_id");
                builder.Property(c => c.ModelYear).HasColumnName("model_year");
                builder.Property(c => c.ListPrice).HasColumnName("list_price");
               
            });
            modelBuilder.Entity<Stock>(builder =>
            {
                builder.ToTable("stocks", "production");
                builder.Property(c => c.StoreId).HasColumnName("store_id");
                builder.Property(c => c.ProductId).HasColumnName("product_id");
                builder.Property(c => c.Quantity).HasColumnName("quantity");
            });
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.ToTable("customers", "sales");
                builder.Property(c => c.Id).HasColumnName("customer_id");
                builder.Property(c => c.FirstName).HasColumnName("first_name");
                builder.Property(c => c.LastName).HasColumnName("last_name");
                builder.Property(c => c.Phone).HasColumnName("phone");
                builder.Property(c => c.Email).HasColumnName("email");
                builder.Property(c => c.Street).HasColumnName("street");
                builder.Property(c => c.City).HasColumnName("city");
                builder.Property(c => c.State).HasColumnName("state");
                builder.Property(c => c.ZipCode).HasColumnName("zip_code");
            });
            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("orders", "sales");
                builder.Property(o => o.OrderId).HasColumnName("order_id");
                builder.Property(o => o.CustomerId).HasColumnName("customer_id");
                builder.Property(o => o.OrderStatus).HasColumnName("order_status");
                builder.Property(o => o.OrderDate).HasColumnName("order_date");
                builder.Property(o => o.RequiredDate).HasColumnName("required_date");
                builder.Property(o => o.ShippedDate).HasColumnName("shipped_date");
                builder.Property(o => o.StoreId).HasColumnName("store_id");
                builder.Property(o => o.StaffId).HasColumnName("staff_id");

            });
            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.ToTable("order_items", "sales");
                builder.Property(oi => oi.ItemId).HasColumnName("item_id");
                builder.Property(oi => oi.Quantity).HasColumnName("quantity");
                builder.Property(oi => oi.Discount).HasColumnName("discount");
                builder.Property(oi => oi.ListPrice).HasColumnName("list_price");
                builder.Property(oi => oi.OrderId).HasColumnName("order_id");
                builder.Property(oi => oi.ProductId).HasColumnName("product_id"); 
            });
            modelBuilder.Entity<Store>(builder =>
            {
                builder.ToTable("stores", "sales");
                builder.Property(c => c.StoreId).HasColumnName("store_id");
                builder.Property(c => c.StoreName).HasColumnName("store_name");
                builder.Property(c => c.Phone).HasColumnName("phone");
                builder.Property(c => c.Email).HasColumnName("email");
                builder.Property(c => c.Street).HasColumnName("street");
                builder.Property(c => c.City).HasColumnName("city");
                builder.Property(c => c.State).HasColumnName("state");
                builder.Property(c => c.ZipCode).HasColumnName("zip_code");
            });
            modelBuilder.Entity<Staff>(builder =>
            {
                builder.ToTable("staffs", "sales");
                builder.Property(c => c.StaffId).HasColumnName("staff_id");
                builder.Property(c => c.FirstName).HasColumnName("first_name");
                builder.Property(c => c.LastName).HasColumnName("last_name");
                builder.Property(c => c.Phone).HasColumnName("phone");
                builder.Property(c => c.Email).HasColumnName("email");
                builder.Property(c => c.Active).HasColumnName("active");
                builder.Property(c => c.StoreId).HasColumnName("store_id");
                builder.Property(c => c.ManagerId).HasColumnName("manager_id");
            });

            // one to many rshp between to order & customer
            modelBuilder.Entity<Order>()
                .HasOne<Customer>(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many rshp between to order & staff
            modelBuilder.Entity<Order>()
                .HasOne<Staff>(o => o.Staff)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StaffId)
                .OnDelete(DeleteBehavior.Cascade);

            // one to many rshp between to order & store
            modelBuilder.Entity<Order>()
                .HasOne<Store>(o => o.Store)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StoreId)
                .OnDelete(DeleteBehavior.Cascade);

            //one to many rshp between to order & ordreitems
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(ot => ot.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(ot => ot.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


            // one to many rshp between to Products & Categories
            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            //one to many rshp between to products & ordreitems
            //orderitems is many
            //products is one
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(oi => oi.Product)
                .WithMany(p => p.orderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //one to many rshp between to products & Brands
            //Brands is one
            //products is many
            modelBuilder.Entity<Product>()
                .HasOne<Brand>(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);


            //one to many rshp between to stocks & Stores
            //stock is many
            //store is one
            modelBuilder.Entity<Stock>()
                .HasOne<Store>(sc => sc.Store)
                .WithMany(sr => sr.Stocks)
                .HasForeignKey(sc => sc.StoreId)
                .OnDelete(DeleteBehavior.Cascade);


            //one to many rshp between to stocks & Products
            //stock is many
            //Products is one
            modelBuilder.Entity<Stock>()
                .HasOne<Product>(sk => sk.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(sk => sk.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //one to many rshp between to stores & staffs
            //staffs is many
            //stores is one
            modelBuilder.Entity<Staff>()
                .HasOne<Store>(sf => sf.Store)
                .WithMany(sr => sr.Staffs)
                //.HasForeignKey(sf => sf.StoreId)
                
                .OnDelete(DeleteBehavior.Cascade)
                .OnDelete(DeleteBehavior.NoAction)
                //.IsRequired(false)
                ;
            //or 
            //modelBuilder.Entity<Store>()
            //     .HasMany<Staff>(sr => sr.Staffs)
            //     .WithOne(sf => sf.Store)
            //     .HasForeignKey(sf => sf.StoreId);

            // pk for orderitem
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });
            // pk for stock
            modelBuilder.Entity<Stock>()
                .HasKey(sk => new { sk.ProductId, sk.StoreId });

            // pk for staff
            //modelBuilder.Entity<Staff>()
            //    .HasKey(sf => new { sf.StaffId });

            // recursive rsh in staff table



        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}
