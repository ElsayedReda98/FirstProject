using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

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
                builder.Property(c => c.BrandId).HasColumnName("brand_id");
                builder.Property(c => c.BrandName).HasColumnName("brand_name");                
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
                .HasForeignKey(sf => sf.ManagerId)
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
