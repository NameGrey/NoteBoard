using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;
using AzureNoteService.Services.SmsService.SmsBodyFormer;
using AzureNoteService.Services.SmsService.SmsBodyParser;

namespace AzureNoteService.Services.SmsService
{
	public class SmsService: ISmsService
	{
		private IRepository<Note> noteRepository;
		private IRepository<NoteGroup> groupRepository;
		private ISmsBodyParser smsBodyParser;
		private ISmsBodyFormer<Note> noteSmsBodyFormer; 

		//TODO:It's better to inject all the repositories via constructor. Do that in Future when it will be applied DI container
		public SmsService(IRepository<Note> noteRepository, IRepository<NoteGroup> groupRepository)
		{
			this.noteRepository = noteRepository;
			this.groupRepository = groupRepository;
			this.smsBodyParser = new SmsBodyParser.SmsBodyParser();
			this.noteSmsBodyFormer = new NotesSmsBodyFormer();
		}

		public void SmsRecieved(string textBody)
		{
			ParsedBody parsedMessage = smsBodyParser.ParseMessage(textBody);

			if (parsedMessage != null && !String.IsNullOrEmpty(parsedMessage.GroupName))
			{
				IEnumerable<Note> notes = noteRepository.GetCollection().Where(i => i.GroupName == parsedMessage.GroupName);
				if (notes.Any())
				{
					SendSms(noteSmsBodyFormer.CreateSmsBody(notes));
				}
				else
				{
					SendSms("List is empty!");
				}
			}
		}

		public void SendSms(string textBody)
		{
			string formatRequest =
				String.Format(
					"http://smspilot.ru/api.php?send={0}&to=79209567670&apikey=PE091LK3OPG3D038A6E49PCV415LXRS25S4A0SO7964C5RG9U57610V7SF4OB21D",
					textBody);

			var request = (HttpWebRequest)WebRequest.Create(formatRequest);
			request.GetResponse();
		}
	}
}