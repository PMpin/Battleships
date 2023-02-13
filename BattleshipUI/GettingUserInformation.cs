using BattleShipsLibrary;
using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
	public class GettingUserInformation
	{
		private static void GetUserName(PlayerModel player)
		{
			Console.Write("Type your user name: ");
			player.UserName = Console.ReadLine();
			Console.WriteLine();
		}

		private static void GetShipLocation(PlayerModel player)
		{

			int shipNumber = 5;
			do
			{
				MsgUser.PrintBoardWithShips(player);
				Console.Write($"Select where you want your ship that takes {shipNumber} spots : ");
				string shipLocation = Console.ReadLine();

				string shipOrientation = ShipOrientation();
				(string letter, int number) = GameLogic.SplitIt(shipLocation);
				Choice choice = new Choice()
				{
					GridLetter = letter.ToUpper(),
					GridNumber = number,
					Orientation = shipOrientation.ToUpper(),
				};
				if (GameLogic.ValidateShipSelectionLocation(player, choice, shipNumber) && GameLogic.IsSpotFree(player, choice, shipNumber))
				{

					GameLogic.PlacingShips(player, choice, shipNumber);
					shipNumber = shipNumber - 1;
					Console.WriteLine("*********************************************");
					Console.WriteLine("****       Ship placed succesfully       ****");
					Console.WriteLine("*********************************************");
				}
				else
				{
					Console.WriteLine("*********************************************");
					Console.WriteLine("****   Invalid ship selection location   ****");
					Console.WriteLine("*********************************************");
				}




			} while (shipNumber != 1);




		}

		private static string ShipOrientation()
		{
			string shipOrientation = "";
			do
			{
				Console.Write("Do you want your ship to be horizontal (H) or vertical (V): ");
				shipOrientation = Console.ReadLine();
			} while (!GameLogic.ValidateOrientation(shipOrientation));


			return shipOrientation;
		}



		public static (string letter, int number) AskForShot(PlayerModel player)
		{
			string shot = "";
			do
			{
				Console.Write("Type grid you want to shoot: ");
				shot = Console.ReadLine();

			} while (!GameLogic.ValidShot(player, shot));
			(string letter, int number) = GameLogic.SplitIt(shot);

			return (letter, number);
		}


		public static PlayerModel CreatePlayer()
		{
			PlayerModel player = new PlayerModel();
			GameLogic.MakeGrid(player);
			GetUserName(player);
			GetShipLocation(player);
			return player;
		}


	}
}
