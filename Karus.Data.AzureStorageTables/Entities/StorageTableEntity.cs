using Azure.Data.Tables;
using Azure;

namespace Karus.Data.AzureStorageTables.Entities;

#nullable disable

public class StorageTableEntity<TDomain, TId> : ITableEntity where TDomain : class
{
    public StorageTableEntity(string partitionKey, TId rowKey, TDomain domainObject)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey?.ToString() ?? "default";
        DomainObject = domainObject;
    }

    public TDomain DomainObject { get; set; }

    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }
}
