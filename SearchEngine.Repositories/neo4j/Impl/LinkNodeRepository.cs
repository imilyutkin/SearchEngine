using Neo4jClient;
using SearchEngine.DomainModels.Neo4jModels;
using SearchEngine.Repositories.neo4j.Contracts;

namespace SearchEngine.Repositories.neo4j.Impl
{
    public class LinkNodeRepository : Neo4JRepository<LinkNode>, ILinkNodeRepository
    {
        public LinkNodeRepository(IGraphClient client) : base(client)
        {
        }
    }
}
