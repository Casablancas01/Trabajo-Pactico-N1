using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapateria.Datos.Interfaces;
using Zapateria.Datos.Repositorios;
using Zapateria.Entidades;

namespace Zapateria.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZapateriaDbContext _context;

        public UnitOfWork(ZapateriaDbContext context)
        {
            _context = context;
            Brands = new GenericRepository<Brand>(_context);
            Shoes = new GenericRepository<Shoe>(_context);
            Colors = new GenericRepository<Color>(_context);
            Genres = new GenericRepository<Genre>(_context);
            Sports = new GenericRepository<Sport>(_context);
        }

        public IGenericRepository<Brand> Brands { get; private set; }
        public IGenericRepository<Shoe> Shoes { get; private set; }
        public IGenericRepository<Color> Colors { get; private set; }
        public IGenericRepository<Genre> Genres { get; private set; }
        public IGenericRepository<Sport> Sports { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges(); // Confirma todos los cambios
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
