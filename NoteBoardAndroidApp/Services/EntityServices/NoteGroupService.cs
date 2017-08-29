using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.BackendServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class NoteGroupService: GenericEntityService<NoteGroup>
	{
		public NoteGroupService(IBackendServiceCommunicator backendService, IJsonTransformer<NoteGroup> jsonTransformer)
			: base(backendService, jsonTransformer)
		{

		}
	}
}