using AutoMapper;
using Core.Models;
using DataAcces.Entity;

namespace Core.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile() { 
          CreateMap<AuthorDto,Author>().ReverseMap();
        }
    }
}
