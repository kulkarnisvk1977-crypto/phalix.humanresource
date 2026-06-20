using System;
using AutoMapper;
using HumanResource.Dtos;
using HumanResource.Models;

namespace HumanResource.Profiles
{
    public class EmployeeProfile:Profile 
    {
        
        public EmployeeProfile()
        {
            // source to destination mapping
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
        }

        
    }
}
