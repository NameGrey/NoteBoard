using System.Collections.Generic;
using System.Data.Entity;
using BackendNoteService.DAL.Entities;

namespace BackendNoteService.DAL
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
			context.NoteGroups.Add(new NoteGroup() {Name = "Дом"});
			context.NoteGroups.Add(new NoteGroup() { Name = "Дача" });

			context.Notes.AddRange(new List<Note>()
			{
				new Note() {GroupName = "Дом", Name = "Молоко"},
				new Note() {GroupName = "Дом", Name = "Хлеб"},
				new Note() {GroupName = "Дом", Name = "Колбаса"},
				new Note() {GroupName = "Дом", Name = "Шоколодку Alpen Gold"},
				new Note() {GroupName = "Дача", Name = "Саморезы"}
			});
		}
	}
}
