﻿namespace FollowMeAPI.Models.Domain
{
        public class User
        {
                public int Id { get; set; }
                public string? Name { get; set; }
                public string? Login { get; set; }
                public string? Password { get; set; }

                public ICollection<Post>? Posts { get; set; }
        }
}