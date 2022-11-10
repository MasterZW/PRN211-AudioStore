using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AudioStore.Models.Enums;

namespace AudioStore.Models.Entities
{
    public class User
    {
        [Key]
        public int ID { set; get; }
        public int AvatarID { get; set; }

        [Required(ErrorMessage = "Username cannot be empty!")]
        [MaxLength(20)]
        public string Username { set; get; }

        [EmailAddress(ErrorMessage = "Email invalid")]
        [Required(ErrorMessage = "Email cannot be empty!")]
        public string Email { set; get; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be empty")]
        [MaxLength(250)]
        public string Password { set; get; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password cannot be empty")]
        [MaxLength(250)]
        public string ConfirmPassword { set; get; }

        [MaxLength(100)]
        public string Address { set; get; }

        [Required(ErrorMessage = "Phone number cannot be empty")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { set; get; }

        public UserRole Role { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }

        //reference foreign key
        public virtual Avatar Avatar { get; set; }

        //configuration foreign Key
        [ForeignKey("UserId")]
        public virtual ICollection<Order> Orders { set; get; }
        [ForeignKey("UserId")]
        public virtual ICollection<Evaluate> Evaluates { set; get; }
    }
}