using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using Crawler_Case2.Models;
using Microsoft.EntityFrameworkCore;

namespace Crawler_Case2.Concrete
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("Data Source=Eren;Initial Catalog=Futbolig_Crawler;Integrated Security=True; TrustServerCertificate=True");
			optionsBuilder.UseSqlServer("Data Source =104.247.162.242\\MSSQLSERVER2019; Initial Catalog = emremura_Crawler; user = emremura_Crawler; password = Crawler.123;TrustServerCertificate=True");
			
		}
		public DbSet<Teams> Teams { get; set; }
		public DbSet<Player> PlayerS { get; set; }
	}
}
