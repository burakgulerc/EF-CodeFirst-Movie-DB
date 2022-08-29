using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public int? DirectorID { get; set; }
        public int? GenreID { get; set; }
        public int? CategoryID { get; set; }


        // Relational props

        public virtual Director Director { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<MovieTag> MovieTags { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}
