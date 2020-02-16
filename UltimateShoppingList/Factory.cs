using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateShoppingList
{
	static class Factory
	{
		#region Properties
		private static List<ShoppingList> ShoppingLists = new List<ShoppingList>();
		private static List<Activity> Activities = new List<Activity>();
		private static List<Product> Products = new List<Product>();

		#endregion



		#region Methods

		public static ShoppingList CreateNewList(string name, List<Product> l, string email)
		{
			ShoppingList s = new ShoppingList()
			{
				ShopListName = name,
				ShopListProducts = l,
				ShopListEmailAddressOfOwner = email,
				
			};

			ShoppingLists.Add(s);
			return s;
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
			s.ShopListProducts.Add(p);
			return s;

		}
		public static void PrintProdList(int ShoppingListID) 
		{
			var shoplist = ShoppingLists.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
			if (shoplist == null)
			{
				//exception
				return;
			}

			foreach (var item in shoplist.ShopListProducts)
			{
				Console.WriteLine($"Name: {item.ProductName}, Quantity: {item.ProductQuantity}, Category: {item.ProductCategory}, Price: {item.ProductPrice:C}, Notes: {item.ProductNotes}");
			}
			var activity = new Activity
			{
				ActivityDate = DateTime.UtcNow,
				ActivityDescription = "Adding a product",
				ActivityShoppingListID = shoplist.ShopListID
			};
			Activities.Add(activity);
		}

		public static IEnumerable<ShoppingList> GetShoppingListsByEmailAddress(string email)
		{
			return ShoppingLists.Where(sl => sl.ShopListEmailAddressOfOwner == email);
		}
		public static IEnumerable<ShoppingList> GetShoppingListsID(int ListID)
		{
			return ShoppingLists.Where(id => id.ShopListID == ListID);
		}



		public static void AddProduct(int ShoppingListID, Product p) //create one to remove product as well
		{
			var shoplist = ShoppingLists.SingleOrDefault(sl => sl.ShopListID == ShoppingListID);
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
			Activities.Add(activity);
		}

	

		#endregion

	}
}
