using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateShoppingList
{
	class Activity
	{

		public int ActivityID { get; set; }
		public DateTime ActivityDate { get; set; }
		public string ActivityDescription { get; set; }
		public int ActivityShoppingListID { get; set; }

		public int ActivityUserID { get; set; }
		public ShoppingList ShoppingList { get; set; }
		public Product Product { get; set; }
		public User User { get; set; }
		public Groups Groups { get; set; }


		public Activity()
		{

		}
	}
}
