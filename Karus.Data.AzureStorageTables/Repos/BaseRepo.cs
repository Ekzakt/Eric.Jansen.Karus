using Azure.Data.Tables;
using Karus.Application.Contracts;
using Microsoft.Extensions.Logging;
using Karus.Data.AzureStorageTables.Entities;
using Azure;

namespace Karus.Data.AzureStorageTables.Repos;

public abstract class BaseRepo<TEntity, TIdType>
    where TEntity : BaseEntity
{
    private readonly TableClient _tableClient;
    private readonly ILogger<BaseRepo<TEntity, TIdType>> _logger;

    public BaseRepo(ILogger<BaseRepo<TEntity, TIdType>> logger, string connectionString, string tableName)
    {
        _logger = logger;
        _tableClient = new TableClient(connectionString, tableName);
        _tableClient.CreateIfNotExists();
    }


    public async Task AddAsync(ITableEntity entity)
    {
        try
        {
            _logger.LogInformation("Adding entity to storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
            await _tableClient.AddEntityAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to add entity to storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
            throw;
        }
    }


    public async Task UpdateAsync(TEntity entity)
    {
        try
        {
            _logger.LogInformation("Updating entity in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
            await _tableClient.UpsertEntityAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update entity in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
            throw;
        }
    }


    public async Task DeleteAsync(string partitionKey, TIdType id)
    {
        try
        {
            _logger.LogInformation("Deleting entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, id);
            await _tableClient.DeleteEntityAsync(partitionKey, id!.ToString());
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            _logger.LogWarning("Entity not found for deletion in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, id);
            throw;
        }
    }


    public async Task<List<TEntity>> GetAllAsync(string partitionKey)
    {
        _logger.LogInformation("Fetching all entities from storage table. PartitionKey={PartitionKey}", partitionKey);

        var output = new List<TEntity>();
        var entities = _tableClient.QueryAsync<TEntity>();

        await foreach (var entity in entities)
        {
            output.Add(entity);
        }

        return output;
    }


    public async Task<TEntity?> GetByIdAsync(string partitionKey, TIdType id)
    {
        try
        {
            _logger.LogInformation("Fetching entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, id);

            var response = await _tableClient.GetEntityAsync<TEntity>(partitionKey, id!.ToString());
            return response.Value;
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            _logger.LogWarning("Entity not found in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, id);
            return null;
        }
    }




    //public async Task AddAsync(TStorageTableEntity entity)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Adding entity to storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
    //        await _tableClient.AddEntityAsync(entity);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Failed to add entity to storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", entity.PartitionKey, entity.RowKey);
    //        throw;
    //    }
    //}

    //public async Task<TDomain?> GetAsync(string partitionKey, TId rowKey, Func<TStorageTableEntity, TDomain> mapper)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Fetching entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //        var entity = await _tableClient.GetEntityAsync<TStorageTableEntity>(partitionKey, rowKey.ToString());
    //        return mapper(entity.Value);
    //    }
    //    catch (RequestFailedException ex) when (ex.Status == 404)
    //    {
    //        _logger.LogWarning("Entity not found in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //        return null;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Failed to fetch entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //        throw;
    //    }
    //}

    //public async Task DeleteAsync(string partitionKey, TId rowKey)
    //{
    //    try
    //    {
    //        _logger.LogInformation("Deleting entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //        await _tableClient.DeleteEntityAsync(partitionKey, rowKey!.ToString());
    //    }
    //    catch (RequestFailedException ex) when (ex.Status == 404)
    //    {
    //        _logger.LogWarning("Entity not found for deletion in storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Failed to delete entity from storage table. PartitionKey={PartitionKey}, RowKey={RowKey}", partitionKey, rowKey);
    //        throw;
    //    }
    //}
}
