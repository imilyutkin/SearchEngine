using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Neo4jClient;
using SearchEngine.DomainModels.Neo4jModels.Attributes;
using SearchEngine.Repositories.neo4j.Contracts;

namespace SearchEngine.Repositories.neo4j.Impl
{
    public abstract class Neo4JRepository<TNode> : IGraphRepository<TNode> where TNode: class 
    {
        protected IGraphClient Client;

        protected String TypeName
        {
            get { return typeof (TNode).GetCustomAttribute<NodeNameAttribute>().NodeTypeName ?? typeof (TNode).Name; }
        }

        protected const String CreateTemplate = "(node:{0} {{{1}}})";
        protected const String GetAllTemplate = "(node:{0})";
        protected const String CreateParameterName = "nodeToCreate";

        protected Neo4JRepository(IGraphClient client)
        {
            Client = client;
        }

        public TNode Save(TNode node)
        {
            Client.Cypher.Create(String.Format(CreateTemplate, TypeName, CreateParameterName))
                .WithParam(CreateParameterName, node)
                .ExecuteWithoutResults();
            return node;
        }

        public IEnumerable<TNode> Get(Predicate<TNode> predicate)
        {
            return
                Client.Cypher.Match(String.Format(GetAllTemplate, TypeName))
                    .Where<TNode>(node => predicate(node))
                    .Return(node => node as TNode)
                    .Results;
        }

        public IEnumerable<TNode> GetAll()
        {
            return Client.Cypher.Match(String.Format(GetAllTemplate, TypeName)).Return(node => node as TNode).Results;
        }
    }
}
