using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [PrimaryKey(nameof(AirLineId), nameof(PhoneNumber))]
    internal class AirlinePhones
    {
        [ForeignKey(nameof(AirLine))]
        public int AirLineId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
