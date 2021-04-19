﻿using System;

namespace DeliVeggie.Server.Service.Models
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }
}