using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Entidades
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; } // Corregido el typo
        public Brand Brand { get; set; }

        public int SportId { get; set; }
        public Sport Sport { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; } // Asocias el color a los zapatos

        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
