using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_S02_EFCore.Models.Sales
{
    [Table("Owners")]
    internal class Owner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Prop_Owner> OwnedProperties { get; set; } = new HashSet<Prop_Owner>();
    }
}
