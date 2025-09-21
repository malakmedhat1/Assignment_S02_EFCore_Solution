using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_S02_EFCore.Models.Airline
{
    [PrimaryKey(nameof(AircraftId), nameof(RouteId),nameof(Depature))]
    internal class AircraftRoutes
    {
        [ForeignKey(nameof(AirCraft))]
        public int AircraftId { get; set; }
        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }
        public string Depature { get; set; }
        public int NumOfPassengers { get; set; }
        public decimal Price { get; set; }
        public string? Arrival { get; set; }

        public AirCraft AirCraft { get; set; }= null!;
        public Route Route { get; set; } = null!;
    }
}
