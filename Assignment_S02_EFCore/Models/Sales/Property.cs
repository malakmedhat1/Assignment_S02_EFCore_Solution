using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Sales
{
    [Table("Properties")]
    internal class Property
    {
        [Key]
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Code { get; set; }

        [ForeignKey(nameof(SalesOffice))]
        public int ListedOfficeID { get; set; }
        
        public SalesOffice? ListedOffice { get; set; } = null!;
        public ICollection<Prop_Owner> PropertiesOwned { get; set; } = new HashSet<Prop_Owner>();
    }
}
