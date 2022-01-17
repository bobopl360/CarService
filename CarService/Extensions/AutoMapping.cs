using AutoMapper;
using CarService.Models.DTO;
using CarService.Models.Requests;
using CarService.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cars, CarsResponse>().ReverseMap();
            CreateMap<CarsRequest, Cars>().ReverseMap();
            CreateMap<CarsUpdateRequest, Cars>().ReverseMap();
            CreateMap<Clients, ClientResponse>().ReverseMap();
            CreateMap<ClientRequest, Clients>().ReverseMap();
            CreateMap<ClientUpdateRequest, Clients>().ReverseMap();
            CreateMap<Employees, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeRequest, Employees>().ReverseMap();
            CreateMap<EmployeeUpdateRequest, Employees>().ReverseMap();
            CreateMap<Products, ProductResponse>().ReverseMap();
            CreateMap<ProductRequest, Products>().ReverseMap();
            CreateMap<ProductUpdateRequest, Products>().ReverseMap();
            CreateMap<Service, ServiceResponse>().ReverseMap();
            CreateMap<ServiceRequest, Service>().ReverseMap();
            CreateMap<ServiceUpdateRequest, Service>().ReverseMap();
            CreateMap<Shift, ShiftResponse>().ReverseMap();
            CreateMap<ShiftRequest, Shift>().ReverseMap();
            CreateMap<ShiftUpdateRequest, Shift>().ReverseMap();
        }
    }
}
