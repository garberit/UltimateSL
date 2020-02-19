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
		private static int lastProductID = 0;
        public int ProductID { get; private set; }
        public string ProductName { get; set; }
        public PCategory ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductPickedUp { get; set; }
        public string ProductNotes { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime ProductCreationDate { get; private set; }

        #endregion


        #region Methods
        public Product()
        {
            ProductID = lastProductID++;

        }

        #endregion
    }
}
