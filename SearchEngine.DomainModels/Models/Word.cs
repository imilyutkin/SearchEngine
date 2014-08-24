using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.DomainModels.Models
{
    public class Word : Entity
    {
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public String Label
        {
            get;
            set;
        }

        public IList<Url> Urls
        {
            get;
            set;
        }
    }
}
