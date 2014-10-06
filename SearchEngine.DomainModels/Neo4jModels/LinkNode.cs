using System;
using SearchEngine.DomainModels.Neo4jModels.Attributes;

namespace SearchEngine.DomainModels.Neo4jModels
{
    [NodeName("Link")]
    public class LinkNode : BaseNode
    {
        public String Url
        {
            get;
            set;
        }
    }
}
