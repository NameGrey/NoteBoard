using System.Collections.Generic;

namespace BackendNoteService.Repository
{
	public interface IRepository<T>
	{
		T GetByName(string name);

		IEnumerable<T> GetCollection();
		void Insert(T item);

		void Delete(string name);

		void Update(T pet);

		void SaveChanges();
	}
}
