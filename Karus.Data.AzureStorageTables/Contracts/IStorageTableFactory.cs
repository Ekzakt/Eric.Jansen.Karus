namespace Karus.Data.AzureStorageTables.Contracts;

public interface IStorageTableFactory
{
    StorageTableService<TDomain, TId> GetTableService<TDomain, TId>(string tableName) where TDomain : class, new();
}
