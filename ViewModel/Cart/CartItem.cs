using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AudioStore.Models.Entities;

namespace AudioStore.ViewModel.Cart
{
    [NotMapped]
    public class CartItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}