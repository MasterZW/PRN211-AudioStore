using AudioStore.Models.Entities;
using AudioStore.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AudioStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration double primary keys for bill details in DB
            modelBuilder.Entity<OrderDetail>().HasKey(b => new
            {
                b.ProductID,
                b.OrderID
            });

            //Setup tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Evaluate>().ToTable("Evaluates");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Avatar>().ToTable("Avatars");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
            modelBuilder.Entity<Category>().ToTable("Categories");

            //seed
            modelBuilder.Seed();
        }

        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { set; get; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Evaluate> Evaluates { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}