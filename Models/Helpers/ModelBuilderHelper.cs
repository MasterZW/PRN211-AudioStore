using System;
using AudioStore.Models.Entities;
using AudioStore.Utils.Hash;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AudioStore.Models.Helpers
{
    public static class ModelBuilderHelper
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    Name = "LoudSpeaker" //loa
                },
                new Category()
                {
                    ID = 2,
                    Name = "Headphone" //tai nghe
                },
                new Category()
                {
                    ID = 3,
                    Name = "Battery" //pin sạc
                },
                new Category()
                {
                    ID = 4,
                    Name = "Webcam" //webcam
                },
                new Category()
                {
                    ID = 5,
                    Name = "Mouse" //chuột
                },
                new Category()
                {
                    ID = 6,
                    Name = "Keyboard" //bàn phím
                },
                new Category()
                {
                    ID = 7,
                    Name = "Cable" //dây cáp sạc
                }
            );
            #endregion

            #region Seed default Avatar
            modelBuilder.Entity<Avatar>().HasData(new Avatar
            {
                ID = 1,
                Thumnail = "https://www.cariblist.com/admin/assets/avatars/"
            });
            #endregion

            #region Seed User role Admin
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = 1,
                AvatarID = 1,
                Username = "admin",
                Email = "admin@admin.com",
                Password = Md5.GetMD5("adminadmin"),
                Address = "",
                PhoneNumber = "0396384095",
                Role = Enums.UserRole.Admin,
                CreateAt = DateTime.Now
            });
            #endregion

            #region Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = 1,
                    CategoryID = 2,
                    Name = "Fender Track",
                    Thumnail = "https://3kshop.vn/wp-content/uploads/2022/03/3kshop-fender-track-1.jpg",
                    Stock = 50,
                    Price = 175,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 2,
                    CategoryID = 2,
                    Name = "Jabra Elite 4 Active",
                    Thumnail = "https://3kshop.vn/wp-content/uploads/2022/01/jabra-elite-active-4-1.jpg",
                    Stock = 78,
                    Price = 100,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 3,
                    CategoryID = 1,
                    Name = "JBL Charge 5",
                    Thumnail = "https://3kshop.vn/wp-content/uploads/2021/09/QNrL8MzWoEYkLptNdJngqQ.jpeg",
                    Stock = 58,
                    Price = 50,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 4,
                    CategoryID = 1,
                    Name = "Edifier R1280DBs",
                    Thumnail = "https://3kshop.vn/wp-content/uploads/2021/09/unnamed-1.jpg",
                    Stock = 26,
                    Price = 110,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 5,
                    CategoryID = 1,
                    Name = "Marshall Emberton",
                    Thumnail = "https://3kshop.vn/wp-content/uploads/2020/07/loa-marshall-Emberton-BlacknBrass.png",
                    Stock = 89,
                    Price = 105,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 6,
                    CategoryID = 3,
                    Name = "UmeTravel TRIP10C",
                    Thumnail = "https://www.xtmobile.vn/vnt_upload/product/11_2020/thumbs/600_pin_du_phong_polymer_umetravel_trip10c_10000mah.jpg",
                    Stock = 100,
                    Price = 10,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                },
                new Product()
                {
                    ID = 7,
                    CategoryID = 4,
                    Name = "Webcam Logitech C925E",
                    Thumnail = "https://anphat.com.vn/media/product/22508_logitech_c925_1.png",
                    Stock = 96,
                    Price = 100,
                    Desc = "",
                    Detail = "",
                    CreateAt = DateTime.Now
                }
            );
            #endregion
        }
    }
}