namespace BackendNoteService.DAL.Entities
{
	public class Note: IEntity
	{
		public string Name { get; set; }

		public string GroupName { get; set; }

		public NoteGroup NoteGroup { get; set; }
	}
}
