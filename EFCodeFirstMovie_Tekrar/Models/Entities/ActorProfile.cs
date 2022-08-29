using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstMovie_Tekrar.Models.Entities
{
    public class ActorProfile : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Relational props

        public virtual Actor Actor { get; set; }

    }
}
