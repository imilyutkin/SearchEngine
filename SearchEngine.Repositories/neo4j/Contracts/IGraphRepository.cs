using System;
using System.Collections.Generic;
using SearchEngine.DomainModels.Neo4jModels;

namespace SearchEngine.Repositories.neo4j.Contracts
{
    public interface IGraphRepository<TNode> where TNode : BaseNode
    {
        TNode Save(TNode node);

        IEnumerable<TNode> Get(Predicate<TNode> predicate);

        IEnumerable<TNode> GetAll();

        void Delete(Predicate<TNode> predicate);
    }
}
