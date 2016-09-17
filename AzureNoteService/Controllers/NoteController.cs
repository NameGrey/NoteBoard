using System.Linq;
using System.Web.Http;
using AzureNoteService.DAL;
using AzureNoteService.DAL.Entities;
using AzureNoteService.Repository;

namespace AzureNoteService.Controllers
{
	[RoutePrefix("api")]
	public class NoteController : ApiController
	{
		private IRepository<Note> noteRepository;

		public NoteController()
		{
			var context = new DatabaseContext();
			context.Database.Connection.Open();
			noteRepository = new DbNoteRepository(context);
		}

		[Route("notes")]
		public string GetCollection()
		{
			var notes = noteRepository.GetCollection();

			return "Hello World! There are several notes - " + notes.Count();
		}

	}
}
