using Mapster;
using Microsoft.AspNetCore.Mvc;
using Noteboard.Business.Services;
using Noteboard.Domain.Models;
using Noteboard.UI.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Noteboard.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var notes = _noteService.GetNotes();

            return View(notes.Adapt<List<NoteViewModel>>());
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody]NoteViewModel noteModel)
        {
            if (noteModel != null)
            {
                var note = noteModel.Adapt<Note>();
                await _noteService.AddNoteAsync(note);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteNote([FromBody] NoteViewModel noteModel)
        {
            if (noteModel != null)
            {
                await _noteService.DeleteNoteAsync(noteModel.Adapt<Note>());
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
