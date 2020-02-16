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
		public List<Product> ShopListProducts { get; set; }
		public Groups ShopListUsers { get; set; }
		public DateTime ShopListCreatedDate { get; set; }

		private static int LastShopListID = 0;
		public string ShopListEmailAddressOfOwner { get; set; }

		#endregion


		#region Method
		public ShoppingList()
		{
			ShopListID += LastShopListID;

		}

		public void AddProducts(Product p)
		{
			ShopListProducts.Add(p);
		}
		

		#endregion

	}
}
