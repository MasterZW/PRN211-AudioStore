using System.ComponentModel.DataAnnotations;

namespace AudioStore.Models.Entities
{
    public class Evaluate
    {
        [Key]
        public int ID { get; set; }
        public int UserId { set; get; }
        public int ProductID { set; get; }
        public int CommentID { set; get; }
        public string Stars { set; get; }

        //reference Foreign Key
        public virtual User User { set; get; }
        public virtual Product Product { set; get; }
        public virtual Comment Comment { set; get; }
    }
}