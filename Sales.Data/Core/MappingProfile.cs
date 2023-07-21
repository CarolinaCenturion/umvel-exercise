using AutoMapper;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListDTO>()
                .ForMember(m => m.Sales, e => e.MapFrom(x => x.Sales.OrderByDescending(o=>o.Id)));
            CreateMap<Sale, CreateSaleDTO>();

            CreateMap<Sale, SaleListDTO>()
               .ForMember(m => m.Customer, e => e.MapFrom(x => x.Customer));
            CreateMap<Customer, CreateCustomerDTO>();
            CreateMap<Product, CreateProductDTO>();

        }
    }
}
