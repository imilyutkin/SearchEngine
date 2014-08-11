using System;
using System.Collections.Generic;

namespace SearchEngine.Repositories.neo4j.Contracts
{
    public interface IGraphRepository<TNode> where TNode : class 
    {
        TNode Save(TNode node);

        IEnumerable<TNode> Get(Predicate<TNode> predicate);

        IEnumerable<TNode> GetAll();
    }
}
