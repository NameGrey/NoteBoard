using System.Collections.Generic;

namespace AzureNoteService.Services.SmsService.SmsBodyFormer
{
	public interface ISmsBodyFormer<T>
	{
		string CreateSmsBody(IEnumerable<T> entities);
	}
}
