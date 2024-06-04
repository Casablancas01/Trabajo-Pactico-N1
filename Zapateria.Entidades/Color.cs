using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Entidades
{
    public class Color
    {
        public int ColorId { get; set; }
        public int ColorName { get; set; }
        public ICollection<Shoe> Shoes { get; set; }

    }
}
