using System.Collections.Generic;

namespace BackendNoteService.Services.SmsService.SmsBodyFormer
{
	public interface ISmsBodyFormer<T>
	{
		string CreateSmsBody(IEnumerable<T> entities);
	}
}
