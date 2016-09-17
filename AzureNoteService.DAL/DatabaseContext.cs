using System.Data.Entity;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.DAL
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Note> Notes { get; set; }
		public DbSet<NoteGroup> NoteGroups { get; set; }

		public DatabaseContext()
			: base("NoteBoardDb")
		{
			Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>()
				.HasRequired(i => i.NoteGroup)
				.WithMany()
				.HasForeignKey(i => i.GroupId);
		}
	}
}
