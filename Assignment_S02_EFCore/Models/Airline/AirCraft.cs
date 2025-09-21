using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [Table("AirCrafts", Schema = "Airline")]
    internal class AirCraft
    {
        [Key]
        public int AirCraftId { get; set; }
        [Required, MaxLength(50)]
        public string MajPilot { get; set; }
        [Required, MaxLength(50)]
        public string Model { get; set; }
        [Required, MaxLength(50)]
        public string Assisstant { get; set; }
        [Required, MaxLength(50)]
        public string Host1 { get; set; }
        [Required, MaxLength(50)]
        public string Host2 { get; set; }
        [Required]
        public int Capacity { get; set; }

        [ForeignKey(nameof(AirLine.OwnedCraft))]
        public int AirLineOwningId { get; set; }
        public AirLine? AirLineOwning { get; set; }

        public ICollection<AircraftRoutes> AssignedRoutes { get; set; } = new List<AircraftRoutes>();
    }
}
