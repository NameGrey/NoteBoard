
using System;

namespace AzureNoteService.Services.SmsService.SmsBodyParser
{
	public class SmsBodyParser:ISmsBodyParser
	{
		public ParsedBody ParseMessage(string message)
		{
			// cut special number of Sms service
			message = message.Substring(6);
			return new ParsedBody() {GroupName = message};
		}
	}
}