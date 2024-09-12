using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapateria.Entidades;

namespace Zapateria.Datos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Shoe> Shoes { get; }
        IGenericRepository<Color> Colors { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Sport> Sports { get; }

        int Complete(); // Método para confirmar los cambios
    }
}
