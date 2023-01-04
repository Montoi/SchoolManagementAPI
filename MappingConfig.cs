using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Models.Dto;

namespace SchoolManagementAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<Studentsubjects, StudentsubjectsDto>().ReverseMap();
            CreateMap<Studentsubjects, StudentsubjectsCreateDto>().ReverseMap();
            CreateMap<Studentsubjects, StudentsubjectsUpdateDto>().ReverseMap();

        }
    }
}
