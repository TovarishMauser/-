using System;

namespace CortegeApp
{
    class Program
    {
		static void Main(string[] args)
        {			
			var User = GetUser();
			Console.Write("Имя - ");
			Console.WriteLine(User.Name);
			Console.Write("Фамилия - ");
			Console.WriteLine(User.LastName);
			Console.Write("Возраст - ");
			Console.WriteLine(User.Age);
			
			PetsOutput(User.Pets);
			ColorsOutput(User.favcolors);
		}
		
		static bool CheckNum(string number, out int corNumber)
		{
			if (int.TryParse(number, out int intnum))
			{
				if (intnum > 0)
				{
					corNumber = intnum;
					return true;
				}
			}
			{
				corNumber = 0;
				return false;
			}

		}

		static void PetsOutput(string[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write("Питомец № {0}", i);
				Console.WriteLine(array[i]);
			}
		}
		static void ColorsOutput(string[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write("Любимый цвет {0} ", i);
				Console.WriteLine(array[i]);
			}
		}
		static void CheckUserInput(out string result)
		{			
			do
			{
				string input = Console.ReadLine();
				if (input != "")
				{
					result = input;
					break;
				}
				else {
					Console.WriteLine("Введены неверные данные!");
					Console.WriteLine("Попробуйте снова - ");
				}
			} while (true);
		}												//for name and LN
		static void CheckUserNumber(out int result)														//for age
		{
			do
			{
				string input = Console.ReadLine();
				if (CheckNum(input,  out int num))
				{
					result = num;
					break;
				}
				else
				{
					Console.WriteLine("Введены неверные данные!");
					Console.WriteLine("Попробуйте снова - ");
				}
			} while (true);
		}								
		static (string Name, string LastName, string[] Pets, string[] favcolors, int Age) GetUser()
		{
			(string Name, string LastName, string[] Pets, string[] favcolors, int Age) User;
			
			Console.WriteLine("Введите имя - ");
			CheckUserInput(out User.Name);			
			Console.WriteLine("Введите фамилию - ");			
			CheckUserInput(out User.LastName);			
			Console.WriteLine("Введите возраст - ");
			CheckUserNumber(out User.Age);
			
			Console.WriteLine("У вас есть питомец(ы)?  (Y/N)");

			string check = Console.ReadLine();

			if ((check == "Y") || (check == "y"))
			{
				Console.WriteLine("введите количество петов");
				int numPet;
				CheckUserNumber(out numPet);
				User.Pets = new string[numPet];
				for (int i = 0; i < numPet; i++)
				{
					string thatPet;
					Console.WriteLine("Введите кличку {0} пета - ", i);
					CheckUserInput(out thatPet);
					User.Pets[i] = thatPet;
				}
			}
			else { User.Pets = new string[0]; }
			
			Console.WriteLine("Введите количество любимых цветов - ");
			int colorNum;
			CheckUserNumber(out colorNum);
			User.favcolors = new string[colorNum];
			for (int i = 0; i < colorNum; i++)
			{
				string thatColor;
				Console.WriteLine("Введите любимый цвет {0} - ", i);
				CheckUserInput(out thatColor);
				User.favcolors[i] = thatColor;
			}
			return User;
		}		
    }
}
