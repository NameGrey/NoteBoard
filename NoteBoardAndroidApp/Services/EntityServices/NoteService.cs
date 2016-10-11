using AzureNoteService.DAL.Entities;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class NoteService: GenericEntityService<Note>
	{
		public NoteService(IAzureServiceCommunicator azureCommunicator, IJsonTransformer<Note> jsonTransformer)
			: base(azureCommunicator, jsonTransformer)
		{

		}
	}
}