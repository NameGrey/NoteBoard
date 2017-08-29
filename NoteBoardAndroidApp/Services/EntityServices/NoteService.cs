using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.BackendServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class NoteService: GenericEntityService<Note>
	{
		public NoteService(IBackendServiceCommunicator backendService, IJsonTransformer<Note> jsonTransformer)
			: base(backendService, jsonTransformer)
		{

		}
	}
}