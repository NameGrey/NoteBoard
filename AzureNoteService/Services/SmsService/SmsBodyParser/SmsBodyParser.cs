
namespace AzureNoteService.Services.SmsService.SmsBodyParser
{
	public class SmsBodyParser:ISmsBodyParser
	{
		public ParsedBody ParseMessage(string message)
		{
			// For now we don't implement any complex logic here. Consider the message contains only name of group
			return new ParsedBody() {GroupName = message};
		}
	}
}