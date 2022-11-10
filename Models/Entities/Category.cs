using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioStore.Models.Entities
{
    public class Category
    {
        [Key]
        public int ID { set; get; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Category Name cannot be empty")]
        public string Name { set; get; }

        //Configure Foreign Key
        [ForeignKey("CategoryID")]
        public virtual ICollection<Product> Product { set; get; }
    }
}