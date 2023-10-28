using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace BusBookingWebApi.Models
{
    public class CardDetails
    {
        [Key]
        public int PayId { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}")]
        public string? CreditCardNumber { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string? month { get; set; }
        [Required]
        [MaxLength(3)]
        public string? cvv { get; set; }


        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        [ForeignKey("UserId")]
        public RegisterUser? RegisterUser { get; set; }





    }
}
