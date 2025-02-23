namespace FollowMeAPI.Models
{
        public class AddUserRequestDTO
        {
                public int Id { get; set; }
                public string? Name { get; set; }
                public string? Login { get; set; }
                public string? Password { get; set; }
        }
}
