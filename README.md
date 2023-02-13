# Description

Battleship console game that you play against a computer which places and guesses based on **random number generation** without any algorithm.

# Grid
It does not let you place ships on top of each other or take a shot at the same grid more than once.
#
Grid before placing anything.

![VsDebugConsole_DEwliFRHii](https://user-images.githubusercontent.com/118499440/218410068-38998652-3795-4665-8ba9-b3c30cc9f89f.png)
#
Grid while placing ships.

![VsDebugConsole_bI1ccaZgvi](https://user-images.githubusercontent.com/118499440/218411905-e726c95f-b05d-4b0d-b114-e7e479484bdd.png)
#
Grid while shooting at your opponent's grid.

![VsDebugConsole_HB6vAOTk6E](https://user-images.githubusercontent.com/118499440/218415787-5422f9e7-05f2-438e-986d-e4b9eb0360fe.png)


# Determining winner

Winner is determined when all the ships from the opponent's grid are marked as sunk.
```C#
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
   
