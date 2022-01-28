using AutoMapper;
using employee_api.Models;


namespace employee_api.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            // tweets
            CreateMap<Employee, Employee>();
            
        }
    }
}
