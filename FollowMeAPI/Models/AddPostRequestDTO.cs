using FollowMeAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FollowMeAPI.Models
{
        public class AddPostRequestDTO
        {
                public int Id { get; set; }

                [DataType(DataType.DateTime)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
                public DateTime Date { get; set; }

                public string? Text { get; set; }

                [DefaultValue(false)]
                public bool isGroup { get; set; }

                public User? User { get; set; }
        }
}
