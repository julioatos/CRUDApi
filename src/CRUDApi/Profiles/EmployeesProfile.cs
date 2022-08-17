﻿using AutoMapper;
using CRUDApi.DTOs;

namespace CRUDApi.Profiles
{
    public class EmployeesProfile : Profile 
    {
        public EmployeesProfile()
        {
            CreateMap<Models.Employee, EmployeeReadDTO>();
            CreateMap<Models.Employee, EmployeeCreateDTO>().ReverseMap();
        }
    }
}
