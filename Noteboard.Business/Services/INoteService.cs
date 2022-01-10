using System.Collections.Generic;
using Noteboard.Domain.Models;

namespace Noteboard.Business.Services
{
    public interface INoteService
    {
        void AddNote(Note note);
        IList<Note> GetNotes();
    }
}
