using CatGiphyApi.Models;
using CatGiphyApi.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CatGiphyApi.Services
{
    public class SearchHistoryService
    {
        private readonly IMongoCollection<SearchRecord> _collection;

        public SearchHistoryService(IOptions<MongoSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _collection = database.GetCollection<SearchRecord>("SearchHistory");
        }

        //Guarda un registro de búsqueda en Mongo
        public async Task SaveSearchAsync(SearchRecord record)
        {
            await _collection.InsertOneAsync(record);
        }

        public async Task<List<SearchRecord>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
