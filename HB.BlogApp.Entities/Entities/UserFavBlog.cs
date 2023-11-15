namespace HB.BlogApp.Entities.Entities
{
    //Cross Table Fav Blog
    public class UserFavBlog
    {
        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }

        public string UserId { get; set; }
        public int BlogId { get; set; }


    }


}
