using System;
using Mapster;
using Noteboard.DataAccess.Azure.Storage;
using Noteboard.DataAccess.Azure.Storage.Models;
using Noteboard.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noteboard.Business.Services
{
    public class NoteService: INoteService
    {
        private readonly ITableStorageManager<NoteTableEntity> _tableStorageManager;

        public NoteService(ITableStorageManager<NoteTableEntity> tableStorageManager)
        {
            _tableStorageManager = tableStorageManager;
        }

        public async Task AddNoteAsync(Note note)
        {
            await _tableStorageManager.InsertOrMergeAsync(note.Adapt<NoteTableEntity>());
        }

        public IList<Note> GetNotes()
        {
            return _tableStorageManager.Retrieve(BusinessConstants.NoteBoardId).Adapt<IList<Note>>();
        }

        public async Task DeleteNoteAsync(Note note)
        {
            var existingNote = _tableStorageManager.Retrieve(BusinessConstants.NoteBoardId).FirstOrDefault(i => i.Text.Equals(note.Text, StringComparison.InvariantCultureIgnoreCase));

            if (existingNote != null)
            {
                await _tableStorageManager.DeleteAsync(existingNote);

            }
        }
    }
}
