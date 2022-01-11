namespace Noteboard.DataAccess.Azure.Storage
{
    public class StorageTableOptions
    {
        public string TableName { get; set; }
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string TableUrl { get; set; }
    }
}
