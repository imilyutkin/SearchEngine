using System.ComponentModel.DataAnnotations.Schema;
using MilyutkinI.Repository.Contracts;

namespace SearchEngine.DomainModels.Models
{
    public class Entity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            private set;
        }
    }
}
