﻿using System.ComponentModel.DataAnnotations;

namespace FoodForRequest.Models
{
    public class BiddingViewModel
    {
        [Required]
        public string ProductId { get; set; }

        [Range(1, 9999999)]
        [Required]
        public int Value { get; set; }
    }
}
