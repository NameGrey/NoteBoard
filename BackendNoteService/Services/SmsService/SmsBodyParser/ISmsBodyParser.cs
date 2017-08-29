
namespace BackendNoteService.Services.SmsService.SmsBodyParser
{
	public interface ISmsBodyParser
	{
		ParsedBody ParseMessage(string message);
	}
}
