using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioStore.Models.Entities
{
    public class Comment
    {
        [Key]
        public int ID { set; get; }
        [Column("Content")]
        public string CommentContent { set; get; }

        [Column("Date")]
        [DataType(DataType.Date)]
        [MaxLength(250)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CommentDate { set; get; }

        [Column("Edit")]
        public bool? CommentEdit { set; get; }
        [Column("Delete")]
        public bool? CommentDelete { set; get; }

        //Configure Foreign Key
        [ForeignKey("CommentID")]
        public virtual ICollection<Evaluate> Evaluate { set; get; }
    }
}