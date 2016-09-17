using System.Collections.Generic;
using System.Data.Entity;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.DAL
{
	public class DatabaseInitializer: CreateDatabaseIfNotExists<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			FillTestData(context);
			base.Seed(context);
		}

		private void FillTestData(DatabaseContext context)
		{
			context.NoteGroups.Add(new NoteGroup() {Id = 1, Name = "Дом"});
			context.NoteGroups.Add(new NoteGroup() { Id = 2, Name = "Дача" });

			context.Notes.AddRange(new List<Note>()
			{
				new Note() {GroupId = 1, Id = 1, Name = "Молоко"},
				new Note() {GroupId = 1, Id = 2, Name = "Хлеб"},
				new Note() {GroupId = 1, Id = 3, Name = "Колбаса"},
				new Note() {GroupId = 1, Id = 4, Name = "Шоколодку Alpen Gold"}
			});
		}
	}
}
