using Crawler_Case2.Models;

namespace Crawler_Case2.Abstract
{
	public interface IPlayerRepo:IGenericRepo<Player>
	{
        List<Player> GetPlayerByTeam(int id);
    }
}
