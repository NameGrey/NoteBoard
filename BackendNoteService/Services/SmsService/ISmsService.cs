namespace BackendNoteService.Services.SmsService
{
	public interface ISmsService
	{
		void SmsRecieved(string textBody);
		void SendSms(string textBody);
	}
}
