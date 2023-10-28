using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace BusBookingWebApi.Models
{
    public class RegisterUser
    {
        [Key] 
        public int UserId { get; set; }
        [Required] 
        public string? Username { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }

        [JsonIgnore]
        public ICollection<CardDetails>? cards { get; set; }


        [JsonIgnore]
        public ICollection<FeedBack>? feedback { get; set; }



    }
}
