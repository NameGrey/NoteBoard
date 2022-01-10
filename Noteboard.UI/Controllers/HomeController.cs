using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Noteboard.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Noteboard.Business;
using Noteboard.Business.Services;
using Noteboard.Domain.Models;

namespace Noteboard.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteService _noteService;

        public HomeController(ILogger<HomeController> logger, INoteService noteService)
        {
            _logger = logger;
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var notes = _noteService.GetNotes();
            notes = new List<Note>() { new Note() { Text = "Bread" }, new Note() { Text = "Milk" } };

            return View(notes.Adapt<List<NoteViewModel>>());
        }

        [HttpPost]
        public IActionResult AddNote([FromBody]NoteViewModel noteModel)
        {
            if (noteModel != null)
            {
                var note = noteModel.Adapt<Note>();
                _noteService.AddNote(note);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
