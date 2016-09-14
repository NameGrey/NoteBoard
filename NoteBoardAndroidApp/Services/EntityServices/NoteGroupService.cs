using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class NoteGroupService: GenericEntityService<NoteGroup>
	{
		public NoteGroupService(IAzureServiceCommunicator azureCommunicator, IJsonTransformer<NoteGroup> jsonTransformer)
			: base(azureCommunicator, jsonTransformer)
		{

		}
	}
}