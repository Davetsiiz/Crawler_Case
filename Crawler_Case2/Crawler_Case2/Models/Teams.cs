using System.ComponentModel.DataAnnotations;

namespace Crawler_Case2.Models
{
	public class Teams
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public string Coach { get; set; }
		public virtual ICollection<Player> Player { get; set; }
	}
}
