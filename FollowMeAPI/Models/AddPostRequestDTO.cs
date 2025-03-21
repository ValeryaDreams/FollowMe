using FollowMeAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FollowMeAPI.Models
{
        public class AddPostRequestDTO
        {
                [DataType(DataType.DateTime)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
                public DateTime Date { get; set; }

                public string? Text { get; set; }

                public bool isGroup { get; set; }

                public int? UserId { get; set; }
        }
}
