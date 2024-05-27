namespace SocialNetwork.Api.Resources
{
    public class CommentaryResource
    {
        //datos que se van a meter en la base de datos al hacer un post
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
