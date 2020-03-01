using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UltimateShoppingList
{
	class ShoppingList
	{

		#region Properties
		public string ShopListName { get; set; }
		public int ShopListID { get; set; }
		private static ShoppingListContext db = new ShoppingListContext();
		public Groups ShopListUsers { get; set; }
		public DateTime ShopListCreatedDate { get; set; }
		public string ShopListEmailAddressOfOwner { get; set; }
		#endregion


		#region Method
		public ShoppingList()
		{
		}

		public void AddProducts(Product p)
		{
			db.ProductsTable.Add(p);
		}

		public void RemoveProducts(Product p)
		{
			db.ProductsTable.Remove(p);
		}

		#endregion

	}
}
