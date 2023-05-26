using Crawler_Case2.Abstract;
using Crawler_Case2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Crawler_Case2.Concrete
{
    public class PlayerRepo : IPlayerRepo
	{

		Context db = new Context();
		public void Delete(int id)
		{
            string qu = "Delete from Player where ID=@Id";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            db.Database.ExecuteSqlRaw(qu, parameter);
        }
    

		public Player GetById(int id)
		{
            return db.PlayerS.FromSql<Player>($"Select * from Player where Id={id}").FirstOrDefault();
        }

		public List<Player> GetListAll()
		{
			//string query = "Select Id,Name,Photo,Age,TeamId from Player order by Name";
            return db.PlayerS.FromSql<Player>($"Select Id,Name,Photo,Age,TeamId from Player order by Name").ToList();
		}

        public void Insert(Player t)
        {
            string query = $"INSERT INTO Player (Name, Age, TeamId, Photo) VALUES (@Name, @Age, @TeamID,@Photo)";
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Name",t.Name),
				new SqlParameter("@Age",t.Age),
				new SqlParameter("@TeamId",t.TeamId),
				new SqlParameter("@Photo",t.Photo)

			};

            db.Database.ExecuteSqlRaw(query,parameters);
        }

        public void Update(Player t)
		{
            string qu = $"Update  Player set Name=@Name, Photo=@Photo, Age=@Age, TeamId=@TeamId where ID=@Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",t.Id),
                new SqlParameter("@Name",t.Name),
                new SqlParameter("@Age",t.Age),
                new SqlParameter("@TeamId",t.TeamId),
                new SqlParameter("@Photo",t.Photo)

            };
            db.Database.ExecuteSqlRaw(qu, parameters);
        }
        public List<Player> GetPlayerByTeam(int id)
        {
            return db.PlayerS.FromSql<Player>($"Select * from Player where TeamId={id}").ToList();
        }
    }
}
