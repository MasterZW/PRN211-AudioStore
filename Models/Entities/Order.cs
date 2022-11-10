using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioStore.Models.Entities
{
    public class Order
    {
        [Key]
        public int ID { set; get; }
        public int UserId { set; get; }
        public double TotalPrice { set; get; }
        public int Quantity { set; get; }

        //reference Foreign Key
        public virtual User User { set; get; }

        //Configure Foreign Key
        [ForeignKey("OrderID")]
        public virtual ICollection<OrderDetail> OrderDetail { set; get; }
    }
}