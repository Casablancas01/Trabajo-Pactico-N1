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
        public int BrnadId { get; set; }
        public Brand Brand { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
