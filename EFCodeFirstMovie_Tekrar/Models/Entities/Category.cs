using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        // Relational Prop

        public virtual List<Movie> Movies { get; set; }

    }
}
