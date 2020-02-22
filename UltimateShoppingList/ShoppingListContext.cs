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


	}
}
