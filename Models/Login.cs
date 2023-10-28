using System.ComponentModel.DataAnnotations;

namespace BusBookingWebApi.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User name is Required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}
