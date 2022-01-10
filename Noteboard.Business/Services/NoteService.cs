using System;
using System.Collections.Generic;
using Noteboard.Domain.Models;

namespace Noteboard.Business.Services
{
    public class NoteService:INoteService
    {
        public void AddNote(Note note)
        {
            throw new NotImplementedException();
        }

        public IList<Note> GetNotes()
        {
            return new List<Note>();
        }
    }
}
