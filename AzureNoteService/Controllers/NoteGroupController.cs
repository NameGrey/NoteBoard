using System;
using System.Collections.Generic;
using System.Web.Http;
using AzureNoteService.DAL;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;

namespace AzureNoteService.Controllers
{
	[RoutePrefix("api/noteGroups")]
	public class NoteGroupController : ApiController
	{
		private readonly IRepository<NoteGroup> noteGroupRepository;

		public NoteGroupController()
		{
			var context = new DatabaseContext();
			context.Database.Connection.Open();
			noteGroupRepository = new DbNoteGroupRepository(context);
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<NoteGroup> GetCollection()
		{
			return noteGroupRepository.GetCollection();
		}

		[HttpGet]
		[Route("{name}")]
		public NoteGroup GetByName(string name)
		{
			return noteGroupRepository.GetByName(name);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Insertnote(NoteGroup noteGroup)
		{
			try
			{
				noteGroupRepository.Insert(noteGroup);
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}

		[HttpDelete]
		[Route("")]
		public IHttpActionResult DeleteNoteGroup(string name)
		{
			try
			{
				noteGroupRepository.Delete(name);
				return Ok();
			}
			catch (Exception)
			{
				return InternalServerError();
			}
		}
	}
}
