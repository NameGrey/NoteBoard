using System.Data.Entity;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.Repository
{
	public class DbNoteRepository: GenericRepository<Note>
	{
		public DbNoteRepository(DbContext context) : base(context)
		{
		}
	}
}
