using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Models
{
	public class GridModel : GridBase
	{

		public GridStatus Status { get; set; } = GridStatus.Empty;
	}
}
