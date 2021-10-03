using MongoDB.Driver;
using System.Threading.Tasks;

namespace Infrastructure.Data.MongoDb
{
    public class MongoContext
    {
        private IMongoDatabase db;

        public MongoContext(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public async Task InserRecordAsync<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }
    }
}
