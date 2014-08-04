using System.Collections.Generic;

namespace SearchEngine.DomainModels.Models
{
    public class UrlLink : Entity
    {
        public Url Source
        {
            get;
            set;
        }

        public List<Url> Links
        {
            get;
            set;
        }
    }
}
