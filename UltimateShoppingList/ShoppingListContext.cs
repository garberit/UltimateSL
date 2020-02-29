using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateShoppingList
{
	class ShoppingListContext : DbContext
	{
		public DbSet<Activity> ActivitiesTable { get; set; }
		public DbSet<Groups> GroupsTable { get; set; }
		public DbSet<Product> ProductsTable { get; set; }
		public DbSet<ShoppingList> ShoppingListsTable { get; set; }
		public DbSet<User> UsersTable { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShoppingListDB;Integrated Security=True;Connect Timeout=30;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<ShoppingList>(e =>
			{
				e.ToTable("ShoppingListsTable");
				e.HasKey(s => s.ShopListID)
					.HasName("PK_ShoppingLists");
				e.Property(s => s.ShopListID)
					.ValueGeneratedOnAdd();
				e.Property(s => s.ShopListEmailAddressOfOwner)
					.HasMaxLength(100)
					.IsRequired();
			});
			modelBuilder.Entity<User>(e =>
			{
				e.ToTable("UsersTable");
				e.HasKey(u => u.UserID)
					.HasName("PK_Users");
				e.Property(u => u.UserID)
					.IsRequired()
					.ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Groups>(e =>
			{
				e.ToTable("GroupsTable");
				e.HasKey(g => g.GroupID)
					.HasName("PK_Groups");
				e.Property(g => g.GroupCreatedDate)
					.ValueGeneratedOnAdd();
				e.Property(g => g.GroupCategory)
					.IsRequired();
				e.HasOne(g => g.User)
					.WithMany()
					.HasForeignKey(g => g.GroupCreatedByUser); //might be an issue with user property - need to run and see...?
			});
			modelBuilder.Entity<Product>(e =>
			{
				e.ToTable("ProductsTable");
				e.HasKey(p => p.ProductID)
					.HasName("PK_Products");
				e.Property(p => p.ProductID)
					.ValueGeneratedOnAdd();
				e.Property(p => p.ProductQuantity)
					.IsRequired();
				e.Property(p => p.ProductCreationDate)
					.ValueGeneratedOnAdd();
				e.HasOne(p => p.ShoppingList)
					.WithMany()
					.HasForeignKey(p => p.ShoppingListID);
			});
			modelBuilder.Entity<Activity>(e =>
			{
				e.ToTable("ActivitiesTable");
				e.HasKey(a => a.ActivityID)
					.HasName("PK_Activities");
				e.Property(a => a.ActivityDate)
					.ValueGeneratedOnAdd();
				e.HasOne(a => a.ShoppingList)
					.WithMany()
					.HasForeignKey(a => a.ActivityShoppingListID);
			});
			
		}


	}
}
