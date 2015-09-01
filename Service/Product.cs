using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AWDataService
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
