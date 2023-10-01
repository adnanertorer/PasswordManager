using AutoMapper;
using CorePersistence.Paging;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Models;

namespace PasswordManager.Domain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryEntity, Categories>().ReverseMap();
            CreateMap<Paginate<CategoryEntity>, Paginate<Categories>> ().ReverseMap();
            CreateMap<UserAccountEntity, UserAccounts>().ReverseMap();
            CreateMap<Paginate<UserAccountEntity>, Paginate<UserAccounts>>().ReverseMap();
            CreateMap<UserNotesEntity, UserNotes>().ReverseMap();
            CreateMap<Paginate<UserNotesEntity>, Paginate<UserNotes>>().ReverseMap();
        }
    }
}