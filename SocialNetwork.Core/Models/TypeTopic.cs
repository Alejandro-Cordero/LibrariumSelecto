using SocialNetwork.Core.Models.Base;
using System.Collections.ObjectModel;

namespace SocialNetwork.Core.Models
{
    public class TypeTopic : TypeEntity
    {
        public TypeTopic()
        {
            Articles = new Collection<Article>();

        }
        public ICollection<Article> Articles { get; set; }
    }
}
