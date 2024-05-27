using SocialNetwork.Core.Models.Base;
using System.Collections.ObjectModel;

namespace SocialNetwork.Core.Models
{
    public class TypeGender : TypeEntity
    {
        public TypeGender()
        {
            Users = new Collection<User>();
        }
        public ICollection<User> Users { get; set; }
    }
}
