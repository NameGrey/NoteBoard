using Azure.Data.Tables;
using Noteboard.DataAccess.Azure.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Noteboard.DataAccess.Azure.Storage
{
    public class TableStorageManager<T>: ITableStorageManager<T> where T: NoteTableEntity, new()
    {
        private readonly IOptions<StorageTableOptions> _settings;

        public TableStorageManager(IOptions<StorageTableOptions> settings)
        {
            _settings = settings;
        }

        public IList<T> Retrieve(string noteboardId)
        {
            var client = GetTableClient();
            //TODO: investigate how to query asynchronously
            var iterator = (client.Query<NoteTableEntity>(filter: $"PartitionKey eq '{noteboardId}'"));

            return (IList<T>)iterator.ToList();
        }

        public async Task<T> InsertOrMergeAsync(T entity)
        {
            var client = GetTableClient();
            var allNotes = Retrieve(entity.PartitionKey);
            var existingNote = allNotes.FirstOrDefault(note => note.Text.Equals(entity.Text, StringComparison.InvariantCultureIgnoreCase));

            if (existingNote != null)
            {
                return existingNote;
            }

            await client.AddEntityAsync<T>(entity);

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var client = GetTableClient();
            await client.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);

            return entity;
        }

        //TODO: implement Singleton pattern for TableClient
        private TableClient GetTableClient()
        {
            var credentials = new TableSharedKeyCredential(_settings.Value.AccountName, _settings.Value.AccountKey);
            var tableClient = new TableClient(new Uri(_settings.Value.TableUrl), _settings.Value.TableName, credentials);

            return tableClient;
        }
    }
}
