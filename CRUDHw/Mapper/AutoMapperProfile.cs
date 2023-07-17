using AutoMapper;
using CRUDHw.Models;

namespace CRUDHw.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddProductViewModel, Product>();
        }
    }
}
