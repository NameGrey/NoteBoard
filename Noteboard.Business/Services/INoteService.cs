using System.Collections.Generic;
using System.Threading.Tasks;
using Noteboard.Domain.Models;

namespace Noteboard.Business.Services
{
    public interface INoteService
    {
        Task AddNoteAsync(Note note);
        IList<Note> GetNotes();
        Task DeleteNoteAsync(Note note);
    }
}
