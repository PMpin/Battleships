using BattleShipsLibrary;
using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
	public class MsgUser
	{
		public static void PrintBoardWithShips(PlayerModel player)
		{
			string currentRow = player.Grid[0].GridLetter;
			foreach (var gridSpot in player.Grid)
			{


				if (gridSpot.GridLetter != currentRow)
				{
					Console.WriteLine();
					currentRow = gridSpot.GridLetter;
				}

				


				if (gridSpot.Status == GridStatus.Empty)
				{
					Console.Write($" {gridSpot.GridLetter}{gridSpot.GridNumber} ");
				}
				else if (gridSpot.Status == GridStatus.Miss)
				{
					Console.Write(" 0  ");
				}
				else if (gridSpot.Status == GridStatus.Hit)
				{
					Console.Write(" X  ");
				}
				else if (gridSpot.Status == GridStatus.Ship)
				{
					Console.Write(" __ ");
				}


				
				



			}



			Console.WriteLine();
			Console.WriteLine();
		}

		internal static void WinenrIdentity(PlayerModel winner)
		{
			Console.WriteLine();
			Console.WriteLine($"Winner is {winner.UserName}");
			Console.WriteLine();
		}

		public static void PrintBoard(PlayerModel player)
		{
			string currentRow = player.Grid[0].GridLetter;
			foreach (var gridSpot in player.Grid)
			{


				if (gridSpot.GridLetter != currentRow)
				{
					Console.WriteLine();
					currentRow = gridSpot.GridLetter;
				}




				if (gridSpot.Status == GridStatus.Empty)
				{
					Console.Write($" {gridSpot.GridLetter}{gridSpot.GridNumber} ");
				}
				else if (gridSpot.Status == GridStatus.Miss)
				{
					Console.Write(" 0  ");
				}
				else if (gridSpot.Status == GridStatus.Hit)
				{
					Console.Write(" X  ");
				}
				else if (gridSpot.Status == GridStatus.Ship)
				{
					Console.Write($" {gridSpot.GridLetter}{gridSpot.GridNumber} ");
				}









			}



			Console.WriteLine();
			Console.WriteLine();
		}

		public static void WelcomeMsg()
		{
			Console.WriteLine("Welcome to a Battleship game");
			Console.WriteLine();
			Console.WriteLine();
		}

	}
}
