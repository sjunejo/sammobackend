using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SammoBackend.Models
{
    // CRUD methods need to be declared here.
    public interface IQueryRepository
    {
          IEnumerable<Query> GetAllQueries();

          Query GetQuery(string id);

          Query AddQuery(Query query);

          bool RemoveQuery(string id);

          bool UpdateQuery(string id, Query query);
    }
}