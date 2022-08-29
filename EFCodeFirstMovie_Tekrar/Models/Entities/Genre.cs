using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        //Relational Props

        public virtual List<Movie> Movies { get; set; }
       


    }
}
