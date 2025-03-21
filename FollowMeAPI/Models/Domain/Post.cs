using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FollowMeAPI.Models.Domain
{
        public class Post
        {
                public int Id { get; set; }

                [DataType(DataType.DateTime)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
                public DateTime Date { get; set; }

                public string? Text { get; set; }

                public bool isGroup { get; set; }

                public int? UserId { get; set; }
                public User? User { get; set; }
        }
}
