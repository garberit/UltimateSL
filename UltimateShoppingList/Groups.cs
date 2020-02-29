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
		public int GroupCreatedByUser { get; set; }
		public int GroupID { get; set; }

		public User User { get; set; }
		#endregion


		#region Methods
		public Groups()
		{

		}

		#endregion
	}
}
