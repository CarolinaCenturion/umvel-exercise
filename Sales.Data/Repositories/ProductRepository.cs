using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sales.Data.Context;
using Sales.Data.Core;
using Sales.Data.Interfaces;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {

        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext applicationDbContext, IMapper mapper): base(applicationDbContext)
        {
            _mapper = mapper;
        }

        public List<CreateProductDTO> GetProductsDTO()
        {
            return _context.Products.ProjectTo<CreateProductDTO>(_mapper.ConfigurationProvider).ToList();
        }

        public CreateProductDTO GetProductByIdDTO(int id)
        {
            return _context.Products.Where(p => p.Id == id).ProjectTo<CreateProductDTO>(_mapper.ConfigurationProvider).FirstOrDefault();
        }
    }
}
