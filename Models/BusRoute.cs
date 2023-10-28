using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusBookingWebApi.Models
{
    public class BusRoute
    {
        [Key] 
        public int RouteId { get; set; }

        [Required]
        public string? From { get; set; }
        [Required]
        public string? To { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
        public string? StartDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
        public string? EndDate { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public int Duration { get; set; }



    }
}
