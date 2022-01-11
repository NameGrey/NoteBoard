using Azure;
using Azure.Data.Tables;
using System;

namespace Noteboard.DataAccess.Azure.Storage.Models
{
    public class NoteTableEntity: ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public string Text { get; set; }
    }
}
