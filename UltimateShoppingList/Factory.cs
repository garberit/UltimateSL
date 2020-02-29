using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateShoppingList
{
	static class Factory
	{
		#region Properties
		private static ShoppingListContext db = new ShoppingListContext();
		//private static List<ShoppingList> ShoppingLists = new List<ShoppingList>();
		//public static List<Activity> Activities = new List<Activity>();
		//public static List<Product> Products = new List<Product>();

		#endregion



		#region Methods

		public static ShoppingList CreateNewList(string name, string email)
		{
			ShoppingList s = new ShoppingList()
			{
				ShopListName = name,
				ShopListEmailAddressOfOwner = email,
				
			};

			db.ShoppingListsTable.Add(s);
			return s;
		}

		public static void RemoveProdByID(int ShoppingListID, int ProdID)
		{
			var shoplist = db.ShoppingListsTable.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
			var prod = db.ProductsTable.SingleOrDefault(p => p.ProductID == ProdID);
			
			shoplist.RemoveProducts(prod);

			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Removing Product",
				ActivityShoppingListID = ShoppingListID
			};
			db.ActivitiesTable.Add(activity);

		}
		public static Product CreateNewProduct(string name, PCategory category, decimal price, string notes, int quantity)
		{
		Product p = new Product()
			{
				ProductName = name,
				ProductCategory = category,
				ProductPrice = price,
				ProductNotes = notes,
				ProductQuantity = quantity
			};

			return p;

			
		}
		public static ShoppingList AddProdToList (Product p, ShoppingList s, int ShopID)
		{			
			ShopID = s.ShopListID;			
			s.AddProducts(p);

			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Adding Product",
				ActivityShoppingListID = ShopID
			};
			db.ActivitiesTable.Add(activity);
			return s;

		}
		public static void PrintProdList(int ShoppingListID) 
		{
			var shoplist = db.ShoppingListsTable.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
			if (shoplist == null)
			{
				//exception
				return;
			}
			Console.WriteLine("************************");
			Console.WriteLine("Here are all the products in your list:");
			Console.WriteLine("************************");

			foreach (var item in db.ProductsTable.Where(p => p.ShoppingListID == ShoppingListID))
			{
				Console.WriteLine($"ID: {item.ProductID}, Name: {item.ProductName}, Quantity: {item.ProductQuantity}, Category: {item.ProductCategory}, Price: {item.ProductPrice:C}, Notes: {item.ProductNotes}");
			}
			Console.WriteLine("************************");

			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Printing products",
				ActivityShoppingListID = shoplist.ShopListID
			};
			db.ActivitiesTable.Add(activity);
		}

		public static IEnumerable<ShoppingList> GetShoppingListsByEmailAddress(string email)
		{
			return db.ShoppingListsTable.Where(sl => sl.ShopListEmailAddressOfOwner == email);
		}
	
		public static void AddProduct(int ShoppingListID, Product p) //create one to remove product as well
		{
			var shoplist = db.ShoppingListsTable.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
			if (shoplist == null)
			{
				//exception
				return;
			}

			shoplist.AddProducts(p);
			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Adding a product",
				ActivityShoppingListID = shoplist.ShopListID
			};
			db.ActivitiesTable.Add(activity);
		}

		public static void RemoveProduct(int ShoppingListID, Product p)
		{
			var shoplist = db.ShoppingListsTable.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
			var id = p.ProductID;
			var prod = db.ProductsTable.SingleOrDefault(p => p.ProductID == id);

			shoplist.RemoveProducts(prod);

			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Removing Product",
				ActivityShoppingListID = ShoppingListID
			};
			db.ActivitiesTable.Add(activity);
			if (shoplist == null)
			{
				//exception 
				return;
			}
			
		}

		public static IEnumerable<Activity> GetActivitiesByShoppingListNumber(int ShoppingListNumber)
		{
			return db.ActivitiesTable.Where(a => a.ActivityShoppingListID == ShoppingListNumber);
			
		}


		#endregion

	}
}
