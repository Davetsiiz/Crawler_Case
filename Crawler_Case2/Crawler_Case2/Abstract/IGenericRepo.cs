namespace Crawler_Case2.Abstract
{
	public interface IGenericRepo<T> where T:class
	{
		void Insert(T t);
		void Delete(int id);
		void Update(T t);

		List<T> GetListAll();
		T GetById(int id);

		
	}
}
