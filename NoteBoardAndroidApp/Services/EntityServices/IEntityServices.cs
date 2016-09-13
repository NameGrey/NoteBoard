using System.Collections.Generic;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public interface IEntityServices<T>
	{
		T GetEntityById(int id);
		IEnumerable<T> GetCollection();
		void Add(T entity);
		void Remove(int id);
	}
}