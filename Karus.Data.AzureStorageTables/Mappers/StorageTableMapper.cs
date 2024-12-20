using Karus.Data.AzureStorageTables.Entities;

namespace Karus.Data.AzureStorageTables.Mappers;

public static class StorageTableMapper
{
    public static StorageTableEntity<T, TId> ToTableEntity<T, TId>(this T domainObject, string partitionKey, TId rowKey) where T : class
    {
        return new StorageTableEntity<T, TId>(partitionKey, rowKey, domainObject);
    }

    public static T ToDomainModel<T, TId>(this StorageTableEntity<T, TId> tableEntity) where T : class
    {
        return tableEntity.DomainObject;
    }
}