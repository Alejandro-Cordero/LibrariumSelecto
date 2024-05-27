using SocialNetwork.Core.Models.Base;

namespace SocialNetwork.Core.Models
{
    public class Recommendation : Entity
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
