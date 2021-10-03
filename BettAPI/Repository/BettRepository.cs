using BettAPI.Data;
using BettAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BettAPI.Repository
{
    public class BettRepository : IBettRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BettRepository(ApplicationDbContext context, IMapper mapper)
         {
                _context = context;
                _mapper = mapper;
         }


        public async Task<List<BettModel>> GetAllBettsAsync()
        {
            var records = await _context.Bett.ToListAsync();
            return _mapper.Map<List<BettModel>>(records);
        }

        public async Task<BettModel> GetBettByIdAsync(int id)
        {
            //var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return records;

            var bett = await _context.Bett.FindAsync(id);
            return _mapper.Map<BettModel>(bett);
        }

        public async Task<int> AddBettAsync(UpdatedBettModel bettModel)
        {
            var bet = new Bett()
            {
                Amount = bettModel.Amount,
                Type = bettModel.Type,
                Odds = bettModel.Odds
            };

            _context.Bett.Add(bet);
            await _context.SaveChangesAsync();
            return bet.Id;
        }

        public async Task UpdateBettAsync(int id, BettModel bettModel)
        {
            //var book = await _context.Books.FindAsync(bookId);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await _conext.SaveChangesAsync();
            //}

            var bet = new Bett()
            {
                Id = id,
                Amount = bettModel.Amount,
                Type = bettModel.Type,
                Odds = bettModel.Odds,
                UpdatedTime = bettModel.UpdatedTime,
                isUpdated = bettModel.isUpdated == true
            };

            _context.Bett.Update(bet);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateBettPatchAsync(int id, JsonPatchDocument bettModel)
        {
            var bet = await _context.Bett.FindAsync(id);
            if (bet != null)
            {
                bettModel.ApplyTo(bet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBettAsync(int id)
        {
            var bet = new Bett() { Id = id };

            _context.Bett.Remove(bet);

            await _context.SaveChangesAsync();
        }

    }
}
