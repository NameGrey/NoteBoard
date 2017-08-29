using System.Data.Entity;
using BackendNoteService.DAL.Entities;

namespace BackendNoteService.Repository
{
	public class DbNoteGroupRepository: GenericRepository<NoteGroup>
	{
		public DbNoteGroupRepository(DbContext context) : base(context)
		{
		}
	}
}
