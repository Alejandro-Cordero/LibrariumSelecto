namespace SocialNetwork.Api.Resources
{
    public class SaveUserResource
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public int? TypeGenderId { get; set; }
    }
}