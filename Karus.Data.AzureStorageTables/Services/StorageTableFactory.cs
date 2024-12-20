using Karus.Data.AzureStorageTables.Contracts;

namespace Karus.Data.AzureStorageTables.Services;

public class TableStorageFactory : IStorageTableFactory
{
    private readonly string _connectionString;

    public TableStorageFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public StorageTableService<TDomain, TId> GetTableService<TDomain, TId>(string tableName) where TDomain : class, new()
    {
        return new StorageTableService<TDomain, TId>(_connectionString, tableName);
    }
}