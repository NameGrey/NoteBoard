using System.Collections.Generic;

namespace AzureNoteService.Repository
{
	public interface IRepository<T>
	{
		T GetByID(int id);

		IEnumerable<T> GetCollection();
		void Insert(T item);

		void Delete(int id);

		void Update(T pet);
	}
}
