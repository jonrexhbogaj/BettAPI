using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Models
{
    public class Bett
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Odds { get; set; }

        public bool isUpdated { get; set; }
        public DateTime UpdatedTime { get; set; }


    }
  
}
