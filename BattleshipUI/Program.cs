using BattleShipsLibrary;
using BattleShipsLibrary.Models;
using System.Data.Common;

namespace Battleships
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MsgUser.WelcomeMsg();

			PlayerModel player = GettingUserInformation.CreatePlayer();
			PlayerModel computer = ComputerOpponent.CreateComputer();
			PlayerModel winner = null;


			do
			{
				(string letter , int number) = GettingUserInformation.AskForShot(player);
				Choice choice = new Choice()
				{
					GridLetter= letter ,
					GridNumber= number ,
				};
				GameLogic.RecordShot(player,computer,choice);
				bool gameContinues = GameLogic.StillActive(computer);
				MsgUser.PrintBoard(player);
				if (gameContinues)
				{
					(string cLetter, int cNumber) = ComputerOpponent.GetRandomLetterAndNumber();
					choice.GridLetter = cLetter;
					choice.GridNumber = cNumber;

					
					GameLogic.RecordShot(computer, player, choice);
					
				}
				else
				{
					winner = player;
				}

				gameContinues = GameLogic.StillActive(player);

				if (!gameContinues)
				{
					winner = computer;
				}

			} while (winner == null);


			MsgUser.WinenrIdentity(winner);
			MsgUser.PrintBoard(computer);
		}
	}
}