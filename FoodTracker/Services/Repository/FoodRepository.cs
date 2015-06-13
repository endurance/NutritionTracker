using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;
using FoodTracker.Model;
using Dapper;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FoodTracker.Services.Repository
{
    public interface IRepository<T>
    {
        void AddEntity(T newEntity);
        T GetEntity(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }

    public interface IFoodRepository : IRepository<FoodItem>
    {
        IEnumerable<FoodItem> GetAllFoodItems();
    }

    public class MongoFoodRepository : IFoodRepository
    {
        private IMongoDatabase mongoDb;
        private IMongoClient mongoClient;
        private readonly IMongoCollection<FoodItem> collection;

        public MongoFoodRepository()
        {
            mongoClient = new MongoClient(ConfigurationManager.ConnectionStrings["FoodTrackerDb"].ConnectionString);
            mongoDb = mongoClient.GetDatabase("FoodDb");
            collection = mongoDb.GetCollection<FoodItem>("FoodItems");
        }
        
        public async void AddEntity(FoodItem newEntity)
        {
            await collection.InsertOneAsync(newEntity);
        }

        public FoodItem GetEntity(FoodItem entity)
        {
            return collection.Find(i => i == entity).SingleAsync().Result;
        }

        public IEnumerable<FoodItem> Find(Expression<Func<FoodItem, bool>> predicate)
        {
            return collection.Find(predicate).ToListAsync().Result;
        }

        public IEnumerable<FoodItem> GetAllFoodItems()
        {
            return collection.Find(i => true).ToListAsync().Result;
        }
    }
}