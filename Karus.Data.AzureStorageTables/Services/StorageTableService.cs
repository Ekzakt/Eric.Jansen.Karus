using Azure.Data.Tables;
using Azure;
using Karus.Data.AzureStorageTables.Mappers;
using Karus.Data.AzureStorageTables.Entities;

public class StorageTableService<TDomain, TId> where TDomain : class, new()
{
    private readonly TableClient _tableClient;

    public StorageTableService(string connectionString, string tableName)
    {
        _tableClient = new TableClient(connectionString, tableName);
        _tableClient.CreateIfNotExists();
    }


    public async Task AddAsync(TDomain domainObject, string partitionKey, TId rowKey)
    {
        var entity = domainObject.ToTableEntity(partitionKey, rowKey);
        await _tableClient.AddEntityAsync(entity);
    }


    public async Task<TDomain> GetAsync(string partitionKey, TId rowKey)
    {
        var entity = await _tableClient.GetEntityAsync<StorageTableEntity<TDomain, TId>>(partitionKey, rowKey?.ToString() ?? "default");

        return entity.Value.ToDomainModel();
    }


    public async Task UpdateAsync(TDomain domainObject, string partitionKey, TId rowKey)
    {
        var entity = domainObject.ToTableEntity(partitionKey, rowKey);
        await _tableClient.UpdateEntityAsync(entity, ETag.All, TableUpdateMode.Replace);
    }


    public async Task DeleteAsync(string partitionKey, TId rowKey)
    {
        await _tableClient.DeleteEntityAsync(partitionKey, rowKey?.ToString() ?? "default");
    }
}