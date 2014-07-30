namespace SearchEngine.DomainModels.Models
{
    public class UrlLink : Entity
    {
        public Url From
        {
            get;
            set;
        }

        public Url To
        {
            get;
            set;
        }
    }
}
