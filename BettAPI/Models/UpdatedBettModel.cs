using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Models
{
    public class UpdatedBettModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }
        public string Type { get; set; }

        public string Odds { get; set; }
    }
}
