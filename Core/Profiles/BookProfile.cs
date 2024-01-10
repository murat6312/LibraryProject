using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<BookUpdateModel, Book>().ReverseMap();
        }
    }
}
