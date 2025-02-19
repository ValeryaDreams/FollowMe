using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FollowMeAPI.Models.Domain
{
        public class Post
        {
                public Guid Id { get; set; }

                [DataType(DataType.DateTime)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
                public DateTime Date { get; set; }

                public string? Text { get; set; }

                [DefaultValue(false)]
                public bool isGroup { get; set; }

                public User? User { get; set; }
        }
}
