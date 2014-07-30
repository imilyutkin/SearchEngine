using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;

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
    }
}
