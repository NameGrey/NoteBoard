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

		public T GetByName(string name)
		{
			return dbSet.Find(name);
		}

		public IEnumerable<T> GetCollection()
		{
			return dbSet.ToList();
		}

		public void Insert(T item)
		{
			dbSet.Add(item);
		}

		public void Delete(string name)
		{
			T entityToDelete = dbSet.First(i => i.Name == name);
			Delete(entityToDelete);
		}

		private void Delete(T entityToDelete)
		{
			var local = context.Set<T>().Local.FirstOrDefault(x => x.Name == entityToDelete.Name);
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
			var local = context.Set<NoteGroup>().Local.FirstOrDefault(x => x.Name == pet.Name);
			if (local != null)
				context.Entry(local).State = EntityState.Detached;

			dbSet.Attach(pet);
			context.Entry(pet).State = EntityState.Modified;
		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}
