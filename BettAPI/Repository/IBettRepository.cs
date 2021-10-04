using BettAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Repository
{
    public interface IBettRepository
    {
        Task<List<BettModel>> GetAllBettsAsync();
        Task<BettModel> GetBettByIdAsync(int id);
        Task<int> AddBettAsync(UpdatedBettModel bett);
        Task UpdateBettAsync(int id, BettModel bett);
       
        Task DeleteBettAsync(int id);
    }
}
