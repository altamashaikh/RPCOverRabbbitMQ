using System;

namespace DeliVeggie.Queue.Messages
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }
}
