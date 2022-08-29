using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        // Relational Props

        public virtual List<MovieActor> MovieActors { get; set; }
        public virtual ActorProfile Profile { get; set; }

    }
}
