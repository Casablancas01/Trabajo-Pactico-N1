using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zapateria.Datos.Interfaces;
using Zapateria.Entidades;
using Zapateria.Servicios.Interefaces;

namespace Zapateria.Servicios.Servicios
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _unitOfWork.Brands.GetAllAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _unitOfWork.Brands.GetByIdAsync(id);
        }

        public async Task AddAsync(Brand brand)
        {
            await _unitOfWork.Brands.AddAsync(brand);
            _unitOfWork.Complete(); // Confirma los cambios
        }

        public async Task UpdateAsync(Brand brand)
        {
            _unitOfWork.Brands.Update(brand);
            _unitOfWork.Complete(); // Confirma los cambios
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _unitOfWork.Brands.GetByIdAsync(id);
            if (brand != null)
            {
                _unitOfWork.Brands.Remove(brand);
                _unitOfWork.Complete(); // Confirma los cambios
            }
        }
    }

}
