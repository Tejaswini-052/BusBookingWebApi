using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusBookingWebApi.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
       // [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        [ForeignKey("UserId")]
        public RegisterUser? RegisterUser { get; set; }

    }
}
