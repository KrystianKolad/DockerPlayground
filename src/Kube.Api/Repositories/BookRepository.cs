using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kube.Api.Models;
using Kube.Api.Repositories.Interfaces;
using MongoDB.Driver;

namespace Kube.Api.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IMongoDatabase _database;
        public BookRepository(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("KubeDb");
        }
        public async Task AddAsync(Book model)
        {
            var collection = _database.GetCollection<Book>("Books");
            await collection.InsertOneAsync(model);
        }

        public async Task<Book> FindAsync(Expression<Func<Book, bool>> predicate)
        {
            var collection = _database.GetCollection<Book>("Books");
            return await collection.Find(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            var collection = _database.GetCollection<Book>("Books");
            return await collection.AsQueryable().ToListAsync();
        }
    }
}