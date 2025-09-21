using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Airline
{
    [Table("Routes", Schema = "Airline")]
    internal class Route
    {
        [Key]
        public int RouteId { get; set; }
        [Required, MaxLength(50)]
        public string Origin { get; set; }
        [Required, MaxLength(50)]
        public string Destination { get; set; }
        [Required, MaxLength(100)]
        public string Classification { get; set; }
        [Required]
        public int Distance { get; set; }

        public ICollection<AircraftRoutes> RoutesAssigned { get; set; } = new List<AircraftRoutes>();
    }
}
