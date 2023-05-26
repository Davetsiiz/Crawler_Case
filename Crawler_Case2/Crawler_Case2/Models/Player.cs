using System.ComponentModel.DataAnnotations;

namespace Crawler_Case2.Models
{
	public class Player
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public  string Photo { get; set; }
		public int Age { get; set; }
		public int TeamId { get; set; }
		public virtual Teams Team { get; set; }
	}
}
