using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class Tag : BaseEntity
    {
        public string TagDesc { get; set; }

        // Relational Props

        public virtual List<MovieTag> MovieTags { get; set; }

    }
}
