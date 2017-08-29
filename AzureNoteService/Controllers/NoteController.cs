using System;
using System.Collections.Generic;
using System.Web.Http;
using AzureNoteService.DAL;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;
using log4net;

namespace AzureNoteService.Controllers
{ 
	[RoutePrefix("api/notes")]
	public class NoteController : ApiController
	{
		public readonly ILog logger = LogManager.GetLogger("NoteControllerLogger");
		private IRepository<Note> noteRepository;

		public NoteController()
		{
			try
			{
				var context = new DatabaseContext();
				context.Database.Connection.Open();
				noteRepository = new DbNoteRepository(context);
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Repository initialization> : {0} - {1}", ex.Message, ex.StackTrace);
			}
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<Note> GetCollection()
		{
			IEnumerable<Note> collection = null;

			try
			{
				collection = noteRepository.GetCollection();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Controller GetCollection> : {0} - {1}", ex.Message, ex.StackTrace);
			}

			return collection;
		}

		[HttpGet]
		[Route("{name}")]
		public Note GetById(string name)
		{
			Note note = null;

			try
			{
				note = noteRepository.GetByName(name);
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Controller GetById> : {0} - {1}", ex.Message, ex.StackTrace);
			}

			return note;
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Insertnote(Note note)
		{
			try
			{
				noteRepository.Insert(note);
				noteRepository.SaveChanges();
				logger.InfoFormat("<Note Controller Insert note> : {0}", "Note inserted");
				return Ok();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Controller Insert note> : {0} - {1}", ex.Message, ex.StackTrace);
				return InternalServerError();
			}
		}

		[HttpDelete]
		[Route("")]
		public IHttpActionResult DeleteNote(string name)
		{
			try
			{
				noteRepository.Delete(name);
				noteRepository.SaveChanges();
				logger.InfoFormat("<Note Controller Delete note> : {0}", "Note deleted");
				return Ok();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Controller Insert note> : {0} - {1}", ex.Message, ex.StackTrace);
				return InternalServerError();
			}
		}
	}
}
