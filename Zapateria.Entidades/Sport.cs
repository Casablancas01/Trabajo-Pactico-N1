using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Entidades
{
    public  class Sport
    {
        public int SportsId { get; set; }
        public string SportsName { get; set;}
        public ICollection<Shoe> Shoes { get; set; }
    }
}
