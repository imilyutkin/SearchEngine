using System;
using System.Reflection;
using Neo4jClient;
using SearchEngine.DomainModels.Neo4jModels.Attributes;
using SearchEngine.Repositories.neo4j.Contracts;

namespace SearchEngine.Repositories.neo4j.Impl
{
    public abstract class Neo4JRepository<TNode> : IGraphRepository<TNode>
    {
        protected IGraphClient Client;
        protected const String CreateTemplate = "(node:{0} {{{1}}})";
        protected const String CreateParameterName = "nodeToCreate";

        protected Neo4JRepository(IGraphClient client)
        {
            Client = client;
        }

        public TNode Save(TNode node)
        {
            var typeName = typeof (TNode).GetCustomAttribute<NodeNameAttribute>().NodeTypeName ?? typeof (TNode).Name;
            Client.Cypher.Create(String.Format(CreateTemplate, typeName, CreateParameterName))
                .WithParam(CreateParameterName, node)
                .ExecuteWithoutResults();
            return node;
        }
    }
}
