using System;
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

        [Index(IsUnique = true)]
        public String Address
        {
            get;
            set;
        }
    }
}
