using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AudioStore.Models.Enums;

namespace AudioStore.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ProductID { set; get; }
        [Key]
        [Column(Order = 2)]
        public int OrderID { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { set; get; } = DateTime.Now;

        public BillMode BillMode { get; set; } = BillMode.InProgress;

        public virtual Product Product { set; get; }
        public virtual Order Order { set; get; }
    }
}