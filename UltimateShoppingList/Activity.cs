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
		private static int lastActivityID = 0;


		public Activity()
		{
			ActivityID = lastActivityID++;

		}
	}
}
