using System;

namespace SearchEngine.Repositories.neo4j.Contracts
{
    public interface IGraphRepository<TNode>
    {
        TNode Save(TNode node);
    }
}
