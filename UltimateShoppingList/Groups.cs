using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateShoppingList
{
	public enum GroupType
	{
		Business,
		Family,
		Friends,
		Team
	}
	class Groups
	{
		#region Properties
		public string GroupName { get; set; }
		public List<User> UsersInGroup { get; set; }
		public GroupType GroupCategory { get; set; }
		public DateTime GroupCreatedDate { get; set; }
		public User GroupCreatedBy { get; set; }
		public int GroupID { get; set; }

		private static int LastGroupID = 0;
		public User ShopListOwner { get; set; }
		#endregion


		#region Methods
		public Groups()
		{
			GroupID += LastGroupID;

		}

		#endregion
	}
}
