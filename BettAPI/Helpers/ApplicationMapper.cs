using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettAPI.Data;
using BettAPI.Models;

namespace BettAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
            public ApplicationMapper()
            {
                CreateMap<Bett, BettModel>().ReverseMap();
                CreateMap<Bett, UpdatedBettModel>().ReverseMap();
        }
     }

    
}
