using Azure;
using Azure.Data.Tables;

namespace Karus.Data.AzureStorageTables.Entities;

#nullable disable

public abstract class BaseEntity : ITableEntity
{
    public string PartitionKey { get; set; }

    public string RowKey { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public ETag ETag { get; set; }

    public int SortNumber { get; set; } = 100;

    public bool IsInVisible { get; set; }

    public DateTime Added { get; set; }

    public DateTime? Modified { get; set; }
}