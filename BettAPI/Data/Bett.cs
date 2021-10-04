using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BettAPI.Models
{
    public class Bett
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public double Amount { get; set; }
        
        public string Type { get; set; }
        
        public string Odds { get; set; }

        public bool isUpdated { get; set; }
        public DateTime UpdatedTime { get; set; }


    }
    
}
