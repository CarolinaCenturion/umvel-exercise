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
    public class SaleRepository: BaseRepository<Sale>, ISaleRepository
    {
        private readonly IMapper _mapper;
        public SaleRepository(ApplicationDbContext applicationDbContext, IMapper mapper): base(applicationDbContext)
        {
            _mapper = mapper;
        }

        public List<SaleListDTO> GetSalesDTOByRangeDate(DateTime startDate, DateTime endTime)
        {
            return _context.Sales.Where(s => s.Date >= startDate && s.Date <= endTime).ProjectTo<SaleListDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
