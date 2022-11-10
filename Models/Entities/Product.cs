using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioStore.Models.Entities
{
    public class Product
    {
        [Key]
        public int ID { set; get; }
        public int CategoryID { set; get; }

        [Column("ProductName")]
        [Required(ErrorMessage = "Product Name cannot be empty")]
        [MaxLength(50)]
        public string Name { set; get; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Url invalid")]
        [Required(ErrorMessage = "Image url cannot be empty")]
        public string Thumnail { set; get; }

        [Required(ErrorMessage = "Stock must be greater than zero")]
        [DisplayName("Stock")]
        public int Stock { set; get; }

        [Required(ErrorMessage = "Price must be greater than zero")]
        public double Price { set; get; }

        [Column("Description")]
        public string Desc { get; set; }

        [Column("ProductDetail")]
        [DataType(DataType.Text)]
        public string Detail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        //reference Foreign Key
        public virtual Category Category { set; get; }

        //Configure Foreign Key
        [ForeignKey("ProductID")]
        public virtual ICollection<OrderDetail> OrderDetails { set; get; }
        [ForeignKey("ProductID")]
        public virtual ICollection<Evaluate> Evaluate { set; get; }
    }
}