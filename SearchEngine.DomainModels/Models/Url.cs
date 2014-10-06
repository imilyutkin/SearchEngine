using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.DomainModels.Models
{
    public class Url : Entity
    {
        public String Title
        {
            get;
            set;
        }

        [MaxLength(100)]
        [Index(IsUnique = true)]
        public String Address
        {
            get;
            set;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId
        {
            get;
            set;
        }

        public IList<Word> Words
        {
            get;
            set;
        }
    }
}
