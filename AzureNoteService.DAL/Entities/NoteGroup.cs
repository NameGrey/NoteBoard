namespace AzureNoteService.DAL.Entities
{
	public class NoteGroup: IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
