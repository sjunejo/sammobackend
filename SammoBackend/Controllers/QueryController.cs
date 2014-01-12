using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;

using SammoBackend.Models;

namespace SammoBackend.Controllers
{
    public class QueryController : ApiController
    {

        private static readonly IQueryRepository queries = new QueryRepository();

        [HttpGet]
        public IQueryable<Query> Get()
        {
            return queries.GetAllQueries().AsQueryable();
        }

        public Query Get(string id)
        {
            Query query = queries.GetQuery(id);
            if (query == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return query;
        }

        public Query Post(Query q)
        {
            Query query = queries.AddQuery(q);
            return query;
        }

        public void Put(string id, Query q)
        {
            if (!queries.UpdateQuery(id, q))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(string id)
        {
            if (!queries.RemoveQuery(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
