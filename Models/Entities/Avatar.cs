using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioStore.Models.Entities
{
    public class Avatar
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Url invalid")]
        public string Thumnail { get; set; }

        [ForeignKey("AvatarID")]
        public ICollection<User> User { get; set; }
    }
}