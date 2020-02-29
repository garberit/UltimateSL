using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateShoppingList
{
    public enum PCategory
    {
        Baby,
        Cleaning,
        Dairy,
        DryFood,
        Electronics,
        Fashion,
        Fish,
        Frozen,
        Fruits,
        Houshold,
        Meat,
        Pets,
        Vegetables
    }
    class Product
	{
		#region Properties
        public int ProductID { get;  set; }
        public string ProductName { get; set; }
        public PCategory ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductPickedUp { get; set; }
        public string ProductNotes { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime ProductCreationDate { get;  set; }
        public User ProductCreatedBy { get; set; }
        public Groups ProductSharedWith { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int ShoppingListID { get; set; }

        #endregion


        #region Methods
        public Product()
        {

        }

        #endregion
    }
}
