using System;
using System.Collections.Generic;
using System.Web.Http;
using AzureNoteService.DAL;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;
using log4net;
using System.Data.SqlClient;

namespace AzureNoteService.Controllers
{
	[RoutePrefix("api/noteGroups")]
	public class NoteGroupController : ApiController
	{
		public readonly ILog logger = LogManager.GetLogger("NoteGroupControllerLogger");
		private readonly IRepository<NoteGroup> noteGroupRepository;

		public NoteGroupController()
		{
			try
			{
				var context = new DatabaseContext();
				context.Database.Connection.Open();
				noteGroupRepository = new DbNoteGroupRepository(context);
			}
			catch (SqlException ex)
			{
				logger.ErrorFormat("<NoteGroup repository initialization> : {0} - {1}", ex.Message, ex.StackTrace);
			}
		}

		[HttpGet]
		[Route("")]
		public IEnumerable<NoteGroup> GetCollection()
		{
			IEnumerable<NoteGroup> collection = null;

			try
			{
				collection = noteGroupRepository.GetCollection();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<NoteGroup Controller GetCollection> : {0} - {1}", ex.Message, ex.StackTrace);
			}

			return collection;
		}

		[HttpGet]
		[Route("{name}")]
		public NoteGroup GetByName(string name)
		{
			NoteGroup noteGroup = null;

			try
			{
				noteGroup = noteGroupRepository.GetByName(name);
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<Note Repository GetById> : {0} - {1}", ex.Message, ex.StackTrace);
			}

			return noteGroup;
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Insertnote(NoteGroup noteGroup)
		{
			try
			{
				noteGroupRepository.Insert(noteGroup);
				noteGroupRepository.SaveChanges();
				logger.InfoFormat("<NoteGroup Controller Insert noteGroup> : {0}", "NoteGroup inserted");
				return Ok();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<NoteGroup Controller Insert noteGroup> : {0} - {1}", ex.Message, ex.StackTrace);
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
				noteGroupRepository.SaveChanges();
				logger.InfoFormat("<NoteGroup Controller Insert noteGroup> : {0}", "NoteGroup deleted");
				return Ok();
			}
			catch (Exception ex)
			{
				logger.ErrorFormat("<NoteGroup Controller Delete noteGroup> : {0} - {1}", ex.Message, ex.StackTrace);
				return InternalServerError();
			}
		}
	}
}
