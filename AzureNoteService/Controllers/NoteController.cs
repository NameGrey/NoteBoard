using System;
using System.Collections.Generic;
using System.Linq;
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
		[Route("{id}")]
		public Note GetById(int id)
		{
			return noteRepository.GetByID(id);
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
		public IHttpActionResult DeleteNote(int id)
		{
			try
			{
				noteRepository.Delete(id);
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
