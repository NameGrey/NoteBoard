using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.Repository
{
	public class GenericRepository<T>: IRepository<T> 
		where T: class, IEntity
	{
		private readonly DbContext context;
		private DbSet<T> dbSet;

		public GenericRepository(DbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		public T GetByID(int id)
		{
			return dbSet.Find(id);
		}

		public IEnumerable<T> GetCollection()
		{
			return dbSet.ToList();
		}

		public void Insert(T item)
		{
			dbSet.Add(item);
		}

		public void Delete(int id)
		{
			T entityToDelete = dbSet.Find(id);
			Delete(entityToDelete);
		}

		private void Delete(T entityToDelete)
		{
			var local = context.Set<T>().Local.FirstOrDefault(x => x.Id == entityToDelete.Id);
			if (local != null)
				context.Entry(local).State = EntityState.Detached;


			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}

		public void Update(T pet)
		{
			var local = context.Set<NoteGroup>().Local.FirstOrDefault(x => x.Id == pet.Id);
			if (local != null)
				context.Entry(local).State = EntityState.Detached;

			dbSet.Attach(pet);
			context.Entry(pet).State = EntityState.Modified;
		}
	}
}
