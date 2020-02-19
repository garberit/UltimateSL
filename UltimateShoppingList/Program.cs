using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateShoppingList
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Console.WriteLine("*********************");
			Console.WriteLine("Welcome to the shopping list!");
			while (true)
			{
				Console.WriteLine("0 - Exit");
				Console.WriteLine("1 - Create New List");
				Console.WriteLine("2 - Edit my list");
				Console.WriteLine("3 - Print all lists");
				Console.WriteLine("4 - Print activities in my list");
				Console.WriteLine("*********************");
				Console.Write("Please select an option ");

				var answer = Console.ReadLine();

				switch (answer)
				{
					case "0":
						Console.WriteLine("Thank you, Bye!");
						return;

					case "1":
						Console.WriteLine("Please provide a name for the list: ");
						string name = Console.ReadLine();
						List<Product> l = new List<Product>();
						Console.WriteLine("Please provide a email for the list: ");
						string email = Console.ReadLine();
						Factory.CreateNewList(name, l, email);
						break;
					case "2":
						PrintAllShoppingLists();
						Console.Write("Please type shopping list number: ");
						var shoppingListNumber = Convert.ToInt32(Console.ReadLine());
						while (true)
						{
							Console.Write("Would you like to add a product to your list? y/n. Type r to remove a product: ");
							var response = Console.ReadLine().ToLower();
							if (response == "y")
							{
								ProductAddingQuestionnaire(shoppingListNumber);
							}
							else if (response == "r")
							{
								Factory.PrintProdList(shoppingListNumber);
								Console.Write("What is the ID of the product you with to remove?");
								var productSelectedToRemove = Convert.ToInt32(Console.ReadLine());
								Factory.RemoveProdByID(shoppingListNumber, productSelectedToRemove);
								Console.WriteLine("Product removed succesfully.");
								Factory.PrintProdList(shoppingListNumber);

							}
							else if (response == "n")
							{
								Factory.PrintProdList(shoppingListNumber);
								break;
							}
						}
						break;
					case "3":
						PrintAllShoppingLists();
						break;
					case "4":
						PrintAllShoppingLists();
						Console.WriteLine("What is the ID of the list you wish to see activities for? ");
						var answerId = Convert.ToInt32(Console.Read());
						var filteredList = Factory.GetActivitiesByShoppingListNumber(answerId);
						foreach (var item in filteredList)
						{
							Console.WriteLine($"Activity Type: {item.ActivityID}, Activity Description: {item.ActivityDescription}, Date Created: {item.ActivityDate}");
						}
						break;
					default:
						break;
				}
			}
		}

		private static void ProductAddingQuestionnaire(int shoppingListNumber)
		{
			Console.Write("Product Name: ");
			var Pname = Console.ReadLine();
			Console.Write($"How Many  {Pname} ?");
			var pQuantity = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Product Category?");
			var catname = Enum.GetNames(typeof(PCategory));
			for (int i = 0; i < catname.Length; i++)
			{
				Console.WriteLine($"{i}. {catname[i]}");
			}
			var Pcat = Enum.Parse<PCategory>(Console.ReadLine());

			Console.WriteLine("If you know the price, please type here. (hit Enter to skip): ");
			var answer2 = Console.ReadLine();
			decimal answer1 = 1;
			if (!Decimal.TryParse(answer2, out answer1))
			{
				
				answer2 = "0";
			}
			var Pprice = Convert.ToDecimal(answer2);

			Console.Write("Any notes about the product (hit enter to skip): ");
			var pNotes = Console.ReadLine();

			Product p = Factory.CreateNewProduct(Pname, Pcat, Pprice, pNotes, pQuantity);
			Factory.AddProduct(shoppingListNumber, p);
			Console.WriteLine($"ID: {p.ProductID}, Name: {Pname}, Quantity: {pQuantity}, Category: {Pcat}, Price: {Pprice:C}, Notes: {pNotes}");

		}


		

		private static void PrintAllShoppingLists()
		{
			Console.WriteLine("Your email address?");
			var emailadd = Console.ReadLine();
			var lists = Factory.GetShoppingListsByEmailAddress(emailadd);
			foreach (var sl in lists)
			{
				Console.WriteLine(sl.ShopListName + " | List ID: " + sl.ShopListID);
			}
		}
		


	}
	}

