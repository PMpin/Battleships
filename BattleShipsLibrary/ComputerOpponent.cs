using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary
{
	public class ComputerOpponent
	{
		public static (string letter, int number) GetRandomLetterAndNumber()
		{
			Random random = new Random();
			int number = 0;
			int randomIndex = 0;
			char charLetter;
			string letter;
			string letterSelection = "ABCDEFGHIJ";

			randomIndex = random.Next(0, letterSelection.Length);
			number = random.Next(1, 9);
			charLetter = letterSelection[randomIndex];
			letter = charLetter.ToString();

			return (letter, number);
		}

		private static string GetRandomOrientation()
		{
			string orientation = "";
			Random random = new Random();
			int index = random.Next(0, 1);
			string orientationSelection = "VH";
			char charOrientation = orientationSelection[index];
			orientation = charOrientation.ToString();

			return orientation;
		}

		private static void PlaceComputerShips(PlayerModel computer)
		{
			int shipSize = 5;

			do
			{
				(string letter , int number) = GetRandomLetterAndNumber();
				string orientation = GetRandomOrientation();

				Choice choice = new Choice()
				{
					GridLetter= letter,
					GridNumber = number,
					Orientation = orientation,
				};
				if (GameLogic.ValidateShipSelectionLocation(computer, choice, shipSize) && GameLogic.IsSpotFree(computer, choice, shipSize))
				{
					GameLogic.PlacingShips(computer, choice, shipSize);
					shipSize = shipSize - 1;
				}
			} while (shipSize != 1);
		}

		public static PlayerModel CreateComputer()
		{
			PlayerModel computer = new PlayerModel();
			GameLogic.MakeGrid(computer);
			computer.UserName = "Computer";
			PlaceComputerShips(computer);
			return computer;
		}
	}
}
