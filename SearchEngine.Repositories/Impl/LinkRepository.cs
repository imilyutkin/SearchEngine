using MilyutkinI.Repository;
using MilyutkinI.Repository.Contracts;
using SearchEngine.DomainModels.Models;
using SearchEngine.Repositories.Contracts;

namespace SearchEngine.Repositories.Impl
{
    public class LinkRepository : BaseRepository<UrlLink>, ILinkRepository
    {
        public LinkRepository(ISourceContext sourceContext) : base(sourceContext)
        {
        }

        public override void Dispose()
        {
        }
    }
}
