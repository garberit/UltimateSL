using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateShoppingList
{
	class User
	{
		#region Properties
		public string UserName { get; set; }
		public int UserID { get; set; }
		public string UserEMail { get; set; }
		public string UserAddress { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		private static int lastUserID = 0;

		#endregion



		#region Methods

		public User()
		{
			UserID += lastUserID;
		}

		#endregion

	}
}
