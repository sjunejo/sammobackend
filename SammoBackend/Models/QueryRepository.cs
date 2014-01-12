using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SammoBackend.Constants;


namespace SammoBackend.Models
{
    public class QueryRepository: IQueryRepository
    {

        MongoServer server;
        MongoDatabase database;
        MongoCollection<Query> queries;


        // Constants
        private const string ID = "Query_Id";
        private const string USER = "user";
        private const string TITLE = "title";
        private const string TAGS = "tags";

        // Test method - will add proper data later
        private void addExampleData()
        {
            // Remove old data
            queries.RemoveAll();

            // TEST
            Query[] queries_array = new Query[]{
            new Query {Id = "1", User_Id = "sunny", Location = "Manchester, United Kingdom", 
            tags = new string[]{ "SOS", "injury", "leg", "arm"} },
            new Query {Id = "2", User_Id = "ymo1992", Location = "London, United Kingdom", 
            tags = new string[]{ "SOS", "injury", "leg", "head"} },
            new Query {Id = "3", User_Id = "junejo", Location = "New Jersey", 
            tags = new string[]{ "SOS", "pain", "heart"} },

            };

            foreach (Query q in queries_array){
                AddQuery(q);
            }
        }


        public IEnumerable<Query> GetAllQueries(){
            return queries.FindAll();
        }

        public Query GetQuery(string id)
        {
            IMongoQuery mongoQ =  MongoDB.Driver.Builders.Query.EQ(ID, id);
            return queries.Find(mongoQ).FirstOrDefault();
        }

        public Query AddQuery(Query query)
        {
            query.Id = ObjectId.GenerateNewId().ToString();
            queries.Insert(query);
            return query;
        }

        public bool RemoveQuery(string id)
        {
            IMongoQuery mongoQ = MongoDB.Driver.Builders.Query.EQ(ID, id);
            SafeModeResult result = queries.Remove(mongoQ);
            return result.DocumentsAffected == 1;

        }

        public bool UpdateQuery(string id, Query query)
        {
            IMongoQuery mongoQ = MongoDB.Driver.Builders.Query.EQ(ID, id);
            IMongoUpdate update = Update
                .Set(USER, query.User_Id)
                .Set(TAGS, query.tags.ToString())
                .Set(TITLE, query.Title);
            SafeModeResult result = queries.Update(mongoQ, update);
            return result.UpdatedExisting;
        }
        
        
        public QueryRepository()
            : this("")
        {
        }

        // Connect to database as soon as constructed
        public QueryRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = DatabaseConstants.DATABASE_CONNECTION;
            }

            server = MongoServer.Create(connection);

            database = server.GetDatabase(DatabaseConstants.DATABASE_NAME);

            queries = database.GetCollection<Query>(DatabaseConstants.DATABASE_NAME);

            this.addExampleData();
        }


      
    }
}