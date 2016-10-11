using System;
using System.Collections.Generic;
using System.Web.Http;
using AzureNoteService.DAL;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;

namespace AzureNoteService.Controllers
{
	[RoutePrefix("api/notes")]
	public class NoteController : ApiController
	{
		private IRepository<Note> noteRepository;

		public NoteController()
		{
			var context = new DatabaseContext();
			context.Database.Connection.Open();
			noteRepository = new DbNoteRepository(context);
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<Note> GetCollection()
		{
			return noteRepository.GetCollection();
		}

		[HttpGet]
		[Route("{name}")]
		public Note GetById(string name)
		{
			return noteRepository.GetByName(name);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Insertnote(Note note)
		{
			try
			{
				noteRepository.Insert(note);
				return Ok();
			}
			catch (Exception)
			{
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
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
