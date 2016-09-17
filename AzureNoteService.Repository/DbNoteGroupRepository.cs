using System.Data.Entity;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.Repository
{
	public class DbNoteGroupRepository: GenericRepository<NoteGroup>
	{
		public DbNoteGroupRepository(DbContext context) : base(context)
		{
		}
	}
}
