using MilyutkinI.Repository;
using MilyutkinI.Repository.Contracts;
using SearchEngine.DomainModels.Models;
using SearchEngine.Repositories.Contracts;

namespace SearchEngine.Repositories.Impl
{
    public class UrlRepository : BaseRepository<Url>, IUrlRepository
    {
        public UrlRepository(ISourceContext sourceContext) : base(sourceContext)
        {
        }

        public override void Dispose()
        {
        }
    }
}
