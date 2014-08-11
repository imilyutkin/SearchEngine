using System;

namespace SearchEngine.DomainModels.Neo4jModels.Attributes
{
    public class NodeNameAttribute : Attribute
    {
        public String NodeTypeName
        {
            get;
            set;
        }

        public NodeNameAttribute(String nodeTypeName)
        {
            NodeTypeName = nodeTypeName;
        }
    }
}
