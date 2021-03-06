﻿using System.Data.Entity;
using BackendNoteService.DAL.Entities;

namespace BackendNoteService.DAL
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
				.HasForeignKey(i => i.GroupName);

			modelBuilder.Entity<Note>()
				.HasKey(i => i.Name);

			modelBuilder.Entity<NoteGroup>()
				.HasKey(i => i.Name);
		}
	}
}
