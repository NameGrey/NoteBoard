using System.Data.Entity;
using BackendNoteService.DAL.Entities;

namespace BackendNoteService.Repository
{
	public class DbNoteRepository: GenericRepository<Note>
	{
		public DbNoteRepository(DbContext context) : base(context)
		{
		}
	}
}
