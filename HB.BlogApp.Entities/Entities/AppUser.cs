using HB.BlogApp.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.Entities.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {

        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? LastLogin { get; set; }
        public bool isBanned { get; set; } = false;

        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
    }


    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Context { get; set; } = null!;
        public string ImagePath { get; set; } = null!;

        public List<UserFavBlog> UserFavBlogs { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();

    }


    //cross table  appuser with blog (n-n relation)
    public class Comment
    {

        public int Id { get; set; }
        public string CommentContent { get; set; } = null!;
        public DateTime AddedDate { get; set; }


        //nav prop
        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }


        //FK
        public string UserId { get; set; }
        public int BlogId { get; set; }


    }

}
