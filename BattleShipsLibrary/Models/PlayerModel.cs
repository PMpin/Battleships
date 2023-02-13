

namespace BattleShipsLibrary.Models
{
	public class PlayerModel
	{
		public string UserName { get; set; }
		public List<GridModel> ShipLocation { get; set; } = new List<GridModel>();
		public List<GridModel> Grid { get; set; } = new List<GridModel>();
	}
}
