namespace AzureNoteService.DAL.Entities
{
	public class Note: IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int GroupId { get; set; }

		public NoteGroup NoteGroup { get; set; }
	}
}
