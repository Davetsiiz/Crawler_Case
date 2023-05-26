using Crawler_Case2.Abstract;
using Crawler_Case2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Crawler_Case2.Concrete
{
	
	public class TeamsRepo : ITeamsRepo
	{
		Context db = new Context();
		public void Delete(int id)
		{
            string qu = "Delete from Teams where ID=@Id";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            db.Database.ExecuteSqlRaw(qu, parameter);
        }

		public Teams GetById(int id)
		{
            return db.Teams.FromSql<Teams>($"Select * from Teams where Id={id}").FirstOrDefault();
        }

		public List<Teams> GetListAll()
		{
			return db.Teams.FromSql<Teams>($"Select Id, Name,Logo, Coach from Teams order by Name").ToList(); 
        }

       

        public void Insert(Teams t)
		{
            string query = $"Insert into Teams (Name, Logo, Coach) values (@Name, @Logo, @Coach)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",t.Name),
                new SqlParameter("@Logo",t.Logo),
                new SqlParameter("@Coach",t.Coach)

            };

            db.Database.ExecuteSqlRaw(query, parameters);
        }

		public void Update(Teams t)
		{
            string qu = "Update Teams set Name=@Name,Logo=@Logo,Coach=@Coach where Id=@Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",t.Id),
                new SqlParameter("@Name",t.Name),
                new SqlParameter("@Logo",t.Logo),
                new SqlParameter("@Coach",t.Coach),
            };
            db.Database.ExecuteSqlRaw(qu, parameters);
        }
	}
}
