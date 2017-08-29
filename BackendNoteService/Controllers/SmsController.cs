using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using BackendNoteService.DAL;
using BackendNoteService.DAL.Entities;
using BackendNoteService.Repository;
using BackendNoteService.Services.SmsService;

namespace BackendNoteService.Controllers
{
	[RoutePrefix("api/sms")]
	public class SmsController : ApiController
	{
		private IRepository<Note> noteRepository;
		private IRepository<NoteGroup> groupNoteRepository;
		private ISmsService smsService;

		public SmsController()
		{
			var context = new DatabaseContext();
			context.Database.Connection.Open();
			noteRepository = new DbNoteRepository(context);
			groupNoteRepository = new DbNoteGroupRepository(context);
			smsService = new SmsService(noteRepository, groupNoteRepository);
		}

		[HttpPost]
		[Route("getNotes")]
		public void ReceiveMessageHandler(FormDataCollection collection)
		{
			string message = collection.GetValues("message").First();
			//string message = String.Empty;

			//if (Request.Content.IsFormData())
			//{
				
			//}

			if (!String.IsNullOrEmpty(message))
			{
				smsService.SmsRecieved(message);
			}
		}
	}
}
