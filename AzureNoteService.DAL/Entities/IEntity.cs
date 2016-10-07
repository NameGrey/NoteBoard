namespace AzureNoteService.DAL.Entities
{
	public interface IEntity
	{
		int Id { get; set; }

		string Name { get; set; }
	}
}
