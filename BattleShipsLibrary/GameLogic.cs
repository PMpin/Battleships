using BattleShipsLibrary.Models;


namespace BattleShipsLibrary
{
	public class GameLogic
	{
		public static void MakeGrid(PlayerModel player)
		{


			List<string> gridLetters = new List<string>()
			{
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"I",
				"J"
			};

			List<int> gridNumbers = new List<int>()
			{
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9,
				10
			};


			foreach (var gridLetter in gridLetters)
			{
				foreach (var gridNumber in gridNumbers)
				{
					GridModel spot = new GridModel();
					spot.GridLetter = gridLetter;
					spot.GridNumber = gridNumber;
					spot.Status = GridStatus.Empty;

					player.Grid.Add(spot);
				}
			}
		}

		public static bool ValidateShipSelectionLocation(PlayerModel player, Choice choice, int shipNumber)
		{
			bool isValid = false;


			int index = 0;
			string selectionLetter = "";
			int j = 0;

			foreach (var grid in player.Grid)
			{
				if (choice.GridLetter == grid.GridLetter && choice.GridNumber == grid.GridNumber)
				{
					index = player.Grid.IndexOf(grid);

					selectionLetter = grid.GridLetter;

				}
			}

			if (choice.Orientation == "V")
			{
				for (int i = 0; i < shipNumber; i++)
				{
					index += 10;
				}
				if (index <= 99)
				{
					isValid = true;
				}
			}
			else if (choice.Orientation == "H" && player.Grid[index].GridNumber <= 10 - (shipNumber - 1))
			{
				isValid = true;
			}


			return isValid;
		}


		public static bool ValidShot(PlayerModel player, string selection)
		{
			bool isValid = false;
			(string letter, int number) = SplitIt(selection);
			foreach (var spot in player.Grid)
			{
				if (letter.ToUpper() == spot.GridLetter && number == spot.GridNumber)
				{
					isValid = true;

				}
			}

			return isValid;
		}


		public static (string letter, int number) SplitIt(string shipLocation)
		{
			string stringNumber = shipLocation.Substring(1);
			int shipNumber = ParsingInt(stringNumber);
			char[] shipArray = shipLocation.ToArray();

			string shipLetter = shipArray[0].ToString();


			return (shipLetter, shipNumber);
		}

		private static int ParsingInt(string stringNumber)
		{
			int.TryParse(stringNumber, out int result);
			return result;
		}

		public static bool IsSpotFree(PlayerModel player, Choice choice, int shipSize)
		{
			bool isEmtpy = true;

			int index = GameLogic.GetIndex(player, choice.GridLetter, choice.GridNumber);

			if (choice.Orientation == "V")
			{
				for (int i = 0; i < shipSize; i++)
				{
					if (player.Grid[index].Status == GridStatus.Ship)
					{
						isEmtpy = false;
					}
					if (index <= 89)
					{
						index += 10;
					}

				}

			}
			else if (choice.Orientation == "H" && player.Grid[index].GridNumber <= 10 - (shipSize - 1))
			{
				for (int i = 0; i < shipSize; i++)
				{
					if (player.Grid[index + i].Status == GridStatus.Ship)
					{
						isEmtpy = false;
					}
				}
			}

			return isEmtpy;
		}

		private static void MarkShotOnPlayersGrid(PlayerModel player, Choice choice, bool hit)
		{
			foreach (var grid in player.Grid)
			{
				if (grid.GridLetter == choice.GridLetter.ToUpper() && grid.GridNumber == choice.GridNumber)
				{
					if (hit)
					{
						grid.Status = GridStatus.Hit;
					}
					else
					{
						grid.Status = GridStatus.Miss;
					}
				}
			}
		}

		public static bool StillActive(PlayerModel computer)
		{
			bool active = false;

			foreach (var ship in computer.ShipLocation)
			{
				if (ship.Status != GridStatus.Sunk)
				{
					active = true;
				}
			}

			return active;
		}



		private static int GetIndex(PlayerModel player, string letter, int number)
		{
			int index = 0;
			foreach (var grid in player.Grid)
			{
				if (grid.GridLetter == letter.ToUpper() && grid.GridNumber == number)
				{
					index = player.Grid.IndexOf(grid);
				}
			}

			return index;
		}

		private static bool ShotResult(PlayerModel opponent, Choice choice)
		{
			bool hit = false;

			foreach (var ship in opponent.ShipLocation)
			{
				if (ship.GridLetter == choice.GridLetter.ToUpper() && ship.GridNumber == choice.GridNumber)
				{
					hit = true;
					ship.Status = GridStatus.Sunk;
				}
			}
			return hit;
		}

		public static void RecordShot(PlayerModel player, PlayerModel opponent, Choice choice)
		{
			bool hit = ShotResult(opponent, choice);
			GameLogic.MarkShotOnPlayersGrid(player, choice, hit);
		}


		public static bool ValidateOrientation(string orientation)
		{
			bool output = false;

			if (orientation.ToUpper() == "H" || orientation.ToUpper() == "V")
			{
				output = true;
			}

			return output;
		}


		public static void PlacingShips(PlayerModel player, Choice choice, int shipNumber)
		{

			int j = 0;

			int index = GameLogic.GetIndex(player, choice.GridLetter, choice.GridNumber);

			if (choice.Orientation == "V")
			{
				for (int i = 0; i < shipNumber; i++)
				{
					if (index <= 99)
					{
						PlaceShip(player, index);
					}

					if (index <= 89)
					{
						index += 10;
					}



				}
			}
			else if (choice.Orientation == "H" && player.Grid[index].GridNumber <= 10 - (shipNumber - 1))
			{
				do
				{
					PlaceShip(player, index, j);

					if (index <= 98)
					{
						j++;
					}

				} while (choice.GridLetter == player.Grid[index + j].GridLetter && j < shipNumber);
			}

		}

		private static void PlaceShip(PlayerModel player, int index, int j = 0)
		{

			player.ShipLocation.Add(new GridModel()
			{
				GridLetter = player.Grid[index + j].GridLetter,
				GridNumber = player.Grid[index + j].GridNumber,
				Status = GridStatus.Ship,

			});
			player.Grid[index + j].Status = GridStatus.Ship;
		}

	}


}
