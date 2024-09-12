﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapateria.Entidades
{
    public class Sport
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public ICollection<Shoe> Shoes { get; set; }
    }
}
