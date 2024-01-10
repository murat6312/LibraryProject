using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Profiles
{
    public class PublisherProfile : Profile
    {

        public PublisherProfile() {
            CreateMap<Publisher, PublisherDto>().ReverseMap();
        }
    }
}
