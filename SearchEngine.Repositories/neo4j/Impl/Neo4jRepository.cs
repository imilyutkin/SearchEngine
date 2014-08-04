using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using SearchEngine.Repositories.neo4j.Contracts;

namespace SearchEngine.Repositories.neo4j.Impl
{
    public class Neo4JRepository : IGraphRepository
    {
        protected IGraphClient Client;

        public Neo4JRepository(IGraphClient client)
        {
            Client = client;
        }
    }
}
